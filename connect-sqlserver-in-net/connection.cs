using Devart.Data.SqlServer;

partial class Program
{
    static void Main(string[] args)
    {

        string connectionString =
                "Data Source=127.0.0.1;" +
                "User Id=TestUser;" +
                "Password=TestPassword;" +
                "Initial Catalog=TestDb;" +
                "Encrypt=True;" +
                "TrustServerCertificate=True;" +
                "License Key=**********";

        try
        {
            using (var connection = SqlTest.DatabaseConnection.CreateConnection())
            {
                connection.Open();
                Console.WriteLine("Successfully connected to SQL Server!\n");

                using (SqlCommand command = new SqlCommand("SELECT TOP (10) * FROM actor", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Actor ID: {reader["actor_id"]}, " +
                                          $"Name: {reader["first_name"]} {reader["last_name"]}");
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error connecting to database: {ex.Message}");
        }
    }
}