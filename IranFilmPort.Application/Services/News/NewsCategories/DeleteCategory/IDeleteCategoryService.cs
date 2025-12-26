using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.News.NewsCategories.DeleteCategory
{
    public class RequestDeleteCategoryServiceDto
    {
        public Guid Id { get; set; }
    }
    public interface IDeleteCategoryService
    {
        ResultDto Execute(RequestDeleteCategoryServiceDto req);
    }
    public class DeleteCategoryService : IDeleteCategoryService
    {
        private readonly IDataBaseContext _context;
        public DeleteCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteCategoryServiceDto req)
        {
            if (req.Id == null || req.Id == Guid.Empty)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                };
            }

            if (CheckExistenceSubCategoriesNews(_context, req.Id))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خبری در این دسته وجود دارد و اجازه حذف شدن آن را ندارید",
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
                cat.DeleteDateTime = DateTime.Now;
                // post & save
                if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
                else return new ResultDto { IsSuccess = false };
            }
        }
        private bool CheckExistenceSubCategoriesNews(IDataBaseContext context, Guid categoryId)
        {
            var parent_or_child = _context.NewsCategories
                .Any(x => x.Id == categoryId && x.SubId == Guid.Empty); // if ture: parent
            if (parent_or_child)
            {
                var children = _context.NewsCategories.Any(x => x.SubId == categoryId);
                if (children) return false; else return true;
            }
            return _context.News.Any(x => x.NewsCategoryId == categoryId);
        }
    }
}
