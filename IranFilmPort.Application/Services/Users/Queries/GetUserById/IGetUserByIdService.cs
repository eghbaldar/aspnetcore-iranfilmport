using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Users.Queries.GetUserById
{
    public class GetUserByIdServiceDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public byte ProviderId { get; set; } // ProviderConstants.cs
        public Guid RoleId { get; set; } // RoleConstants.cs
        public DateTime InsertDateTime { get; set; }
    }
    public class RequestGetUserByIdServiceDto
    {
        public Guid? Id { get; set; }
    }
    public interface IGetUserByIdService
    {
        GetUserByIdServiceDto Execute(RequestGetUserByIdServiceDto req);
    }
    public class GetUserByIdService : IGetUserByIdService
    {
        private readonly IDataBaseContext _context;
        public GetUserByIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetUserByIdServiceDto? Execute(RequestGetUserByIdServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty) return null;
            var result =
                _context.Users
                .Where(x => x.Id == req.Id)
                .Select(x => new GetUserByIdServiceDto
                {
                    Id = x.Id,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Email = x.Email,
                    Password = x.Password,
                    ProviderId = x.ProviderId,
                    InsertDateTime = x.InsertDateTime,
                    Username = x.Username,
                    Phone = x.Phone,
                    RoleId = x.RoleId
                })
                .FirstOrDefault();
            if (result == null) return null;
            return result;
        }
    }
}
