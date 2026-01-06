using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePatternDapper;
using IranFilmPort.Application.ServicesDapper.Films.Queries.GetFilmById;
using IranFilmPort.Application.ServicesDapper.Films.Queries.GetFilms;

namespace IranFilmPort.Application.ServicesDapper.Films.FacadePattern
{
    public class FilmFacadePatternDapper: IFilmFacadePatternDapper
    {
        private readonly IDapperExecutor _dapper;
        public FilmFacadePatternDapper(IDapperExecutor dapper)
        {
            _dapper = dapper;
        }
        // GetFilmsDapperService
        private GetFilmsServiceDapper _getFilmsDapperService;
        public GetFilmsServiceDapper GetFilmsDapperService
        {
            get { return _getFilmsDapperService = _getFilmsDapperService ?? new GetFilmsServiceDapper(_dapper); }
        }
        // GetFilmByIdServiceDapper
        private GetFilmByIdServiceDapper _getFilmByIdServiceDapper;
        public GetFilmByIdServiceDapper GetFilmByIdServiceDapper
        {
            get { return _getFilmByIdServiceDapper = _getFilmByIdServiceDapper ?? new GetFilmByIdServiceDapper(_dapper); }
        }
    }
}
