using IranFilmPort.Application.Services.Accolades.Queries.GetAllAccolades;
using IranFilmPort.Application.ServicesDapper.Films.Queries.GetFilms;

namespace Endpoint.Website.Models.Accolades
{
    public class ModelAccolades
    {
        public ResultGetFilmsServiceDapperDto ResultGetFilmsServiceDapperDto { get; set; }
        public ResutlGetAllAccoladesServiceDto ResutlGetAllAccoladesServiceDto { get; set; }
    }
}
