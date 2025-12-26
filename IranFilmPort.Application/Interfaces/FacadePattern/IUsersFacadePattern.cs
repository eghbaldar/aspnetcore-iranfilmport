using IranFilmPort.Application.Services.Users.Commands.PostUser;
using IranFilmPort.Application.Services.Users.Commands.UpdateUser;
using IranFilmPort.Application.Services.Users.Queries.CheckUsernamePassword;
using IranFilmPort.Application.Services.Users.Queries.GetAllUsers;
using IranFilmPort.Application.Services.Users.Queries.GetUserById;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IUsersFacadePattern
    {
        public PostUserService PostUserService { get; }
        public UpdateUserService UpdateUserService { get; }
        public CheckUsernamePasswordService CheckUsernamePasswordService { get; }
        public GetAllUsersService GetAllUsersService { get; }
        public GetUserByIdService GetUserByIdService { get; }
    }
}
