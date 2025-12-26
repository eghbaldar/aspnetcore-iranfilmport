using IranFilmPort.Application.Common;

namespace IranFilmPort.Application.Services.NewsCategories.Commands.UpdateNewsCategory
{
    public interface IUpdateNewsCategoryService
    {
        ResultDto Execute(RequestUpdateNewsCategoryServiceDto req);
    }
}
