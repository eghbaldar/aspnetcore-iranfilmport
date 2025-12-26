using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Helpers;

namespace IranFilmPort.Application.Services.Users.Commands.PostUser
{
    public class RequestPostUserServiceDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public byte ProviderId { get; set; } // ProviderConstants.cs
        public Guid RoleId { get; set; } // RoleConstants.cs
    }
    public interface IPostUserService
    {
        ResultDto Execute(RequestPostUserServiceDto req);
    }
    public class PostUserService : IPostUserService
    {
        private readonly IDataBaseContext _context;
        public PostUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostUserServiceDto req)
        {
            if (req == null ||
                req.RoleId == Guid.Empty ||
                string.IsNullOrEmpty(req.Firstname.Trim()) ||
                string.IsNullOrEmpty(req.Lastname.Trim()) ||
                string.IsNullOrEmpty(req.Firstname.Trim()) ||
                string.IsNullOrEmpty(req.Username.Trim()) ||
                string.IsNullOrEmpty(req.Username.Trim()) ||
                string.IsNullOrEmpty(req.Password.Trim()))
                return new ResultDto { IsSuccess = false };

            if (!General.IsValidEmail(req.Email.Trim()) ||
                !General.IsValidIranianCellPhone(req.Phone.Trim()))
                return new ResultDto { IsSuccess = false, Message = "فرمت ایمیل و یا موبایل اشتباه است." };

            PasswordHasher passswordHasherHelper = new PasswordHasher();
            var hashedPassword = passswordHasherHelper.HashPassword(req.Password.Trim());

            Domain.Entities.User.Users user
                = new Domain.Entities.User.Users()
                {
                    Firstname = req.Firstname.Trim(),
                    Lastname = req.Lastname.Trim(),
                    Username = req.Username.Trim(),
                    Email = req.Email.Trim(),
                    Phone = req.Phone.Trim(),
                    ProviderId = req.ProviderId,
                    Password = hashedPassword,
                    RoleId = req.RoleId,
                };
            _context.Users.Add(user);
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
