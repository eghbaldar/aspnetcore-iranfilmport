using Dapper;
using IranFilmPort.Application.Interfaces.Context;
using Microsoft.Extensions.Configuration;
using static IranFilmPort.Persistence.Contexts.DapperContenxt;

namespace IranFilmPort.Persistence.Contexts
{
    public class DapperExecutor : DapperContext, IDapperExecutor
    {
        public DapperExecutor(IConfiguration configuration)
            : base(configuration)
        {
        }
        public async Task<int> ExecuteAsync(string sql, object? param = null)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(sql, param);
        }

        public async Task<T?> QuerySingleAsync<T>(string sql, object? param = null)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<T>(sql, param);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<T>(sql, param);
        }

        public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param);
        }
    }
}
