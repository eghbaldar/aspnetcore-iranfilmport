using IranFilmPort.Application.Services.Countires.Queries.GetAllCountries;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface ICountiresFacadePattern
    {
        public GetAllCountriesService GetAllCountriesService { get; }
    }
}
