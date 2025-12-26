using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Helpers;
using System.Net;

namespace IranFilmPort.Application.Services.NewsLetters.PostNewsletter
{
    public class RequestPostNewsletterDto
    {
        public string Email { get; set; }
        public string IP { get; set; }
    }
    public interface IPostNewsletter
    {
        ResultDto Execute(RequestPostNewsletterDto req);
    }
    public class PostNewsletter : IPostNewsletter
    {
        private readonly IDataBaseContext _context;
        public PostNewsletter(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostNewsletterDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Email) ||
                string.IsNullOrEmpty(req.IP)
                )
                return new ResultDto { IsSuccess = false };

            if (!General.IsValidEmail(req.Email))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "فرمت ایمیل وارد شده نادرست است.",
                };
            }
            IranFilmPort.Domain.Entities.Newsletter.Newsletters newsletter = 
                new IranFilmPort.Domain.Entities.Newsletter.Newsletters()
            {
                Email = WebUtility.HtmlDecode(req.Email),
                IP = WebUtility.HtmlDecode(req.IP),
            };
            _context.Newsletters.Add(newsletter);
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
