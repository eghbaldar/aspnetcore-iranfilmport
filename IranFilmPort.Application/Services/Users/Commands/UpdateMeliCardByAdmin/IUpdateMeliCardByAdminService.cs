using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.Users.Commands.UpdateMeliCardByAdmin
{
    public class RequestUpdateMeliCardByAdminServiceDto
    {
        public Guid UserId { get; set; }
        public byte Status { get; set; } // StatusConstants.cs
        public string? Message { get; set; }
    }
    public interface IUpdateMeliCardByAdminService
    {
        ResultDto Execute(RequestUpdateMeliCardByAdminServiceDto req);
    }
    public class UpdateMeliCardByAdminService : IUpdateMeliCardByAdminService
    {
        private readonly IDataBaseContext _context;
        public UpdateMeliCardByAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateMeliCardByAdminServiceDto req)
        {
            if (req == null || req.UserId == Guid.Empty) return new ResultDto { IsSuccess = false };
            if (req.Status == StatusConstants.Rejected && string.IsNullOrEmpty(req.Message))
                return new ResultDto { IsSuccess = false, Message = "علت ردی ذکر شود." };
            var check = _context.Users.FirstOrDefault(x => x.Id == req.UserId);
            if (check == null) return new ResultDto { IsSuccess = false };
            check.MeliCardStatus = req.Status;
            if (req.Status == StatusConstants.Rejected) check.MeliCardStatusMessage = req.Message;
            // put & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
