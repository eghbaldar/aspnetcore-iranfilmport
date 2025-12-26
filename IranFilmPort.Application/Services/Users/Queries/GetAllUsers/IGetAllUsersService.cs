using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Users.Queries.GetAllUsers
{
    public class RequestGetAllUsersServiceDto
    {
        public string RoleTitle { get; set; }
    }
    public class GetAllUsersServiceDto
    {
        public Guid UserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string RoleTitle { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetAllUsersServiceDto
    {
        public List<GetAllUsersServiceDto> Result { get; set; }
    }
    public interface IGetAllUsersService
    {
        ResultGetAllUsersServiceDto Execute(RequestGetAllUsersServiceDto req);
    }
    public class GetAllUsersService : IGetAllUsersService
    {
        private readonly IDataBaseContext _context;
        public GetAllUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllUsersServiceDto Execute(RequestGetAllUsersServiceDto req)
        {
            if (req == null || string.IsNullOrEmpty(req.RoleTitle)) return null;
            var role = _context.Roles.FirstOrDefault(x => x.Title == req.RoleTitle);
            if (role == null) return null;

            var result = _context.Users
                .Where(x => x.RoleId == role.Id)
                .OrderByDescending(x => x.InsertDateTime)
                .Select(x => new GetAllUsersServiceDto
                {
                    UserId = x.Id,
                    Fullname = x.Username,
                    InsertDateTime = x.InsertDateTime,
                    Username = x.Username,
                    RoleTitle = req.RoleTitle
                })
                .ToList();
            return new ResultGetAllUsersServiceDto
            {
                Result = result
            };
        }
    }
}
