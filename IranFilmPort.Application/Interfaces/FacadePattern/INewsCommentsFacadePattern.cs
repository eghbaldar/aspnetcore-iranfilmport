using IranFilmPort.Application.Services.NewsComments.Commands.PostNewsComment;
using IranFilmPort.Application.Services.NewsComments.Commands.UpdateNewsCommentActive;
using IranFilmPort.Application.Services.NewsComments.Queries.GetNewsComments;
using IranFilmPort.Application.Services.NewsComments.Queries.GetNewsCommentsByUniqueCode;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface INewsCommentsFacadePattern
    {
        public PostNewsCommentService PostNewsCommentService { get; }
        public GetNewsCommentsByUniqueCodeService GetNewsCommentsByUniqueCodeService { get; }
        public GetNewsCommentsService GetNewsCommentsService { get; }
        public UpdateNewsCommentActiveService UpdateNewsCommentActiveService { get; }
    }
}
