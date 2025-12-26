using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Roles.Queries.GetAllRoles;

namespace IranFilmPort.Application.Services.Roles.FacadePattern
{
    public class RoleFacadePattern: IRoleFacadePattern
    {
        private readonly IDataBaseContext _context;
        public RoleFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // GetAllRolesService 
        public GetAllRolesService getAllRolesService {  get; set; }
        public GetAllRolesService GetAllRolesService
        {
            get { return getAllRolesService = getAllRolesService ?? new GetAllRolesService(_context); }
        }
    }
}
