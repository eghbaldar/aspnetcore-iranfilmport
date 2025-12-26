using IranFilmPort.Application.Common;

namespace IranFilmPort.Application.Services.NewsComments.Commands.PostNewsComment
{
    public interface IPostNewsCommentService
    {
        ResultDto Execute(RequestPostNewsCommentServiceDto req);
    }
}
