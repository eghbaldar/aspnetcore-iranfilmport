using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces;
using System.Net;

namespace IranFilmPort.Application.Services.Contacts.PostContact
{
    public class RequestPostContactServiceDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string IP { get; set; }
    }
    public interface IPostContactService
    {
        ResultDto Execute(RequestPostContactServiceDto req);
    }
    public class PostContactService : IPostContactService
    {
        private readonly IDataBaseContext _context;
        public PostContactService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostContactServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Email) ||
                string.IsNullOrEmpty(req.Fullname) ||
                string.IsNullOrEmpty(req.Message) ||
                req.Message.Length > 3000 ||
                string.IsNullOrEmpty(req.IP)
                ) return new ResultDto { IsSuccess = false };

            IranFilmPort.Domain.Entities.Contact.Contacts contacts =
                new IranFilmPort.Domain.Entities.Contact.Contacts()
                {
                    Fullname = WebUtility.HtmlDecode(req.Fullname),
                    IP = WebUtility.HtmlDecode(req.IP),
                    Email = WebUtility.HtmlDecode(req.Email),
                    Message = WebUtility.HtmlDecode(req.Message),
                };
            _context.Contacts.Add(contacts);
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
