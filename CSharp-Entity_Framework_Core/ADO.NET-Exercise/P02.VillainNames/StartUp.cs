namespace P02.VillainNames
{
    using Microsoft.Data.SqlClient;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            string sqlQuery =
                @"  SELECT 
                    CONCAT_WS(' - ',v.Name, COUNT(*)) AS [Output]
                    FROM Villains AS v
                    JOIN MinionsVillains AS mv
                    ON mv.VillainId = v.Id
                    JOIN Minions AS m
                    ON m.Id = mv.MinionId
                    GROUP BY v.Id, v.Name
                    HAVING COUNT(*) > @minMinions
                    ORDER BY COUNT(*) DESC
                ";
            int minMinions = 3;


            using SqlConnection connection =
                new SqlConnection(Config.ConnectionString);

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@minMinions", minMinions);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
        }
    }
}