using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.Users.Commands.UpdateProfileByAdmin
{
    public class RequestUpdateProfileByAdminServiceDto
    {
        public Guid UserId { get; set; }
        public byte Status { get; set; } // StatusConstants.cs
        public string? Message { get; set; }
    }
    public interface IUpdateProfileByAdminService
    {
        ResultDto Execute(RequestUpdateProfileByAdminServiceDto req);
    }
    public class UpdateProfileByAdminService : IUpdateProfileByAdminService
    {
        private readonly IDataBaseContext _context;
        public UpdateProfileByAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateProfileByAdminServiceDto req)
        {
            if (req == null || req.UserId == Guid.Empty) return new ResultDto { IsSuccess = false };
            if (req.Status == StatusConstants.Rejected && string.IsNullOrEmpty(req.Message))
                return new ResultDto { IsSuccess = false, Message = "علت ردی ذکر شود." };
            var check = _context.Users.FirstOrDefault(x => x.Id == req.UserId);
            if (check == null) return new ResultDto { IsSuccess = false };
            check.MainStatus = req.Status;
            if (req.Status == StatusConstants.Rejected) check.MainStatusMessage = req.Message;
            // put & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
