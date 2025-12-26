using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.News.NewsComments.UpdateCommentActive
{
    public class RequestUpdateCommentActiveServiceDto
    {
        public Guid CommentId { get; set; }
        public byte Active { get; set; } // NewsCommentActiveConstants.cs
    }
    public interface IUpdateCommentActiveService
    {
        ResultDto Execute(RequestUpdateCommentActiveServiceDto req);
    }
    public class UpdateCommentActiveService : IUpdateCommentActiveService
    {
        private readonly IDataBaseContext _context;
        public UpdateCommentActiveService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateCommentActiveServiceDto req)
        {
            if (req == null || req.CommentId == Guid.Empty)
                return new ResultDto { IsSuccess = false };
            var comment = _context.NewsComments
                .FirstOrDefault(x => x.Id == req.CommentId);
            if (comment == null) return new ResultDto { IsSuccess = false };
            comment.Active = req.Active;
            // update & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
