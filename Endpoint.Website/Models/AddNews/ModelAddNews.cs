using IranFilmPort.Application.Services.News.News.GetNewsForAdmin;
using IranFilmPort.Application.Services.News.NewsCategories.GetChildrenCategories;
using IranFilmPort.Application.Services.News.NewsCategories.GetParentCategories;

namespace Endpoint.Website.Models.AddNews
{
    public class ModelAddNews
    {
        // will fill the SELECT Control
        public ResultGetParentCategoriesDto ResultGetParentCategoriesDto { get; set; }
        public GetNewsForAdminServiceDto? GetNewsForAdminServiceDto { get; set; }
        public ResultGetChildrenCategoriesDto? ResultGetChildrenCategoriesDto { get; set; }
    }
}
