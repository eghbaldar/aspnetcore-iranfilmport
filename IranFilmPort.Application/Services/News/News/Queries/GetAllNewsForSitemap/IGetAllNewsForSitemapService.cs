using IranFilmPort.Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace IranFilmPort.Application.Services.News.News.Queries.GetAllNewsForSitemap
{
    public class RequestGetAllNewsForSitemapServiceDto
    {
        public int CurrentPage { get; set; } // current page
    }
    public class GetAllNewsForSitemapServiceDto
    {
        public DateTime FutureDateTime { get; set; } // FutureDateTime < DateTime.Now()
        public long UniqueCode { get; set; }
    }
    public class ResultGetAllNewsForSitemapServiceDto
    {
        public List<GetAllNewsForSitemapServiceDto> Result { get; set; }
    }
    public interface IGetAllNewsForSitemapService
    {
        ResultGetAllNewsForSitemapServiceDto Execute();
    }
    public class GetAllNewsForSitemapService : IGetAllNewsForSitemapService
    {
        private readonly IDataBaseContext _context;
        public GetAllNewsForSitemapService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllNewsForSitemapServiceDto Execute()
        {
            var result = _context.News
                .Include(x => x.NewsCategory)
                .Select(x => new GetAllNewsForSitemapServiceDto
                {
                    FutureDateTime = x.FutureDateTime,
                    UniqueCode = x.UniqueCode
                })
                .OrderByDescending(x => x.FutureDateTime)
                .ToList();
            return new ResultGetAllNewsForSitemapServiceDto
            {
                Result = result,
            };
        }
    }
}
