using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IranFilmPort.Application.Services.Users.Queries.CheckUsernamePassword
{
    public class CheckUsernamePasswordServiceDto
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
    }
    public class RequestCheckUsernamePasswordServiceDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserAgent { get; set; }
    }
    public interface ICheckUsernamePasswordService
    {
        ResultDto<CheckUsernamePasswordServiceDto> Execute(RequestCheckUsernamePasswordServiceDto req);
    }
    public class CheckUsernamePasswordService : ICheckUsernamePasswordService
    {
        private readonly IDataBaseContext _context;
        public CheckUsernamePasswordService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<CheckUsernamePasswordServiceDto> Execute(RequestCheckUsernamePasswordServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Username) ||
                string.IsNullOrEmpty(req.Password))
                return new ResultDto<CheckUsernamePasswordServiceDto> { IsSuccess = false };

            PasswordHasher passswordHasherHelper = new PasswordHasher();

            var check = _context.Users
                .FirstOrDefault(x => x.Username == req.Username.Trim());
            if (check == null)
                return new ResultDto<CheckUsernamePasswordServiceDto> { IsSuccess = false, Message = "نام کاربری و یا کلمه عبور نادرست است." };
            var checkPassword = passswordHasherHelper.VerifyPassword(check.Password, req.Password.Trim());
            if (!checkPassword)
                return new ResultDto<CheckUsernamePasswordServiceDto> { IsSuccess = false, Message = "نام کاربری و یا کلمه عبور نادرست است." };

            return new ResultDto<CheckUsernamePasswordServiceDto>
            {
                IsSuccess = true,
                Data = new CheckUsernamePasswordServiceDto
                {
                    Fullname = $"{check.Firstname} {check.Lastname}",
                    Role = _context.Roles.First(y => y.Id == check.RoleId).Title,
                    UserId = check.Id,
                    Username = check.Username,
                }
            };
        }
    }
}
