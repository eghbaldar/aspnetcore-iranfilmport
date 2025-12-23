using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces;
using IranFilmPort.Common.Helpers;

namespace IranFilmPort.Application.Services.Users.CheckUsernamePassword
{
    public class RequestCheckUsernamePasswordServiceDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public interface ICheckUsernamePasswordService
    {
        ResultDto Execute(RequestCheckUsernamePasswordServiceDto req);
    }
    public class CheckUsernamePasswordService : ICheckUsernamePasswordService
    {
        private readonly IDataBaseContext _context;
        public CheckUsernamePasswordService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestCheckUsernamePasswordServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Username) ||
                string.IsNullOrEmpty(req.Password))
                return new ResultDto { IsSuccess = false };

            PasswordHasher passswordHasherHelper = new PasswordHasher();

            var check = _context
                .Users
                .FirstOrDefault(x => x.Username == req.Username.Trim() &&
                 passswordHasherHelper
                    .VerifyPassword(x.Password, req.Password.Trim())
                );
            if (check == null)
                return new ResultDto { IsSuccess = false };
            else
                return new ResultDto { IsSuccess = false };
        }
    }
}
