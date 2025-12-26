using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsComments.Queries.GetNewsComments
{
    public class GetNewsCommentsService : IGetNewsCommentsService
    {
        private readonly IDataBaseContext _context;
        public GetNewsCommentsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNewsCommentsServiceDto Execute()
        {
            var groupedComments = _context.NewsComments
           .GroupBy(c => c.NewsId)
           .Select(g => new GetNewsCommentsServiceDto
           {
               NewsId = g.Key,
               Total = g.Count(),
               UnderConsiderationCount = g.Where(c => c.Active == 0).ToList().Count,
               AcceptedCount = g.Where(c => c.Active == 1).ToList().Count,
               RejectedCount = g.Where(c => c.Active == 2).ToList().Count,
               NewsTitle = _context.News.Where(x => x.Id == g.Key).First().Title,
           })
           .OrderByDescending(c => c.UnderConsiderationCount)
           .ToList();

            return new ResultGetNewsCommentsServiceDto
            {
                Result = groupedComments,
            };
        }
    }
}
