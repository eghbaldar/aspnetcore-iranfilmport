using IranFilmPort.Application.Common;
namespace IranFilmPort.Application.Services.NewsComments.Commands.UpdateNewsCommentActive
{
    public interface IUpdateNewsCommentActiveService
    {
        ResultDto Execute(RequestUpdateNewsCommentActiveServiceDto req);
    }
}
