using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategoriesBySubId
{
    public class GetNewsCategoriesBySubIdService : IGetNewsCategoriesBySubIdService
    {
        private readonly IDataBaseContext _context;
        public GetNewsCategoriesBySubIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNewsCategoriesBySubIdServiceDto Execute(RequestGetNewsCategoriesBySubIdServiceDto req)
        {
            var categories = _context.NewsCategories
                .Where(cate => cate.SubId == req.SubId)
                .OrderByDescending(cat => cat.InsertDateTime)
                .Select(cate => new GetNewsCategoriesBySubIdServiceDto
                {
                    Title = cate.Title,
                    SubId = cate.SubId,
                    Id = cate.Id
                }).ToList();
            return new ResultGetNewsCategoriesBySubIdServiceDto
            {
                Result = categories,
            };
        }
    }
}
