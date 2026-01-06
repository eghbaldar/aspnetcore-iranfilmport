using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Domain.EntitiesDapper;

namespace IranFilmPort.Application.ServicesDapper.Films.Queries.GetFilms
{
    public class GetFilmsServiceDapperDto
    {
        public long Id { get; set; }
        public string Film { get; set; }
        public string FilmFa { get; set; }
        public string FullTitle { get; set; }
    }
    public class ResultGetFilmsServiceDapperDto
    {
        public List<GetFilmsServiceDapperDto> Result { get; set; }
    }
    public interface IGetFilmsDapperService
    {
        Task<ResultGetFilmsServiceDapperDto> Execute();
    }
    public class GetFilmsServiceDapper: IGetFilmsDapperService
    {
        private readonly IDapperExecutor _dapper;
        public GetFilmsServiceDapper(IDapperExecutor dapper)
        {
            _dapper = dapper;
        }
        public async Task<ResultGetFilmsServiceDapperDto> Execute()
        {
            var films = await _dapper.QueryAsync<FilmsDapper>(
                @"SELECT 
                Id,
                Film,
                FilmFa,
                Film + N' - ' + FilmFa AS FullTitle
                FROM tbFilms
                ORDER BY [Film] ASC"
            );


            return new ResultGetFilmsServiceDapperDto
            {
                Result = films.Select(f => new GetFilmsServiceDapperDto
                {
                    Id = f.Id,
                    FullTitle = f.FullTitle
                }).ToList()
            };
        }
    }
}
