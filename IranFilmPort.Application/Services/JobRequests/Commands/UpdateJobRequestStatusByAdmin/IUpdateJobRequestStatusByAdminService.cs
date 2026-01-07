using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.JobRequests.Commands.UpdateJobRequestStatusByAdmin
{
    public class RequestUpdateJobRequestStatusByAdminServiceDto
    {
        public Guid Id { get; set; }
        public byte Status { get; set; }
    }
    public interface IUpdateJobRequestStatusByAdminService
    {
        ResultDto Execute(RequestUpdateJobRequestStatusByAdminServiceDto req);
    }
    public class UpdateJobRequestStatusByAdminService : IUpdateJobRequestStatusByAdminService
    {
        private readonly IDataBaseContext _context;
        public UpdateJobRequestStatusByAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateJobRequestStatusByAdminServiceDto req)
        {
            var check = _context.JobRequests.FirstOrDefault(x => x.Id == req.Id);
            if (check == null) { return null; }
            check.Status = req.Status;
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
