﻿namespace ProblemsOnADO.NET
{
    using Microsoft.Data.SqlClient;
    using Microsoft.IdentityModel.Tokens;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Text;
    using System.Transactions;

    internal class StartUp
    {
        async static Task Main(string[] args)
        {
            using SqlConnection connection =
                new SqlConnection(Config.ConnectionString);

            //Console.WriteLine(await VillianNames(connection));

            //Console.WriteLine(await MinionNames(connection, 8));

            //Console.WriteLine(await AddMinionAsync(connection));

            //Console.WriteLine(await TownsToUpperAsync(connection, Console.ReadLine()));

            //Console.WriteLine(await RemoveVillainAsync(connection, int.Parse(Console.ReadLine())));

            //Console.WriteLine(await PrintMinionsNames(connection));

            //Console.WriteLine(await IncrementMinionsAgeAsync(connection,
            //    Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(id => int.Parse(id))
            //    .ToArray()));

            //Console.WriteLine(await UseStoredProcedureGetOldAsync(connection,
            //    int.Parse(Console.ReadLine())));
        }


        //P02.VillianNames
        async static Task<string> VillianNames(SqlConnection sqlConnection)
        {
            int minMinions = 3;

            SqlCommand command = new SqlCommand(SqlQuery.VillainsNamesAndTheirMinions, sqlConnection);
            command.Parameters.AddWithValue("@minMinions", minMinions);

            await sqlConnection.OpenAsync();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                sb.AppendLine((string)reader["Output"]);
            }

            return sb.ToString().Trim();
        }

        //P03.MinionNames
        async static Task<string> MinionNames(SqlConnection sqlConnection, int villianId)
        {
            SqlCommand getVillianSqlCommand = new SqlCommand(SqlQuery.GetVillianById, sqlConnection);
            getVillianSqlCommand.Parameters.AddWithValue("@Id", villianId);

            SqlCommand getMinionsCommand = new SqlCommand(SqlQuery.MinionNamesForVillian, sqlConnection);
            getMinionsCommand.Parameters.AddWithValue("@Id", villianId);

            await sqlConnection.OpenAsync();

            string? villianName = (string?)await getVillianSqlCommand.ExecuteScalarAsync();
            if (string.IsNullOrEmpty(villianName))
            {
                return $"No villain with ID {villianId} exists in the database.";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Villain: {villianName}");

            SqlDataReader reader = await getMinionsCommand.ExecuteReaderAsync();
            if (!reader.HasRows)
            {
                sb.AppendLine("(no minions)");
                return sb.ToString().Trim();
            }

            while (reader.Read())
            {
                sb.AppendLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
            }

            return sb.ToString().Trim();
        }

        //P04.Add Minion
        static string[]? GetMinionDataFromConsole()
        {
            return Console.ReadLine()?
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList().Skip(1).ToArray();

        }
        static string? GetVillainNameFromConsole()
        {
            return Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
        }

        async static Task<int?> GetTownIdAsync(SqlConnection connection, string minionTown, StringBuilder sb)
        {
            SqlCommand getTownIdCommand = new SqlCommand(SqlQuery.GetTownIdByName, connection);
            getTownIdCommand.Parameters.AddWithValue("@townName", minionTown);

            SqlCommand insertTownCommand = new SqlCommand(SqlQuery.AddTown, connection);
            insertTownCommand.Parameters.AddWithValue("@townName", minionTown);

            int? townId = (int?)await getTownIdCommand.ExecuteScalarAsync();
            if (townId == null)
            {
                await insertTownCommand.ExecuteNonQueryAsync();
                townId = (int?)await getTownIdCommand.ExecuteScalarAsync();
                sb.AppendLine($"Town {minionTown} was added to the database.");
            }

            return townId;
        }

        async static Task<int?> GetVillainIdAsync(SqlConnection connection, string villainName, StringBuilder sb)
        {
            SqlCommand getVillainIdCommand = new SqlCommand(SqlQuery.GetVillainIdByName, connection);
            getVillainIdCommand.Parameters.AddWithValue("@Name", villainName);

            SqlCommand insertVillainCommand = new SqlCommand(SqlQuery.AddVillain, connection);
            insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);

            int? villainId = (int?)await getVillainIdCommand.ExecuteScalarAsync();
            if (villainId == null)
            {
                await insertVillainCommand.ExecuteNonQueryAsync();
                villainId = (int?)await getVillainIdCommand.ExecuteScalarAsync();
                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }

        async static Task<int?> GetMinionIdAsync(SqlConnection connection, string minionName, int minionAge, int townId)
        {
            SqlCommand getMinionIdCommand = new SqlCommand(SqlQuery.GetMinionIdByName, connection);
            getMinionIdCommand.Parameters.AddWithValue("@Name", minionName);

            int? minionId = (int?)await getMinionIdCommand.ExecuteScalarAsync();
            if (minionId == null)
            {
                SqlCommand insertMinionCommand = new SqlCommand(SqlQuery.AddMinion, connection);
                insertMinionCommand.Parameters.AddWithValue("@name", minionName);
                insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
                insertMinionCommand.Parameters.AddWithValue("@townId", townId);
                await insertMinionCommand.ExecuteNonQueryAsync();
                minionId = (int?)await getMinionIdCommand.ExecuteScalarAsync();
            }

            return minionId;
        }

        async static Task AssignMinionToVillain(SqlConnection connection, int minionId, int villainId, string minionName, string villainName, StringBuilder sb)
        {
            SqlCommand insertMinionVillainKeyCommand = new SqlCommand(SqlQuery.AddMinionsVillainsIdKey, connection);
            insertMinionVillainKeyCommand.Parameters.AddWithValue("@minionId", minionId);
            insertMinionVillainKeyCommand.Parameters.AddWithValue("@villainId", villainId);
            await insertMinionVillainKeyCommand.ExecuteNonQueryAsync();

            sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        async static Task<string> AddMinionAsync(SqlConnection connection)
        {
            string[] minionData = GetMinionDataFromConsole();
            string villainName = GetVillainNameFromConsole();
            string minionName = minionData[0];
            int minionAge = int.Parse(minionData[1]);
            string minionTown = minionData[2];

            await connection.OpenAsync();

            SqlCommand beginTrans = new SqlCommand("BEGIN TRANSACTION", connection);
            SqlCommand commitTrans = new SqlCommand("COMMIT", connection);
            SqlCommand rollbackTrans = new SqlCommand("ROLLBACK", connection);

            //SqlTransaction transaction = connection.BeginTransaction();
            await beginTrans.ExecuteNonQueryAsync();
            try
            {
                StringBuilder result = new StringBuilder();

                int townId = (int)await GetTownIdAsync(connection, minionTown, result);
                int villainId = (int)await GetVillainIdAsync(connection, villainName, result);
                int minionId = (int)await GetMinionIdAsync(connection, minionName, minionAge, townId);
                await AssignMinionToVillain(connection, minionId, villainId, minionName, villainName, result);

                //await transaction.CommitAsync();
                await commitTrans.ExecuteNonQueryAsync();
                return result.ToString().Trim();
            }
            catch (Exception e)
            {
                //await transaction.RollbackAsync();
                await rollbackTrans.ExecuteNonQueryAsync();
                Console.WriteLine("Database not modified! The transaction failed.");
                throw e;
            }
        }

        //P05.Change Town Names Casing
        async static Task<string> TownsToUpperAsync(SqlConnection connection, string countryName)
        {
            StringBuilder sb = new StringBuilder();

            await connection.OpenAsync();
            SqlCommand toUpperCommand = new SqlCommand(SqlQuery.TownsToUpper, connection);
            toUpperCommand.Parameters.AddWithValue("@countryName", countryName);
            int rowsAffected = (int)await toUpperCommand.ExecuteNonQueryAsync();


            if (rowsAffected != 0)
            {
                sb.AppendLine($"{rowsAffected} town names were affected.");
                SqlCommand getAffected = new SqlCommand(SqlQuery.GetAffectedTowns, connection);
                getAffected.Parameters.AddWithValue("@countryName", countryName);
                SqlDataReader reader = await getAffected.ExecuteReaderAsync();
                List<string> townsAffected = new List<string>(rowsAffected);
                while (reader.Read())
                {
                    townsAffected.Add((string)reader["Name"]);
                }
                sb.Append('[');
                sb.Append(string.Join(", ", townsAffected));
                sb.AppendLine("]");
            }
            else
            {
                sb.AppendLine("No town names were affected.");
            }

            return sb.ToString().Trim();
        }

        //P06.*Remove Villain 
        async static Task<string?> GetVillainNameAsync(SqlConnection conneciton, int id)
        {
            SqlCommand getNameCommand = new SqlCommand(SqlQuery.GetVillianNameById, conneciton);
            getNameCommand.Parameters.AddWithValue("@villainId", id);

            return (string?)await getNameCommand.ExecuteScalarAsync();
        }

        async static Task<int> DeleteMinionVillainKeys(SqlConnection connection, SqlTransaction transaction, int id)
        {
            SqlCommand deleteKeysCommand = new SqlCommand(SqlQuery.DeleteMinionVillainsKey, connection, transaction);
            deleteKeysCommand.Parameters.AddWithValue("@villainId", id);

            return await deleteKeysCommand.ExecuteNonQueryAsync();
        }

        async static Task<int> DeleteVillain(SqlConnection connection, SqlTransaction transaciton, int id)
        {
            SqlCommand deleteVillainCommand = new SqlCommand(SqlQuery.DeleteVillain, connection, transaciton);
            deleteVillainCommand.Parameters.AddWithValue("@villainId", id);

            return await deleteVillainCommand.ExecuteNonQueryAsync();
        }

        async static Task<string> RemoveVillainAsync(SqlConnection connection, int id)
        {
            await connection.OpenAsync();

            string? villainName = await GetVillainNameAsync(connection, id);
            if (string.IsNullOrEmpty(villainName))
            {
                return $"No such villain was found.";
            }

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                int minionsFreed = await DeleteMinionVillainKeys(connection, transaction, id);
                await DeleteVillain(connection, transaction, id);
                await transaction.CommitAsync();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{villainName} was deleted.");
                sb.AppendLine($"{minionsFreed} minions were released.");
                return sb.ToString().Trim();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                Console.WriteLine("Database unchanged!");
                throw e;
            }
        }

        //P07.Print All Minion Names
        async static Task<string> PrintMinionsNames(SqlConnection connection)
        {
            await connection.OpenAsync();
            SqlCommand getNamesCommand = new SqlCommand(SqlQuery.GetAllMinionsNames, connection);
            SqlDataReader reader = await getNamesCommand.ExecuteReaderAsync();
            List<string> Names = new List<string>();
            while (await reader.ReadAsync())
            {
                string name = (string)reader["Name"];
                Names.Add(name);
                Console.WriteLine(name);

            }
            StringBuilder sb = new StringBuilder();
            int length = Names.Count;
            for (int i = 0; i < length / 2; i++)
            {
                sb.AppendLine(Names[i]);
                sb.AppendLine(Names[length - 1 - i]);
            }
            if (length % 2 != 0)
            {
                sb.AppendLine(Names[length / 2]);
            }

            return sb.ToString().Trim();
        }

        //P08.Increase Minion Age
        async static Task<string> IncrementMinionsAgeAsync(SqlConnection connection, int[] ids)
        {
            await connection.OpenAsync();

            foreach (int id in ids)
            {
                SqlCommand updateMinionsCommand = new SqlCommand(SqlQuery.ChangeYearsAndNamesOfMinionsById, connection);
                updateMinionsCommand.Parameters.AddWithValue("@Id", id);
                await updateMinionsCommand.ExecuteNonQueryAsync();
                await updateMinionsCommand.DisposeAsync();
            }

            SqlCommand getMinionsCommand = new SqlCommand(SqlQuery.GetNameAndAgeFromMinions, connection);
            SqlDataReader reader = await getMinionsCommand.ExecuteReaderAsync();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} {reader["Age"]}");
            }

            return sb.ToString().Trim();
        }

        //P09.Increase Age Stored Procedure 
        async static Task<string> UseStoredProcedureGetOldAsync(SqlConnection connection, int id)
        {
            await connection.OpenAsync();
            SqlCommand procCommand = new SqlCommand("usp_GetOlder @id", connection);
            procCommand.Parameters.AddWithValue("@id", id);
            await procCommand.ExecuteNonQueryAsync();

            SqlCommand getNameAgeCommand = new SqlCommand(SqlQuery.GetNameAndAgeFromMinion, connection);
            getNameAgeCommand.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = await getNameAgeCommand.ExecuteReaderAsync();

            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} – {reader["Age"]} years old");
            }

            return sb.ToString().Trim();
        }
    }
}