using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces;
using System.Net;

namespace IranFilmPort.Application.Services.News.NewsCategories.UpdateCategory
{
    public class RequestUpdateCategoryServiceDto
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
    }
    public interface IUpdateCategoryService
    {
        ResultDto Execute(RequestUpdateCategoryServiceDto req);
    }
    public class UpdateCategoryService : IUpdateCategoryService
    {
        private readonly IDataBaseContext _context;
        public UpdateCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateCategoryServiceDto req)
        {
            if (string.IsNullOrEmpty(req.Title) || req.Id == null
                || req.Id == Guid.Empty)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                };
            }
            var cat = _context.NewsCategories
                .FirstOrDefault(x => x.Id == req.Id);
            if (cat == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                };
            }
            else
            {
                cat.Title = WebUtility.HtmlDecode(req.Title.Trim());
                // post & save
                if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
                else return new ResultDto { IsSuccess = false };
            }
        }
    }
}
