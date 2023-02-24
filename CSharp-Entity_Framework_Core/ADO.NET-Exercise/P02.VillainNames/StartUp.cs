namespace ProblemsOnADO.NET
{
    using Microsoft.Data.SqlClient;
    using System.Text;

    internal class StartUp
    {
        async static Task Main(string[] args)
        {
            using SqlConnection connection =
                new SqlConnection(Config.ConnectionString);

            //Console.WriteLine(await VillianNames(connection));

            Console.WriteLine(await MinionNames(connection, 8));
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
                sb.AppendLine((string) reader["Output"]);
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

            string? villianName = (string?) await getVillianSqlCommand.ExecuteScalarAsync();
            if(string.IsNullOrEmpty(villianName))
            {
                return $"No villain with ID {villianId} exists in the database.";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Villain: {villianName}");

            SqlDataReader reader = await getMinionsCommand.ExecuteReaderAsync();
            if(!reader.HasRows)
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
    }
}