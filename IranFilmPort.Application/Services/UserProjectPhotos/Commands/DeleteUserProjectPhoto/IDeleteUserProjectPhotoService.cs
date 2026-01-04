using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.UserProjectPhotos.Commands.DeleteUserProjectPhoto
{
    public class RequestDeleteUserProjectPhotoServiceDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
    public interface IDeleteUserProjectPhotoService
    {
        ResultDto Execute(RequestDeleteUserProjectPhotoServiceDto req);
    }
    public class DeleteUserProjectPhotoService : IDeleteUserProjectPhotoService
    {
        private readonly IDataBaseContext _context;
        public DeleteUserProjectPhotoService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteUserProjectPhotoServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty || req.UserId == Guid.Empty) return new ResultDto { IsSuccess = false };
            var project = _context.UserProjects
                .Where(x => x.UserId == req.UserId)
                .Select(x => x.Id)
                .ToList();
            var photo = _context.UserProjectPhotos.FirstOrDefault(x => x.Id == req.Id && project.Contains(x.ProjectId));
            if (photo == null) return new ResultDto { IsSuccess = false };
            photo.DeleteDateTime = DateTime.Now;
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
