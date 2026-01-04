using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.UserProjectPhotos.Commands.UpdateUserProjectPhotoStatus
{
    public class RequestUpdateUserProjectPhotoStatusDto
    {
        public Guid PhotoId { get; set; }
        public byte Status { get; set; }
    }
    public interface IUpdateUserProjectPhotoStatusService
    {
        ResultDto Execute(RequestUpdateUserProjectPhotoStatusDto req);
    }
    public class UpdateUserProjectPhotoStatusService : IUpdateUserProjectPhotoStatusService
    {
        private readonly IDataBaseContext _context;
        public UpdateUserProjectPhotoStatusService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateUserProjectPhotoStatusDto req)
        {
            if (req == null) return new ResultDto { IsSuccess = false };
            var photo = _context.UserProjectPhotos.FirstOrDefault(x => x.Id == req.PhotoId);
            if (photo == null) return new ResultDto { IsSuccess = false };
            photo.Status = req.Status;
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
