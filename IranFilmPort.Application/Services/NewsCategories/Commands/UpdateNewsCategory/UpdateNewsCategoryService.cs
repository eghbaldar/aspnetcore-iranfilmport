using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsCategories.Commands.UpdateNewsCategory
{
    public class UpdateNewsCategoryService : IUpdateNewsCategoryService
    {
        private readonly IDataBaseContext _context;
        public UpdateNewsCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateNewsCategoryServiceDto req)
        {
            var artcileCategory = _context.NewsCategories.Where(x => x.Id == req.Id).First();
            if (artcileCategory != null)
            {
                artcileCategory.Title = req.Title;
                var output = _context.SaveChanges();
                if (output >= 0)
                    return new ResultDto { IsSuccess = true };
                else return new ResultDto { IsSuccess = false };

            }
            else return new ResultDto { IsSuccess = false };
        }
    }
}
