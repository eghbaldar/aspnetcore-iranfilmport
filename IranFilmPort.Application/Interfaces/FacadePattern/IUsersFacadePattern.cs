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

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IUsersFacadePattern
    {
        public PostUserService PostUserService { get; }
        public UpdateUserService UpdateUserService { get; }
        public CheckUsernamePasswordService CheckUsernamePasswordService { get; }
        public GetAllUsersService GetAllUsersService { get; }
        public GetUserByIdService GetUserByIdService { get; }
        public UpdateInfoUserService UpdateInfoUserService { get; }
        public UpdateMeliCardService UpdateMeliCardService { get; }
        public UpdateHeadshotService UpdateHeadshotService { get; }
        public GetUserProfilesService GetUserProfilesService { get; }
        public GetUserMelicardsService GetUserMelicardsService { get; }
        public GetUserHeadshotsService GetUserHeadshotsService { get; }
        public UpdateHeadshotByAdminService UpdateHeadshotByAdminService { get; }
        public UpdateProfileByAdminService UpdateProfileByAdminService { get; }
        public UpdateMeliCardByAdminService UpdateMeliCardByAdminService { get; }
    }
}
