using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategoriesById
{
    public class GetNewsCategoriesByIdService : IGetNewsCategoriesByIdService
    {
        private readonly IDataBaseContext _context;
        public GetNewsCategoriesByIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNewsCategoriesByIdServiceDto Execute(RequestGetNewsCategoriesByIdServiceDto req)
        {
            var artcileCat = _context.News.Where(x => x.Id == req.Id).FirstOrDefault().NewsCategoryId;
            var cateSubId = _context.NewsCategories.Where(cate => cate.Id == artcileCat).FirstOrDefault().SubId;

            var categories2 = _context.NewsCategories
            .Where(cate => cate.SubId == cateSubId)
            .OrderByDescending(cat => cat.InsertDateTime)
            .Select(cate => new GetNewsCategoriesByIdServiceDto
            {
                Title = cate.Title,
                SubId = cate.SubId,
                Id = cate.Id
            }).ToList();
            return new ResultGetNewsCategoriesByIdServiceDto
            {
                Result = categories2,
            };
        }
    }
}
