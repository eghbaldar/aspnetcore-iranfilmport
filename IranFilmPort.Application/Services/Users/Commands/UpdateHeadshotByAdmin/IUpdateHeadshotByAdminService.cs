using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.Users.Commands.UpdateHeadshotByAdmin
{
    public class RequestUpdateHeadshotByAdminServiceDto
    {
        public Guid UserId { get; set; }
        public byte Status { get; set; } // StatusConstants.cs
        public string? Message { get; set; }
    }
    public interface IUpdateHeadshotByAdminService
    {
        ResultDto Execute(RequestUpdateHeadshotByAdminServiceDto req);
    }
    public class UpdateHeadshotByAdminService : IUpdateHeadshotByAdminService
    {
        private readonly IDataBaseContext _context;
        public UpdateHeadshotByAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateHeadshotByAdminServiceDto req)
        {
            if (req == null || req.UserId == Guid.Empty) return new ResultDto { IsSuccess = false };
            if (req.Status == StatusConstants.Rejected && string.IsNullOrEmpty(req.Message))
                return new ResultDto { IsSuccess = false, Message = "علت ردی ذکر شود." };
            var check = _context.Users.FirstOrDefault(x => x.Id == req.UserId);
            if (check == null) return new ResultDto { IsSuccess = false };
            check.HeadshotStatus = req.Status;
            if (req.Status == StatusConstants.Rejected) check.HeadshotStatusMessage = req.Message;
            // put & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
