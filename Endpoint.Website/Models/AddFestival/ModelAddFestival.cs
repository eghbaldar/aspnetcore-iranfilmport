using IranFilmPort.Application.Services.Countires.Queries.GetAllCountries;
using IranFilmPort.Application.Services.Festivals.Queries.GetFestival;

namespace Endpoint.Website.Models.AddFestival
{
    public class ModelAddFestival
    {
        public ResultGetAllCountriesServiceDto ResultGetAllCountriesServiceDto { get; set; }
        public GetFestivalServiceDto GetFestivalServiceDto { get; set; }
    }
}
