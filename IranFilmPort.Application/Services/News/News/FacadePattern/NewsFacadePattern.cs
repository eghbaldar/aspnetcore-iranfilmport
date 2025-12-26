using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.News.News.Commands.DeleteNews;
using IranFilmPort.Application.Services.News.News.Commands.PostNews;
using IranFilmPort.Application.Services.News.News.Commands.UpdateNews;
using IranFilmPort.Application.Services.News.News.Commands.UpdateNewsVisit;
using IranFilmPort.Application.Services.News.News.Queries.GetAllNewsForAdmin;
using IranFilmPort.Application.Services.News.News.Queries.GetNews;

namespace IranFilmPort.Application.Services.News.News.FacadePattern
{
    public class NewsFacadePattern : INewsFacadePattern
    {
        private readonly IDataBaseContext _context;
        private readonly IServiceProvider _serviceProvider;

        public NewsFacadePattern(IDataBaseContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        // DeleteNewsService
        public DeleteNewsService _deleteNewsService;
        public DeleteNewsService DeleteNewsService
        {
            get { return _deleteNewsService = _deleteNewsService ?? new DeleteNewsService(_context); }
        }
        // PostNewsService
        public PostNewsService _postNewsService;
        public PostNewsService PostNewsService
        {
            get { return _postNewsService = _postNewsService ?? new PostNewsService(_context); }
        }
        // UpdateNewsService
        public UpdateNewsService _updateNewsService;
        public UpdateNewsService UpdateNewsService
        {
            get { return _updateNewsService = _updateNewsService ?? new UpdateNewsService(_context); }
        }
        // GetAllNewsForAdminService
        public GetAllNewsForAdminService _getAllNewsForAdminService;
        public GetAllNewsForAdminService GetAllNewsForAdminService
        {
            get { return _getAllNewsForAdminService = _getAllNewsForAdminService ?? new GetAllNewsForAdminService(_context); }
        }
        // GetNewsForAdminService
        public GetNewsService _getNewsService;
        public GetNewsService GetNewsService
        {
            get { return _getNewsService = _getNewsService ?? new GetNewsService(_context, _serviceProvider); }
        }
        // UpdateNewsVisitService
        public UpdateNewsVisitService _updateNewsVisitService;
        public UpdateNewsVisitService UpdateNewsVisitService
        {
            get { return _updateNewsVisitService = _updateNewsVisitService ?? new UpdateNewsVisitService(_context); }
        }
    }
}
