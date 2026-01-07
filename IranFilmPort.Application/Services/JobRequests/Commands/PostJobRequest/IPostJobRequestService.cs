using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;
using IranFilmPort.Common.Helpers;
using System.Net;

namespace IranFilmPort.Application.Services.JobRequests.Commands.PostJobRequest
{
    public class RequestPostJobRequestServiceDto
    {
        public string Fullname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public byte Category { get; set; } // JobRequestCategoryConstants.cs
        public string Resume { get; set; }
        public string IP { get; set; }
        public byte Status { get; set; } // StatusConstants.cs
    }
    public interface IPostJobRequestService
    {
        ResultDto Execute(RequestPostJobRequestServiceDto req);
    }
    public class PostJobRequestService : IPostJobRequestService
    {
        private readonly IDataBaseContext _context;
        public PostJobRequestService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostJobRequestServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Fullname) ||
                string.IsNullOrEmpty(req.Email) ||
                string.IsNullOrEmpty(req.IP) ||
                string.IsNullOrEmpty(req.Phone) ||
                string.IsNullOrEmpty(req.Resume)
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

            IranFilmPort.Domain.Entities.Guest.JobRequests jobRequests
                = new Domain.Entities.Guest.JobRequests()
                {
                    Phone = WebUtility.HtmlDecode(req.Email),
                    Fullname = WebUtility.HtmlDecode(req.Fullname),
                    Email = WebUtility.HtmlDecode(req.Email),
                    Resume = WebUtility.HtmlDecode(req.Resume),
                    IP = req.IP,
                    Category = req.Category,
                    Status = StatusConstants.UnderConsideration,                    
                };
            _context.JobRequests.Add(jobRequests);
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
