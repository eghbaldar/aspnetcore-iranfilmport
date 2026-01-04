using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Festivals.Queries.GetAllFestivalsForSitemap
{
    public class GetAllFestivalsForSitemapServiceDto
    {
        public int UniqueCode { get; set; }
        public Guid Id { get; set; }
        public DateTime InsertDate { get; set; }
    }
    public class ResultGetAllFestivalsForSitemapServiceDto
    {
        public List<GetAllFestivalsForSitemapServiceDto> Result { get; set; }
    }
    public interface IGetAllFestivalsForSitemapService
    {
        ResultGetAllFestivalsForSitemapServiceDto Execute();
    }
    public class GetAllFestivalsForSitemapService : IGetAllFestivalsForSitemapService
    {
        private readonly IDataBaseContext _context;
        public GetAllFestivalsForSitemapService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllFestivalsForSitemapServiceDto Execute()
        {
            var festivals = _context.Festivals
                .Select(x => new GetAllFestivalsForSitemapServiceDto
                {
                    Id = x.Id,
                    InsertDate = x.InsertDateTime,
                    UniqueCode = x.UniqueCode
                })
                .OrderByDescending(x => x.InsertDate)
                .ToList();
            return new ResultGetAllFestivalsForSitemapServiceDto
            {
                Result = festivals,
            };
        }
    }
}
