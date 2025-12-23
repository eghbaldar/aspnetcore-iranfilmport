using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces;

namespace IranFilmPort.Application.Services.News.News.DeleteNews
{
    public class RequestDeleteNewsServiceDto
    {
        public Guid Id { get; set; }
    }
    public interface IDeleteNewsService
    {
        ResultDto Execute(RequestDeleteNewsServiceDto req);
    }
    public class DeleteNewsService : IDeleteNewsService
    {
        private readonly IDataBaseContext _context;
        public DeleteNewsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteNewsServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty) return new ResultDto { IsSuccess = false };
            var news = _context.News.FirstOrDefault(x => x.Id == req.Id);
            if (news == null) return new ResultDto { IsSuccess = false };
            news.DeleteDateTime = DateTime.Now;
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
