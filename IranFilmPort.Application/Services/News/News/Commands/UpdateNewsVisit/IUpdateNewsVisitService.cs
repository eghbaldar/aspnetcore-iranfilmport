using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.News.News.Commands.UpdateNewsVisit
{
    public class RequestUpdateNewsVisitServiceDto
    {
        public Guid NewsId { get; set; }
    }
    public interface IUpdateNewsVisitService
    {
        Task<bool> Execute(RequestUpdateNewsVisitServiceDto req);
    }
    public class UpdateNewsVisitService : IUpdateNewsVisitService
    {
        private readonly IDataBaseContext _context;
        public UpdateNewsVisitService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Execute(RequestUpdateNewsVisitServiceDto req)
        {
            try
            {
                var news = _context.News.Find(req.NewsId);
                news.Visit++;
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
