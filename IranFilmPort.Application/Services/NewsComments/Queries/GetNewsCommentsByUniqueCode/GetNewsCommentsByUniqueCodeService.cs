using IranFilmPort.Application.Interfaces.Context;
namespace IranFilmPort.Application.Services.NewsComments.Queries.GetNewsCommentsByUniqueCode
{
    public class GetNewsCommentsByUniqueCodeService : IGetNewsCommentsByUniqueCodeService
    {
        private readonly IDataBaseContext _context;
        public GetNewsCommentsByUniqueCodeService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNewsCommentsByUniqueCodeService Execute(RequestGetNewsCommentsByUniqueCodeService req)
        {
            var newsComments = _context.NewsComments
                .Where(x => x.NewsId == _context.News.Where(y => y.UniqueCode == req.UniqueCode).First().Id)
                .OrderByDescending(x => x.InsertDateTime)
                .Select(x => new GetNewsCommentsByUniqueCodeServiceDto
                {
                    Active = x.Active,
                    Admin = x.Admin,
                    NewsId = x.NewsId,
                    Comment = x.Comment,
                    Email = x.Email,
                    Fullname = x.Fullname,
                    InsertDate = x.InsertDateTime,
                    Id = x.Id,
                    ParentId = x.ParentId
                })
                .ToList();
            if (newsComments.Any())
            {
                return new ResultGetNewsCommentsByUniqueCodeService
                {
                    Result = newsComments,
                    Total = newsComments.Where(x => x.Active == 1).ToList().Count,
                };
            }
            else return new ResultGetNewsCommentsByUniqueCodeService { Result = null };
        }
    }
}
