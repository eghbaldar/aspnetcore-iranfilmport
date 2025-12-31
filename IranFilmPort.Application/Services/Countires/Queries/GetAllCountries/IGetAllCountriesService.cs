using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Countires.Queries.GetAllCountries
{
    public class GetAllCountriesServiceDto
    {
        public byte CountryCode { get; set; }
        public string NameFa { get; set; }
        public string NameEn { get; set; }
    }
    public class ResultGetAllCountriesServiceDto
    {
        public List<GetAllCountriesServiceDto> Result { get; set; }
    }
    public interface IGetAllCountriesService
    {
        ResultGetAllCountriesServiceDto Execute();
    }
    public class GetAllCountriesService: IGetAllCountriesService
    {
        private readonly IDataBaseContext _context;
        public GetAllCountriesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllCountriesServiceDto Execute()
        {
            var countries = _context.Countries
                .OrderBy(x => x.NameEn)
                .Select(x => new GetAllCountriesServiceDto
                {
                    CountryCode = x.CountryCode,
                    NameFa = x.NameFa,
                    NameEn = x.NameEn,
                })
                .ToList();
            return new ResultGetAllCountriesServiceDto
            {
                Result = countries
            };
        }
    }
}
