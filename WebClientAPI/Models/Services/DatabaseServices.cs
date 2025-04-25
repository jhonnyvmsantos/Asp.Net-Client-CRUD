using System.Data.SqlClient;

namespace WebClientAPI.Models.Services
{
    public static class DatabaseServices
    {
        public static void CreateDatabase()
        {
            const string connectionStringToMaster = @"Server=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";

            using (var connection = new SqlConnection(connectionStringToMaster))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"
            IF EXISTS (SELECT name FROM sys.databases WHERE name = N'WebClientApi') DROP DATABASE WebClientApi;
            CREATE DATABASE WebClientApi;";
                command.ExecuteNonQuery();
            }
        }
    }
}