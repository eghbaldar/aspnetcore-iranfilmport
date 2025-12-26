using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsComments.Commands.PostNewsComment
{
    public class PostNewsCommentService : IPostNewsCommentService
    {
        private readonly IDataBaseContext _context;
        public PostNewsCommentService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostNewsCommentServiceDto req)
        {
            if (req == null || string.IsNullOrEmpty(req.Comment) || string.IsNullOrEmpty(req.Email) || string.IsNullOrEmpty(req.Fullname))
            {
                return new ResultDto { IsSuccess = false };
            }
            IranFilmPort.Domain.Entities.News.NewsComments newsComments =
                new IranFilmPort.Domain.Entities.News.NewsComments()
                {
                    NewsId = req.NewsId,
                    Fullname = req.Fullname,
                    Email = req.Email,
                    Comment = req.Comment,
                    ParentId = req.ParentId,
                    Admin = req.Admin,
                    Active = req.Active,
                };
            _context.NewsComments.Add(newsComments);
            if (_context.SaveChanges() > 0 || _context.SaveChanges() == 0)
            {
                return new ResultDto { IsSuccess = true };
            }
            else return new ResultDto { IsSuccess = false };
        }
    }
}
