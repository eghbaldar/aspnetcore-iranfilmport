using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsByNewsCategoryId;

namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsSubCategories
{
    public interface IGetNewsSubCategoriesService
    {
        ResultGetNewsByNewsCategoryIdServiceDto Execute(RequestGetNewsSubCategoriesServiceDto req);
    }
}
