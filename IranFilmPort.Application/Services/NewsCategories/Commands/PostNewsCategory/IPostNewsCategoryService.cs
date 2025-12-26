using IranFilmPort.Application.Common;

namespace IranFilmPort.Application.Services.NewsCategories.Commands.PostNewsCategory
{
    public interface IPostNewsCategoryService
    {
        ResultDto Execute(RequestPostNewsCategoryServiceDto req);
    }
}
