using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace IranFilmPort.Persistence.Contexts
{
    public class DapperContenxt
    {
        public abstract class DapperContext
        {
            private readonly string _connectionString;

            protected DapperContext(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("DesktopServer");
            }

            protected IDbConnection CreateConnection()
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
