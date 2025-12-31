using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.NewsComments.Commands.PostNewsComment;
using IranFilmPort.Application.Services.NewsComments.Commands.UpdateNewsCommentActive;
using IranFilmPort.Application.Services.NewsComments.Queries.GetNewsComments;
using IranFilmPort.Application.Services.NewsComments.Queries.GetNewsCommentsByUniqueCode;

namespace IranFilmPort.Application.Services.NewsComments.FacadePattern
{
    public class NewsCommentsFacadePattern : INewsCommentsFacadePattern
    {
        private readonly IDataBaseContext _context;
        public NewsCommentsFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // Add News Comments
        public PostNewsCommentService _postNewsCommentService;
        public PostNewsCommentService PostNewsCommentService
        {
            get { return _postNewsCommentService = _postNewsCommentService ?? new PostNewsCommentService(_context); }
        }
        // Get News Comments
        public GetNewsCommentsByUniqueCodeService _getNewsCommentsByUniqueCodeService;
        public GetNewsCommentsByUniqueCodeService GetNewsCommentsByUniqueCodeService
        {
            get { return _getNewsCommentsByUniqueCodeService = _getNewsCommentsByUniqueCodeService ?? new GetNewsCommentsByUniqueCodeService(_context); }
        }
        // Get Newss for Admin
        public GetNewsCommentsService _getNewsCommentsService;
        public GetNewsCommentsService GetNewsCommentsService
        {
            get { return _getNewsCommentsService = _getNewsCommentsService ?? new GetNewsCommentsService(_context); }
        }
        // Update Newss Commet Activate for Admin
        public UpdateNewsCommentActiveService _updateNewsCommentActiveService;
        public UpdateNewsCommentActiveService UpdateNewsCommentActiveService
        {
            get { return _updateNewsCommentActiveService = _updateNewsCommentActiveService ?? new UpdateNewsCommentActiveService(_context); }
        }
    }
}
