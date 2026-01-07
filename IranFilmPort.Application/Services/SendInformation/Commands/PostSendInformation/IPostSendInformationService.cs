using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;
using IranFilmPort.Common.Helpers;
using System.Net;

namespace IranFilmPort.Application.Services.SendInformation.Commands.PostSendInformation
{
    public class RequestPostSendInformationServiceDto
    {
        public string Fullname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string WhichWay { get; set; } // SendInformationWhichWayContants.cs
        public string? Link { get; set; }
        public string? Password { get; set; }
        public string IP { get; set; }
    }
    public interface IPostSendInformationService
    {
        ResultDto Execute(RequestPostSendInformationServiceDto req);
    }
    public class PostSendInformationService : IPostSendInformationService
    {
        private readonly IDataBaseContext _context;
        public PostSendInformationService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostSendInformationServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Fullname) ||
                string.IsNullOrEmpty(req.IP) ||
                string.IsNullOrEmpty(req.WhichWay)
                ) return new ResultDto { IsSuccess = false };

            if (string.IsNullOrEmpty(req.Email) &&
                string.IsNullOrEmpty(req.Phone)
                ) return new ResultDto { IsSuccess = false, Message = "شماره موبایل و یا ایمیل باید تکمیل شود." };

            // validations
            if (!string.IsNullOrEmpty(req.Email))
                if (!General.IsValidEmail(req.Email.Trim()))
                    return new ResultDto { IsSuccess = false, Message = "فرمت ایمیل اشتباه است." };
            if (!string.IsNullOrEmpty(req.Phone))
                if (!General.IsValidIranianCellPhone(req.Phone.Trim()))
                    return new ResultDto { IsSuccess = false, Message = "فرمت شماره موبایل اشتباه است." };

            IranFilmPort.Domain.Entities.Guest.SendInformation sendInformation
                = new Domain.Entities.Guest.SendInformation()
                {
                    Phone = WebUtility.HtmlDecode(req.Email),
                    Fullname = WebUtility.HtmlDecode(req.Fullname),
                    Email = WebUtility.HtmlDecode(req.Email),
                    Link = WebUtility.HtmlDecode(req.Link),
                    WhichWay = WebUtility.HtmlDecode(req.WhichWay),
                    Password = WebUtility.HtmlDecode(req.Password),
                    Status = StatusConstants.UnderConsideration,
                    IP = req.IP,
                };
            _context.SendInformation.Add(sendInformation);
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
