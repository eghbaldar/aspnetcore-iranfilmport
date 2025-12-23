using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces;
using IranFilmPort.Common.Helpers;
using System.Numerics;

namespace KingetoNews.Services.Users.UpdateUser
{
    public class RequestUpdateUserServiceDto
    {
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool ChangingPassword { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public byte ProviderId { get; set; } // ProviderConstants.cs
        public Guid RoleId { get; set; } // RoleConstants.cs
    }
    public interface IUpdateUserService
    {
        ResultDto Execute(RequestUpdateUserServiceDto req);
    }
    public class UpdateUserService : IUpdateUserService
    {
        private readonly IDataBaseContext _context;
        public UpdateUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateUserServiceDto req)
        {
            if (req == null ||
                req.UserId == Guid.Empty ||
                req.RoleId == Guid.Empty ||
                string.IsNullOrEmpty(req.Firstname.Trim()) ||
                string.IsNullOrEmpty(req.Lastname.Trim()) ||
                string.IsNullOrEmpty(req.Firstname.Trim()) ||
                string.IsNullOrEmpty(req.Username.Trim()) ||
                string.IsNullOrEmpty(req.Username.Trim()) ||
                string.IsNullOrEmpty(req.Password.Trim()))
                return new ResultDto { IsSuccess = false };

            if (req.ChangingPassword && string.IsNullOrEmpty(req.Password))
                return new ResultDto { IsSuccess = false };

            if (!General.IsValidEmail(req.Email.Trim()) ||
                !General.IsValidIranianCellPhone(req.Phone.Trim()))
                return new ResultDto { IsSuccess = false, Message = "فرمت ایمیل و یا موبایل اشتباه است." };

            var user = _context.Users
                .FirstOrDefault(x => x.Id == req.UserId);
            if (user == null) return new ResultDto { IsSuccess = false };

            user.Firstname = req.Firstname.Trim();
            user.Lastname = req.Lastname.Trim();
            user.Username = req.Username.Trim();
            user.Email = req.Email.Trim();
            user.Phone = req.Phone.Trim();
            user.RoleId = req.RoleId;

            if (req.ChangingPassword)
            {
                PasswordHasher passswordHasherHelper = new PasswordHasher();
                var hashedPassword = passswordHasherHelper.HashPassword(req.Password.Trim());
                user.Password = hashedPassword;
            }
            // put & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
