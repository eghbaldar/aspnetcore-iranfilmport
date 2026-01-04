using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.SendInformation.Commands.UpdateSendInformationStatusByAdmin
{
    public class RequestUpdateSendInformationStatusByAdminServiceDto
    {
        public Guid Id { get; set; }
        public byte Status { get; set; }
    }
    public interface IUpdateSendInformationStatusByAdminService
    {
        ResultDto Execute(RequestUpdateSendInformationStatusByAdminServiceDto req);
    }
    public class UpdateSendInformationStatusByAdminService : IUpdateSendInformationStatusByAdminService
    {
        private readonly IDataBaseContext _context;
        public UpdateSendInformationStatusByAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateSendInformationStatusByAdminServiceDto req)
        {
            var check = _context.SendInformation.FirstOrDefault(x => x.Id == req.Id);
            if (check == null) { return null; }            
            check.Status = req.Status;
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
