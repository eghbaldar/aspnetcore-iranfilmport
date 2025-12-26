using IranFilmPort.Application.Services.Users.Queries.GetAllUsers;

namespace Endpoint.Website.Models.Users
{
    public class ModelUsers
    {
        public ResultGetAllUsersServiceDto ResultGetAllUsersServiceDto { get; set; }
        public string RoleTitle { get; set; }
    }
}
