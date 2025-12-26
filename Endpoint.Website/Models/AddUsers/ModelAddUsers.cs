using IranFilmPort.Application.Services.Roles.Queries.GetAllRoles;
using IranFilmPort.Application.Services.Users.Queries.GetUserById;

namespace Endpoint.Website.Models.AddUsers
{
    public class ModelAddUsers
    {
        public GetUserByIdServiceDto? GetUserByIdServiceDto { get; set; }
        public ResultGetAllRolesServiceDto ResultGetAllRolesServiceDto { get; set; }
        public string? RoleTitle { get; set; }
    }
}
