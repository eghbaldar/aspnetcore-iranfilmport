using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsComments.Commands.UpdateNewsCommentActive
{
    public class UpdateNewsCommentActiveService : IUpdateNewsCommentActiveService
    {
        private readonly IDataBaseContext _context;
        public UpdateNewsCommentActiveService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateNewsCommentActiveServiceDto req)
        {
            var comment = _context.NewsComments.Where(x => x.Id == req.CommentId).FirstOrDefault();
            if (comment != null)
            {
                comment.Active = req.Active;

                var output = _context.SaveChanges();
                if (output >= 0)
                    return new ResultDto { IsSuccess = true };
                else return new ResultDto { IsSuccess = false };

            }
            else return new ResultDto { IsSuccess = false };
        }
    }
}
