using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.UserProjects.Queries.GetAllUserProjectsForAdmin
{
    public class GetGetAllUserProjectsForAdminServiceDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Fullname { get; set; }
        public int Visit { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetGetAllUserProjectsForAdminServiceDto
    {
        public List<GetGetAllUserProjectsForAdminServiceDto> Result { get; set; }
    }
    public interface IGetGetAllUserProjectsForAdminService
    {
        ResultGetGetAllUserProjectsForAdminServiceDto Execute();
    }
    public class GetGetAllUserProjectsForAdminService : IGetGetAllUserProjectsForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetGetAllUserProjectsForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetGetAllUserProjectsForAdminServiceDto Execute()
        {
            var result = _context.UserProjects
                .Where(x => x.Status == StatusConstants.UnderConsideration)
                .Select(x => new GetGetAllUserProjectsForAdminServiceDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    InsertDateTime = x.InsertDateTime,
                    Fullname = _context.Users.FirstOrDefault(y => y.Id == x.UserId).Lastname,
                    Visit = x.Visit 
                })
                .OrderByDescending(x => x.InsertDateTime)
                .ToList();
            return new ResultGetGetAllUserProjectsForAdminServiceDto
            {
                Result = result
            };
        }
    }
}
