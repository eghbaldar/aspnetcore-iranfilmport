using IranFilmPort.Application.Services.News.NewsCategories.GetCategories;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsParentCategories;

namespace Endpoint.Website.Models.NewsCategories
{
    public class ModelNewsCategories
    {        // the following code will fill the TREEVIEW
        public ResultGetCategoriesServiceDto ResultGetCategoriesServiceDto { get; set; }
        // will fill the SELECT Control
        public ResultGetNewsParentCategoriesDto ResultGetParentCategoriesDto { get; set; }
    }
}
