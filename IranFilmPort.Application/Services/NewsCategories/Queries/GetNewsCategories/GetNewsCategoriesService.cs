using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetArticleCategories;

namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategories
{
    public class GetNewsCategoriesService : IGetNewsCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetNewsCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNewsCategoriesServiceDto Execute()
        {
            var categories = _context.NewsCategories
                .OrderByDescending(cat => cat.InsertDateTime)
                .Select(cate => new GetNewsCategoriesServiceDto
                {
                    Title = cate.Title,
                    SubId = cate.SubId,
                    Id = cate.Id,
                    AutoIncrementId = cate.AutoIncreamentId,
                }).ToList();
            return new ResultGetNewsCategoriesServiceDto
            {
                Result = categories,
            };
        }
    }
}
