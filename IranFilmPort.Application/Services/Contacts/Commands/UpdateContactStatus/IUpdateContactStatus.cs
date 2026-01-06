using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Contacts.Commands.UpdateContactStatus
{
    public class RequestUpdateContactStatusDto
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
    }
    public interface IUpdateContactStatus
    {
        ResultDto Execute(RequestUpdateContactStatusDto req);
    }
    public class UpdateContactStatus : IUpdateContactStatus
    {
        private readonly IDataBaseContext _context;
        public UpdateContactStatus(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateContactStatusDto req)
        {
            var check = _context.Contacts.FirstOrDefault(x => x.Id == req.Id);
            if (check == null) { return null; }
            check.Status = req.Status;
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
