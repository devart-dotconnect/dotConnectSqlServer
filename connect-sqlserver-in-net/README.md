# How to connect to SQL Server in .NET with C#

Based on [https://www.devart.com/dotconnect/sqlserver/connect-sql-server-in-net.html](https://www.devart.com/dotconnect/sqlserver/connect-sql-server-in-net.html)

This tutorial explains how to connect your .NET application to a SQL Server database using C# and ADO.NET. We’ll walk through creating a simple console application that connects to SQL Server using dotConnect for SQL Server, performs basic operations, and manages connections efficiently.

## Connect to SQL Server using C#

Begin with the essentials: this section demonstrates how to use dotConnect for SQL Server to create a connection string, open a connection, and interact with your SQL Server database. You'll also see how to perform standard operations like reading and writing data using ADO.NET classes such as SqlConnection, SqlCommand, and SqlDataReader.

```cs
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
```