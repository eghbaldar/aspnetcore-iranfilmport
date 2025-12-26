using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Roles.Queries.GetAllRoles
{
    public class GetAllRolesServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
    public class ResultGetAllRolesServiceDto
    {
        public List<GetAllRolesServiceDto> Result { get; set; }
    }
    public interface IGetAllRolesService
    {
        ResultGetAllRolesServiceDto Execute();
    }
    public class GetAllRolesService : IGetAllRolesService
    {
        private readonly IDataBaseContext _context;
        public GetAllRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllRolesServiceDto Execute()
        {
            var result = _context.Roles
                .Select(x => new GetAllRolesServiceDto
                {
                    Id = x.Id,
                    Title = x.Title,
                })
                .ToList();
            return new ResultGetAllRolesServiceDto
            {
                Result = result
            };
        }
    }
}
