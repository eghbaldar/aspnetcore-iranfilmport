using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using IranFilmPort.Common.Constants;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Users.Commands.UpdateInfoUser
{
    public class RequestUpdateInfoUserServiceDto
    {
        public Guid UserId { get; set; }

        // MAIN INFO
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }

        // EXTRA INFO
        public string? Firstname_En { get; set; }
        public string? Lastname_En { get; set; }
        public string? Resume { get; set; }
        public string? Resume_En { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Website { get; set; }
        public bool? Phone_Visibility { get; set; }
        public bool? Email_Visibility { get; set; }
        public byte? Degree { get; set; } // DegreeContants.cs
        public string? DegreeField { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? IMDb { get; set; }
        public byte Position { get; set; } // PositionContants.cs

    }
    public interface IUpdateInfoUserService
    {
        ResultDto Execute(RequestUpdateInfoUserServiceDto req);
    }
    public class UpdateInfoUserService : IUpdateInfoUserService
    {
        private readonly IDataBaseContext _context;
        public UpdateInfoUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateInfoUserServiceDto req)
        {
            if (req == null ||
                req.UserId == Guid.Empty ||
                string.IsNullOrEmpty(req.Firstname.Trim()) ||
                string.IsNullOrEmpty(req.Lastname.Trim()) ||
                string.IsNullOrEmpty(req.Username.Trim())
                )
                return new ResultDto { IsSuccess = false };

            var user = _context.Users
                .FirstOrDefault(x => x.Id == req.UserId);
            if (user == null) return new ResultDto { IsSuccess = false };

            // main info
            user.Firstname = WebUtility.HtmlDecode(req.Firstname.Trim());
            user.Lastname = WebUtility.HtmlDecode(req.Lastname.Trim());
            user.Username = WebUtility.HtmlDecode(req.Username.Trim());
            // extra info
            user.Resume = WebUtility.HtmlDecode(req.Resume);
            user.Firstname_En = WebUtility.HtmlDecode(req.Firstname_En);
            user.Lastname_En = WebUtility.HtmlDecode(req.Lastname_En);
            user.Resume = WebUtility.HtmlDecode(req.Resume);
            user.Resume_En = WebUtility.HtmlDecode(req.Resume_En);
            user.Birthday = req.Birthday;
            user.Website = WebUtility.HtmlDecode(req.Website);
            user.Phone_Visibility = req.Phone_Visibility;
            user.Email_Visibility = req.Email_Visibility;
            user.Degree = req.Degree;
            user.DegreeField = WebUtility.HtmlDecode(req.DegreeField);
            user.Twitter = WebUtility.HtmlDecode(req.Twitter);
            user.Facebook = WebUtility.HtmlDecode(req.Facebook);
            user.Instagram = WebUtility.HtmlDecode(req.Instagram);
            user.IMDb = WebUtility.HtmlDecode(req.IMDb);
            user.Website = WebUtility.HtmlDecode(req.Website);
            user.Position = req.Position;
            // status
            user.MainStatus = StatusConstants.UnderConsideration;

            // put & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
