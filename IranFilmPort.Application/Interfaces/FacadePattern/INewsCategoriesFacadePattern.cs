using IranFilmPort.Application.Services.NewsCategories.Commands.DeleteNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Commands.PostNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Commands.UpdateNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsByNewsCategoryId;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategories;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategoriesById;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategoriesBySubId;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsSubCategories;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface INewsCategoriesFacadePattern
    {
        public DeleteNewsCategoryService DeleteNewsCategoryService { get; }
        public PostNewsCategoryService PostNewsCategoryService { get; }
        public UpdateNewsCategoryService UpdateNewsCategoryService { get; }
        public GetNewsByNewsCategoryIdService GetNewsByNewsCategoryIdService { get; }
        public GetNewsCategoriesService GetNewsCategoriesService { get; }
        public GetNewsCategoriesByIdService GetNewsCategoriesByIdService { get; }
        public GetNewsCategoriesBySubIdService GetNewsCategoriesBySubIdService { get; }
        public GetNewsSubCategoriesService GetNewsSubCategoriesService { get; }
    }
}
