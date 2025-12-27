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
        public string TurnstileToken { get; set; }
    }
    public interface ICheckUsernamePasswordService
    {
        Task<ResultDto<CheckUsernamePasswordServiceDto>> Execute(RequestCheckUsernamePasswordServiceDto req);
    }
    public class CheckUsernamePasswordService : ICheckUsernamePasswordService
    {
        private readonly IDataBaseContext _context;

        public CheckUsernamePasswordService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<CheckUsernamePasswordServiceDto>> Execute(
            RequestCheckUsernamePasswordServiceDto req)
        {
            if (req == null ||
                string.IsNullOrWhiteSpace(req.Username) ||
                string.IsNullOrWhiteSpace(req.Password))
            {
                return new ResultDto<CheckUsernamePasswordServiceDto>
                {
                    IsSuccess = false
                };
            }

            var username = req.Username.Trim();
            var password = req.Password.Trim();

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                return new ResultDto<CheckUsernamePasswordServiceDto>
                {
                    IsSuccess = false,
                    Message = "نام کاربری و یا کلمه عبور نادرست است."
                };
            }

            var passwordHasher = new PasswordHasher();
            var passwordValid = passwordHasher.VerifyPassword(user.Password, password);

            if (!passwordValid)
            {
                return new ResultDto<CheckUsernamePasswordServiceDto>
                {
                    IsSuccess = false,
                    Message = "نام کاربری و یا کلمه عبور نادرست است."
                };
            }
            var roleTitle = await _context.Roles
            .Where(r => r.Id == user.RoleId)
            .Select(r => r.Title)
            .FirstAsync();

            return new ResultDto<CheckUsernamePasswordServiceDto>
            {
                IsSuccess = true,
                Data = new CheckUsernamePasswordServiceDto
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Fullname = $"{user.Firstname} {user.Lastname}",
                    Role = roleTitle
                }
            };
        }
    }

}
