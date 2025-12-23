using IranFilmPort.Application.Services.Roles.GetAllRoles;
using IranFilmPort.Application.Services.Users.GetUserById;

namespace Endpoint.Website.Models.AddUsers
{
    public class ModelAddUsers
    {
        public GetUserByIdServiceDto? GetUserByIdServiceDto { get; set; }
        public ResultGetAllRolesServiceDto ResultGetAllRolesServiceDto { get; set; }
    }
}
