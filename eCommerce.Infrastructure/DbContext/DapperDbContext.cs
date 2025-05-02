using System.Data;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace eCommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string template = _configuration.GetConnectionString("PostgresConnection")!;
            string connectionString = template!
                .Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
                .Replace("$POSTGRES_PORT", Environment.GetEnvironmentVariable("POSTGRES_PORT"))
                .Replace("$POSTGRES_DB", Environment.GetEnvironmentVariable("POSTGRES_DB"))
                .Replace("$POSTGRES_USER", Environment.GetEnvironmentVariable("POSTGRES_USER"))
                .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));

            // Create a new NpgsqlConnection with the retrieved connection string
            _connection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection DbConnection => _connection;
    }
}