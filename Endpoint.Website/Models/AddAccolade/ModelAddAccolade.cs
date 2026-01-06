using IranFilmPort.Application.Services.Accolades.Queries.GetAccoladeById;
using IranFilmPort.Application.ServicesDapper.Films.Queries.GetFilms;

namespace Endpoint.Website.Models.AddAccolade
{
    public class ModelAddAccolade
    {
        public ResultGetFilmsServiceDapperDto ResultGetFilmsServiceDapperDto { get; set; }
        public GetAccoladeByIdServiceDto GetAccoladeByIdServiceDto { get; set; }
        public long? FilmId { get; set; }
    }
}
