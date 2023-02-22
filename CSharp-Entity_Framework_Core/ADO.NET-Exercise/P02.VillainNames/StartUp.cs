namespace P02.VillainNames
{
    using Microsoft.Data.SqlClient;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection connection =
                new SqlConnection(Config.ConnectionString);
            connection.Open();

            Console.WriteLine("Connected to db!");
        }
    }
}