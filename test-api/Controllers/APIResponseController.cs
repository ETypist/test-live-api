using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIResponseController : ControllerBase
    {
        [HttpGet(Name = "GetAPIResponse")]
        public bool Get()
        {
            string host = "db-etypist-apprunner-test.cuklk1ych7ql.us-east-2.rds.amazonaws.com";
            string database = "postgres";
            string username = "postgres";
            string password = "NCompas123";
            int port = 5432; // Default port for PostgreSQL is 5432

            bool isConnected = false;

            string connectionString = $"Host={host};Database={database};Username={username};Password={password};Port={port}";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    isConnected = true;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
            }

            return isConnected;
        }
    }
}