using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.UserProjectPhotos.Commands.DeleteUserProjectPhoto;
using IranFilmPort.Application.Services.UserProjectPhotos.Commands.PostUserProjectPhoto;
using IranFilmPort.Application.Services.UserProjectPhotos.Commands.UpdateUserProjectPhotoStatus;
using IranFilmPort.Application.Services.UserProjectPhotos.Queries.GetAllUserProjectPhotosByUserId;
using IranFilmPort.Application.Services.UserProjectPhotos.Queries.GetAllUserProjectPhotosForAdmin;
using IranFilmPort.Application.Services.UserProjects.Commands.PostUserProject;

namespace IranFilmPort.Application.Services.UserProjectPhotos.FacadePattern
{
    public class UserProjectPhotosFacadePattern: IUserProjectPhotosFacadePattern
    {
        private readonly IDataBaseContext _context;
        public UserProjectPhotosFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // GetAllUserProjectPhotosForAdminService
        public GetAllUserProjectPhotosForAdminService _getAllUserProjectPhotosForAdminService;
        public GetAllUserProjectPhotosForAdminService GetAllUserProjectPhotosForAdminService
        {
            get { return _getAllUserProjectPhotosForAdminService = _getAllUserProjectPhotosForAdminService ?? new GetAllUserProjectPhotosForAdminService(_context); }
        }
        // GetAllUserProjectPhotosByUserIdService
        public GetAllUserProjectPhotosByUserIdService _getAllUserProjectPhotosByUserIdService;
        public GetAllUserProjectPhotosByUserIdService GetAllUserProjectPhotosByUserIdService
        {
            get { return _getAllUserProjectPhotosByUserIdService = _getAllUserProjectPhotosByUserIdService ?? new GetAllUserProjectPhotosByUserIdService(_context); }
        }
        // UpdateUserProjectPhotoStatusService
        public UpdateUserProjectPhotoStatusService _updateUserProjectPhotoStatusService;
        public UpdateUserProjectPhotoStatusService UpdateUserProjectPhotoStatusService
        {
            get { return _updateUserProjectPhotoStatusService = _updateUserProjectPhotoStatusService ?? new UpdateUserProjectPhotoStatusService(_context); }
        }
        // PostUserProjectPhotoService
        public PostUserProjectPhotoService _postUserProjectPhotoService;
        public PostUserProjectPhotoService PostUserProjectPhotoService
        {
            get { return _postUserProjectPhotoService = _postUserProjectPhotoService ?? new PostUserProjectPhotoService(_context); }
        }
        // DeleteUserProjectPhotoService
        public DeleteUserProjectPhotoService _deleteUserProjectPhotoService;
        public DeleteUserProjectPhotoService DeleteUserProjectPhotoService
        {
            get { return _deleteUserProjectPhotoService = _deleteUserProjectPhotoService ?? new DeleteUserProjectPhotoService(_context); }
        }
    }
}
