using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsCategories.Commands.PostNewsCategory
{
    public class PostNewsCategoryService : IPostNewsCategoryService
    {
        private readonly IDataBaseContext _context;
        public PostNewsCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostNewsCategoryServiceDto req)
        {
            if (req == null || string.IsNullOrEmpty(req.Title)) return new ResultDto { IsSuccess = false };
            IranFilmPort.Domain.Entities.News.NewsCategories articleCategories = new
                IranFilmPort.Domain.Entities.News.NewsCategories();

            articleCategories.Title = req.Title;
            articleCategories.SubId = req.SubId;

            _context.NewsCategories.Add(articleCategories);
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
