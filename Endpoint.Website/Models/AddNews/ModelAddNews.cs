using IranFilmPort.Application.Services.News.News.Queries.GetNews;
using IranFilmPort.Application.Services.News.NewsCategories.GetChildrenCategories;
using IranFilmPort.Application.Services.News.NewsCategories.GetParentCategories;

namespace Endpoint.Website.Models.AddNews
{
    public class ModelAddNews
    {
        // will fill the SELECT Control
        public ResultGetParentCategoriesDto ResultGetParentCategoriesDto { get; set; }
        public GetNewsServiceDto? GetNewsServiceDto { get; set; }
        public ResultGetChildrenCategoriesDto? ResultGetChildrenCategoriesDto { get; set; }
    }
}
