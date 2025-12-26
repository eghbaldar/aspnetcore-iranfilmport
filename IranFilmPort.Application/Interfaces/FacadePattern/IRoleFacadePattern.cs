using IranFilmPort.Application.Services.Roles.Queries.GetAllRoles;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IRoleFacadePattern
    {
        public GetAllRolesService GetAllRolesService { get; }
    }
}
