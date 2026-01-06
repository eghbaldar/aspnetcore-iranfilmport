using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Domain.EntitiesDapper;

namespace IranFilmPort.Application.ServicesDapper.Films.Queries.GetFilmById
{
    public class RequestGetFilmByIdServiceDapperDto
    {
        public long Id { get; set; }
    }
    public class GetFilmByIdServiceDapperDto
    {
        public long Id { get; set; }
        public string FullTitle { get; set; }
    }
    public interface IGetFilmsDapperService
    {
        Task<GetFilmByIdServiceDapperDto> Execute(RequestGetFilmByIdServiceDapperDto req);
    }
    public class GetFilmByIdServiceDapper : IGetFilmsDapperService
    {
        private readonly IDapperExecutor _dapper;
        public GetFilmByIdServiceDapper(IDapperExecutor dapper)
        {
            _dapper = dapper;
        }
        public async Task<GetFilmByIdServiceDapperDto> Execute(RequestGetFilmByIdServiceDapperDto req)
        {
            var sql =
                    @"SELECT 
                    Id,
                    Film,
                    FilmFa,
                    Film + N' - ' + FilmFa AS FullTitle
                    FROM tbFilms
                    where id=@id
                    ORDER BY [Film] ASC";

            var film = await _dapper.QueryFirstOrDefaultAsync<FilmsDapper>(
                sql,
                new { req.Id }
            );

            if (film == null) return null;

            return new GetFilmByIdServiceDapperDto
            {
                Id = film.Id,
                FullTitle = film.FullTitle
            };
        }
    }
}
