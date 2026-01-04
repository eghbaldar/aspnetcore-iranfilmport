using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace IranFilmPort.Application.Services.UserProjects.Commands.UpdateUserProjectStatus
{
    public class RequestUpdateUserProjectStatusServiceDto
    {
        public Guid Id { get; set; }
        public byte Status { get; set; } // StatusConstants.cs + Genuine 
    }
    public interface IUpdateUserProjectStatusService
    {
        ResultDto Execute(RequestUpdateUserProjectStatusServiceDto req);
    }
    public class UpdateUserProjectStatusService : IUpdateUserProjectStatusService
    {
        private readonly IDataBaseContext _context;
        public UpdateUserProjectStatusService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateUserProjectStatusServiceDto req)
        {
            var userProject = _context.UserProjects
                .FirstOrDefault(p => p.Id == req.Id);
            if (userProject == null) return new ResultDto { IsSuccess = false };
            switch (req.Status)
            {
                case StatusConstants.Accepted:
                    userProject.Status = StatusConstants.Accepted;
                    userProject.Genuine = false;
                    break;
                case StatusConstants.Rejected:
                    userProject.Status = StatusConstants.Rejected;
                    userProject.Genuine = false;
                    break;
                case 3: // genunine
                    userProject.Status = StatusConstants.Accepted;
                    userProject.Genuine = true;
                    break;
            }
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
