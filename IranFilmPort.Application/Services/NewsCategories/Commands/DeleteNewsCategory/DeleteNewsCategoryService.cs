using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsCategories.Commands.DeleteNewsCategory
{
    public class DeleteNewsCategoryService : IDeleteNewsCategoryService
    {
        private readonly IDataBaseContext _context;
        public DeleteNewsCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteNewsCategoryServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty) return new ResultDto { IsSuccess = false };
            var cat = _context.NewsCategories.Find(req.Id);
            if (cat != null)
            {
                cat.DeleteDateTime = DateTime.Now;

                var output = _context.SaveChanges();
                if (output >= 0)
                    return new ResultDto { IsSuccess = true };
                else return new ResultDto { IsSuccess = false };

            }
            else return new ResultDto { IsSuccess = false };
        }
    }
}
