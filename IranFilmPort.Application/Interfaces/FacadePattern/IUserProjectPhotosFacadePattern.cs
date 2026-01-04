using IranFilmPort.Application.Services.UserProjectPhotos.Commands.DeleteUserProjectPhoto;
using IranFilmPort.Application.Services.UserProjectPhotos.Commands.PostUserProjectPhoto;
using IranFilmPort.Application.Services.UserProjectPhotos.Commands.UpdateUserProjectPhotoStatus;
using IranFilmPort.Application.Services.UserProjectPhotos.Queries.GetAllUserProjectPhotosByUserId;
using IranFilmPort.Application.Services.UserProjectPhotos.Queries.GetAllUserProjectPhotosForAdmin;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IUserProjectPhotosFacadePattern
    {
        public GetAllUserProjectPhotosForAdminService GetAllUserProjectPhotosForAdminService { get;}
        public GetAllUserProjectPhotosByUserIdService GetAllUserProjectPhotosByUserIdService { get;}
        public UpdateUserProjectPhotoStatusService UpdateUserProjectPhotoStatusService { get;}
        public PostUserProjectPhotoService PostUserProjectPhotoService { get;}
        public DeleteUserProjectPhotoService DeleteUserProjectPhotoService { get;}
    }
}
