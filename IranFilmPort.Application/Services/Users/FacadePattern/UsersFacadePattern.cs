using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Users.Commands.PostUser;
using IranFilmPort.Application.Services.Users.Commands.UpdateHeadshot;
using IranFilmPort.Application.Services.Users.Commands.UpdateHeadshotByAdmin;
using IranFilmPort.Application.Services.Users.Commands.UpdateInfoUser;
using IranFilmPort.Application.Services.Users.Commands.UpdateMeliCard;
using IranFilmPort.Application.Services.Users.Commands.UpdateMeliCardByAdmin;
using IranFilmPort.Application.Services.Users.Commands.UpdateProfileByAdmin;
using IranFilmPort.Application.Services.Users.Commands.UpdateUser;
using IranFilmPort.Application.Services.Users.Queries.CheckUsernamePassword;
using IranFilmPort.Application.Services.Users.Queries.GetAllUsers;
using IranFilmPort.Application.Services.Users.Queries.GetUserById;
using IranFilmPort.Application.Services.Users.Queries.GetUserHeadshots;
using IranFilmPort.Application.Services.Users.Queries.GetUserMelicards;
using IranFilmPort.Application.Services.Users.Queries.GetUserProfiles;

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
        // UpdateInfoUserService
        public UpdateInfoUserService _updateInfoUserService;
        public UpdateInfoUserService UpdateInfoUserService
        {
            get { return _updateInfoUserService = _updateInfoUserService ?? new UpdateInfoUserService(_context); }
        }
        // UpdateMeliCardService
        public UpdateMeliCardService _updateMeliCardService;
        public UpdateMeliCardService UpdateMeliCardService
        {
            get { return _updateMeliCardService = _updateMeliCardService ?? new UpdateMeliCardService(_context); }
        }
        // UpdateHeadshotService
        public UpdateHeadshotService _updateHeadshotService;
        public UpdateHeadshotService UpdateHeadshotService
        {
            get { return _updateHeadshotService = _updateHeadshotService ?? new UpdateHeadshotService(_context); }
        }
        // GetUserProfilesService
        public GetUserProfilesService _getUserProfilesService;
        public GetUserProfilesService GetUserProfilesService
        {
            get { return _getUserProfilesService = _getUserProfilesService ?? new GetUserProfilesService(_context); }
        }
        // GetUserMelicardsService
        public GetUserMelicardsService _getUserMelicardsService;
        public GetUserMelicardsService GetUserMelicardsService
        {
            get { return _getUserMelicardsService = _getUserMelicardsService ?? new GetUserMelicardsService(_context); }
        }
        // GetUserHeadshotsService
        public GetUserHeadshotsService _getUserHeadshotsService;
        public GetUserHeadshotsService GetUserHeadshotsService
        {
            get { return _getUserHeadshotsService = _getUserHeadshotsService ?? new GetUserHeadshotsService(_context); }
        }
        // UpdateMeliCardByAdminService
        public UpdateMeliCardByAdminService _updateMeliCardByAdminService;
        public UpdateMeliCardByAdminService UpdateMeliCardByAdminService
        {
            get { return _updateMeliCardByAdminService = _updateMeliCardByAdminService ?? new UpdateMeliCardByAdminService(_context); }
        }
        // UpdateProfileByAdminService
        public UpdateProfileByAdminService _updateProfileByAdminService;
        public UpdateProfileByAdminService UpdateProfileByAdminService
        {
            get { return _updateProfileByAdminService = _updateProfileByAdminService ?? new UpdateProfileByAdminService(_context); }
        }
        // UpdateHeadshotByAdminService
        public UpdateHeadshotByAdminService _updateHeadshotByAdminService;
        public UpdateHeadshotByAdminService UpdateHeadshotByAdminService
        {
            get { return _updateHeadshotByAdminService = _updateHeadshotByAdminService ?? new UpdateHeadshotByAdminService(_context); }
        }
    }
}
