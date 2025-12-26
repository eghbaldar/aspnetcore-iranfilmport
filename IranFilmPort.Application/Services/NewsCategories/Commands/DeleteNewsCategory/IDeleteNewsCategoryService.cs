using IranFilmPort.Application.Common;

namespace IranFilmPort.Application.Services.NewsCategories.Commands.DeleteNewsCategory
{
    public interface IDeleteNewsCategoryService
    {
        ResultDto Execute(RequestDeleteNewsCategoryServiceDto req);
    }
}
