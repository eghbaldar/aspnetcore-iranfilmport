using IranFilmPort.Application.ServicesDapper.Films.Queries.GetFilmById;
using IranFilmPort.Application.ServicesDapper.Films.Queries.GetFilms;

namespace IranFilmPort.Application.Interfaces.FacadePatternDapper
{
    public interface IFilmFacadePatternDapper
    {
        public GetFilmsServiceDapper GetFilmsDapperService {  get; }
        public GetFilmByIdServiceDapper GetFilmByIdServiceDapper {  get; }
    }
}
