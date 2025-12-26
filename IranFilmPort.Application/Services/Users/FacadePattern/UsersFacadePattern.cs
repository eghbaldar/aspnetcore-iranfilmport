using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Users.Commands.PostUser;
using IranFilmPort.Application.Services.Users.Commands.UpdateUser;
using IranFilmPort.Application.Services.Users.Queries.CheckUsernamePassword;
using IranFilmPort.Application.Services.Users.Queries.GetAllUsers;
using IranFilmPort.Application.Services.Users.Queries.GetUserById;

namespace IranFilmPort.Application.Services.Users.FacadePattern
{
    public class UsersFacadePattern : IUsersFacadePattern
    {
        private readonly IDataBaseContext _context;
        public UsersFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // PostUserService
        public PostUserService _postUserService;
        public PostUserService PostUserService
        {
            get { return _postUserService = _postUserService ?? new PostUserService(_context); }
        }
        // UpdateUserService
        public UpdateUserService _updateUserService;
        public UpdateUserService UpdateUserService
        {
            get { return _updateUserService = _updateUserService ?? new UpdateUserService(_context); }
        }
        // CheckUsernamePasswordService
        public CheckUsernamePasswordService _checkUsernamePasswordService;
        public CheckUsernamePasswordService CheckUsernamePasswordService
        {
            get { return _checkUsernamePasswordService = _checkUsernamePasswordService ?? new CheckUsernamePasswordService(_context); }
        }
        // GetAllUsersService
        public GetAllUsersService _getAllUsersService;
        public GetAllUsersService GetAllUsersService
        {
            get { return _getAllUsersService = _getAllUsersService ?? new GetAllUsersService(_context); }
        }
        // GetUserByIdServiceDto
        public GetUserByIdService _getUserByIdService;
        public GetUserByIdService GetUserByIdService
        {
            get { return _getUserByIdService = _getUserByIdService ?? new GetUserByIdService(_context); }
        }
    }
}
