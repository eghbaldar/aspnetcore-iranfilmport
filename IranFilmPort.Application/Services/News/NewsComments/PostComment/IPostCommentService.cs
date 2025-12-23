using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces;
using IranFilmPort.Common.Constants;
using System.Net;

namespace IranFilmPort.Application.Services.News.NewsComments.PostComment
{
    public class RequestPostCommentServiceDto
    {
        public Guid NewsId { get; set; }
        public string Comment { get; set; }
        public bool Admin { get; set; } // false: regular user
                                        // true: admin
        public Guid? ParentId { get; set; }
        public string? Email { get; set; }
        public string? Fullname { get; set; }
    }
    public interface IPostCommentService
    {
        ResultDto Execute(RequestPostCommentServiceDto req);
    }
    public class PostCommentService : IPostCommentService
    {
        private readonly IDataBaseContext _context;
        public PostCommentService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostCommentServiceDto req)
        {
            if (req == null || req.NewsId == Guid.Empty
                || string.IsNullOrEmpty(req.Comment))
                return new ResultDto { IsSuccess = false };

            IranFilmPort.Domain.Entities.News.NewsComments newsComments
                = new IranFilmPort.Domain.Entities.News.NewsComments()
                {
                    Active = (req.Admin) ? NewsCommentActivateConstants.Accepted : NewsCommentActivateConstants.UnderConsideration,
                    Admin = req.Admin,
                    Comment = WebUtility.HtmlDecode(req.Comment.Trim()),
                    Email = (!string.IsNullOrEmpty(req.Email)) ?
                    WebUtility.UrlDecode(req.Email.Trim()) : null,
                    Fullname = (!string.IsNullOrEmpty(req.Fullname)) ?
                    WebUtility.UrlDecode(req.Fullname.Trim()) : null,
                    ParentId = req.ParentId,
                    NewsId = req.NewsId,
                };
            _context.NewsComments.Add(newsComments);
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
