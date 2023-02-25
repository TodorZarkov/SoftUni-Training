namespace ProblemsOnADO.NET
{
    using Microsoft.Data.SqlClient;
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

            Console.WriteLine(await TownsToUpperAsync(connection, Console.ReadLine()));
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
            int rowsAffected = (int) await toUpperCommand.ExecuteNonQueryAsync();

            
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
    }
}