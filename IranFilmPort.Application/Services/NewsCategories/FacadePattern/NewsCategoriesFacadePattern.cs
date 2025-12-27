using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.NewsCategories.Commands.DeleteNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Commands.PostNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Commands.UpdateNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsByNewsCategoryId;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategories;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategoriesById;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategoriesBySubId;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsChildrenCategories;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsParentCategories;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsSubCategories;

namespace IranFilmPort.Application.Services.NewsCategories.FacadePattern
{
    public class NewsCategoriesFacadePattern : INewsCategoriesFacadePattern
    {
        private readonly IDataBaseContext _context;

        public NewsCategoriesFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // DeleteNewsCategoryService
        public DeleteNewsCategoryService _deleteNewsCategoryService;
        public DeleteNewsCategoryService DeleteNewsCategoryService
        {
            get { return _deleteNewsCategoryService = _deleteNewsCategoryService ?? new DeleteNewsCategoryService(_context); }
        }
        // PostNewsCategoryService
        public PostNewsCategoryService _postNewsCategoryService;
        public PostNewsCategoryService PostNewsCategoryService
        {
            get { return _postNewsCategoryService = _postNewsCategoryService ?? new PostNewsCategoryService(_context); }
        }
        // UpdateNewsCategoryService
        public UpdateNewsCategoryService _updateNewsCategoryService;
        public UpdateNewsCategoryService UpdateNewsCategoryService
        {
            get { return _updateNewsCategoryService = _updateNewsCategoryService ?? new UpdateNewsCategoryService(_context); }
        }
        // GetNewsByNewsCategoryIdService
        public GetNewsByNewsCategoryIdService _getNewsByNewsCategoryIdService;
        public GetNewsByNewsCategoryIdService GetNewsByNewsCategoryIdService
        {
            get { return _getNewsByNewsCategoryIdService = _getNewsByNewsCategoryIdService ?? new GetNewsByNewsCategoryIdService(_context); }
        }
        // GetNewsCategoriesService
        public GetNewsCategoriesService _getNewsCategoriesService;
        public GetNewsCategoriesService GetNewsCategoriesService
        {
            get { return _getNewsCategoriesService = _getNewsCategoriesService ?? new GetNewsCategoriesService(_context); }
        }
        // GetNewsCategoriesByIdService
        public GetNewsCategoriesByIdService _getNewsCategoriesByIdService;
        public GetNewsCategoriesByIdService GetNewsCategoriesByIdService
        {
            get { return _getNewsCategoriesByIdService = _getNewsCategoriesByIdService ?? new GetNewsCategoriesByIdService(_context); }
        }
        // GetNewsCategoriesBySubIdService
        public GetNewsCategoriesBySubIdService _getNewsCategoriesBySubIdService;
        public GetNewsCategoriesBySubIdService GetNewsCategoriesBySubIdService
        {
            get { return _getNewsCategoriesBySubIdService = _getNewsCategoriesBySubIdService ?? new GetNewsCategoriesBySubIdService(_context); }
        }
        // GetNewsSubCategoriesService
        public GetNewsSubCategoriesService _getNewsSubCategoriesService;
        public GetNewsSubCategoriesService GetNewsSubCategoriesService
        {
            get { return _getNewsSubCategoriesService = _getNewsSubCategoriesService ?? new GetNewsSubCategoriesService(_context); }
        }
        // GetNewsParentCategories
        public GetNewsParentCategories _getNewsParentCategories;
        public GetNewsParentCategories GetNewsParentCategories
        {
            get { return _getNewsParentCategories = _getNewsParentCategories ?? new GetNewsParentCategories(_context); }
        }
        // GetNewsChildrenCategories
        public GetNewsChildrenCategories _getNewsChildrenCategories;
        public GetNewsChildrenCategories GetNewsChildrenCategories
        {
            get { return _getNewsChildrenCategories = _getNewsChildrenCategories ?? new GetNewsChildrenCategories(_context); }
        }
    }
}
