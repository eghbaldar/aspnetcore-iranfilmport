using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Countires.Queries.GetAllCountries;

namespace IranFilmPort.Application.Services.Countires.FacadePattern
{
    public class CountiresFacadePattern: ICountiresFacadePattern
    {
        private readonly IDataBaseContext _context;
        public CountiresFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // GetAllCountriesService
        public GetAllCountriesService _getAllCountriesService;
        public GetAllCountriesService GetAllCountriesService
        {
            get { return _getAllCountriesService = _getAllCountriesService ?? new GetAllCountriesService(_context); }
        }
    }
}
