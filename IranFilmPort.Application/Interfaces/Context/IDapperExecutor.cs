namespace IranFilmPort.Application.Interfaces.Context
{
    public interface IDapperExecutor
    {
        Task<int> ExecuteAsync(string sql, object? param = null);
        Task<T?> QuerySingleAsync<T>(string sql, object? param = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null);
        Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null);
    }
}
