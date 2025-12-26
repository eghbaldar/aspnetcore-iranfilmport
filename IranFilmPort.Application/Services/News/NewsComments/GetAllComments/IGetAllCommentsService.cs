using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.News.NewsComments.GetAllComments
{
    public class GetAllCommentsServiceDto
    {
        public Guid NewsId { get; set; }
        public long UniqueCode { get; set; }
        public string NewsTitle { get; set; }
        public string NewsSlug { get; set; }
        public int CommentNumber { get; set; }
        public int UnderConsiderationCommentNumbers { get; set; }
    }
    public class ResultGetAllCommentsServiceDto
    {
        public List<GetAllCommentsServiceDto> Result { get; set; }
    }
    public interface IGetAllCommentsService
    {
        ResultGetAllCommentsServiceDto Execute();
    }
    public class GetAllCommentsService : IGetAllCommentsService
    {
        private readonly IDataBaseContext _context;
        public GetAllCommentsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllCommentsServiceDto Execute()
        {
            var result = _context.NewsComments
                .Where(x => x.ParentId == null || x.ParentId == Guid.Empty)
                .GroupBy(x => x.NewsId)
                .Select(x => new GetAllCommentsServiceDto
                {
                    NewsId = x.Key,
                    CommentNumber = x.Count(),
                    UnderConsiderationCommentNumbers =
                        x.Count(y => y.Active == NewsCommentActivateConstants.UnderConsideration),
                    NewsTitle = _context.News.First(y => y.Id == x.First().NewsId).Title,
                    UniqueCode = _context.News.First(y => y.Id == x.First().NewsId).UniqueCode,
                })
                .OrderByDescending(x => x.UnderConsiderationCommentNumbers)
                .ToList();
            return new ResultGetAllCommentsServiceDto
            {
                Result = result
            };
        }
    }
}
