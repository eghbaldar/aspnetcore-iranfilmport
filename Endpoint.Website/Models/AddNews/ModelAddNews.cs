using IranFilmPort.Application.Services.News.News.Queries.GetNews;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsChildrenCategories;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsParentCategories;

namespace Endpoint.Website.Models.AddNews
{
    public class ModelAddNews
    {
        // will fill the SELECT Control
        public ResultGetNewsParentCategoriesDto ResultGetNewsParentCategoriesDto { get; set; }
        public ResultGetNewsChildrenCategoriesDto? ResultGetNewsChildrenCategoriesDto { get; set; }
        public GetNewsServiceDto? GetNewsServiceDto { get; set; }        
    }
}
