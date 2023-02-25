namespace ProblemsOnADO.NET
{
    using Microsoft.Data.SqlClient;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    internal class StartUp
    {
        async static Task Main(string[] args)
        {
            using SqlConnection connection =
                new SqlConnection(Config.ConnectionString);

            //Console.WriteLine(await VillianNames(connection));

            //Console.WriteLine(await MinionNames(connection, 8));

            Console.WriteLine(await AddMinion(connection));
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
        static string[]? getMinionDataFromConsole()
        {
            return Console.ReadLine()?
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList().Skip(1).ToArray();

        }
        static string? getVillainNameFromConsole()
        {
            return Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
        }

        static int getIdOrCreate(SqlCommand getCommand, SqlCommand insertCommand)
        {
            int? id = (int?)await getTownIdCommand.ExecuteScalarAsync();
            if (id == null)
            {
                await insertTownCommand.ExecuteNonQueryAsync();
                id = (int?)await getTownIdCommand.ExecuteScalarAsync();
                result.AppendLine($"Town {minionTown} was added to the database.");
            }
        }
        async static Task<string> AddMinion(SqlConnection connection)
        {
            string[] minionData = getMinionDataFromConsole();

            string villainName = getVillainNameFromConsole();


            string minionName = minionData[0];
            int minionAge = int.Parse(minionData[1]);
            string minionTown = minionData[2];

            await connection.OpenAsync();



            SqlCommand beginTransactionCommand = new SqlCommand("BEGIN TRANSACTION", connection);

            SqlCommand rollbackTransactionCommand = new SqlCommand("ROLLBACK", connection);

            SqlCommand commitTransactionCommand = new SqlCommand("COMMIT", connection);

            SqlCommand getMinionIdCommand = new SqlCommand(SqlQuery.GetMinionIdByName, connection);
            getMinionIdCommand.Parameters.AddWithValue("@Name", minionName);

            SqlCommand getVillainIdCommand = new SqlCommand(SqlQuery.GetVillainIdByName, connection);
            getVillainIdCommand.Parameters.AddWithValue("@Name", villainName);

            SqlCommand insertVillainCommand = new SqlCommand(SqlQuery.AddVillain, connection);
            insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);

            SqlCommand getTownIdCommand = new SqlCommand(SqlQuery.GetTownIdByName, connection);
            getTownIdCommand.Parameters.AddWithValue("@townName", minionTown);

            SqlCommand insertTownCommand = new SqlCommand(SqlQuery.AddTown, connection);
            insertTownCommand.Parameters.AddWithValue("@townName", minionTown);

            try
            {
                await beginTransactionCommand.ExecuteNonQueryAsync();
                StringBuilder result = new StringBuilder();

                int? townId = (int?)await getTownIdCommand.ExecuteScalarAsync();
                if (townId == null)
                {
                    await insertTownCommand.ExecuteNonQueryAsync();
                    townId = (int?)await getTownIdCommand.ExecuteScalarAsync();
                    result.AppendLine($"Town {minionTown} was added to the database.");
                }

                int? villainId = (int?)await getVillainIdCommand.ExecuteScalarAsync();
                if (villainId == null)
                {
                    await insertVillainCommand.ExecuteNonQueryAsync();
                    villainId = (int?)await getVillainIdCommand.ExecuteScalarAsync();
                    result.AppendLine($"Villain {villainName} was added to the database.");
                }

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

                SqlCommand insertMinionVillainKeyCommand = new SqlCommand(SqlQuery.AddMinionsVillainsIdKey, connection);
                insertMinionVillainKeyCommand.Parameters.AddWithValue("@minionId", minionId);
                insertMinionVillainKeyCommand.Parameters.AddWithValue("@villainId", villainId);
                await insertMinionVillainKeyCommand.ExecuteNonQueryAsync();

                await commitTransactionCommand.ExecuteNonQueryAsync();

                result.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                return result.ToString().Trim();
            }
            catch (Exception e)
            {
                await rollbackTransactionCommand.ExecuteNonQueryAsync();
                Console.WriteLine("Database not modified! The transaction failed.");
                throw e;
            }
        }
    }
}