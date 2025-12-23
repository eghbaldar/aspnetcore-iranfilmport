using IranFilmPort.Application.Interfaces;

namespace IranFilmPort.Application.Services.Users.GetAllUsers
{
    public class GetAllUsersServiceDto
    {
        public Guid UserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetAllUsersServiceDto
    {
        public List<GetAllUsersServiceDto> Result { get; set; }
    }
    public interface IGetAllUsersService
    {
        ResultGetAllUsersServiceDto Execute();
    }
    public class GetAllUsersService : IGetAllUsersService
    {
        private readonly IDataBaseContext _context;
        public GetAllUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllUsersServiceDto Execute()
        {
            var result = _context.Users
                .Select(x => new GetAllUsersServiceDto
                {
                    UserId = x.Id,
                    Fullname = x.Username,
                    InsertDateTime = x.InsertDateTime,
                    Username = x.Username
                })
                .ToList();
            return new ResultGetAllUsersServiceDto
            {
                Result = result
            };
        }
    }
}
