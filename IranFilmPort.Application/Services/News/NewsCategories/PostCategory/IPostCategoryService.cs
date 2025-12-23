using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces;
using IranFilmPort.Common.Helpers;

namespace IranFilmPort.Application.Services.News.NewsCategories.PostCategory
{
    public class RequestPostCategoryServiceDto
    {
        public string Title { get; set; }
        public Guid? SubId { get; set; }
    }
    public interface IPostCategoryService
    {
        ResultDto Execute(RequestPostCategoryServiceDto req);
    }
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IDataBaseContext _context;
        public PostCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostCategoryServiceDto req)
        {
            if (string.IsNullOrEmpty(req.Title)) { return new ResultDto { IsSuccess = false }; }
            IranFilmPort.Domain.Entities.News.NewsCategories newsCategories = new IranFilmPort.Domain.Entities.News.NewsCategories()
            {
                Title = req.Title,
                SubId = req.SubId,
                AutoIncreamentId = AutoIncrement(_context)
            };
            _context.NewsCategories.Add(newsCategories);
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
        private long AutoIncrement(IDataBaseContext context)
        {
            long _rand = UniqueCodeGenerator.GenerateRandomLong();
            while (_context.NewsCategories
                .Any(x => x.AutoIncreamentId == _rand))
            {
                _rand = UniqueCodeGenerator.GenerateRandomLong();
            }
            return _rand;
        }
    }
}
