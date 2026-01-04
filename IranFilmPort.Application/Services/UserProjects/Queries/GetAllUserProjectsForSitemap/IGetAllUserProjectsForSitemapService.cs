using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.UserProjects.Queries.GetAllUserProjectsForSitemap
{
    public class GetAllUserProjectsForSitemapServiceDto
    {
        public int UniqueCode { get; set; }
        public string Username { get; set; }
        public string Slug { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetAllUserProjectsForSitemapServiceDto
    {
        public List<GetAllUserProjectsForSitemapServiceDto> Result { get; set; }
    }
    public interface IGetAllUserProjectsForSitemapService
    {
        ResultGetAllUserProjectsForSitemapServiceDto Execute();
    }
    public class GetAllUserProjectsForSitemapService : IGetAllUserProjectsForSitemapService
    {
        private readonly IDataBaseContext _context;
        public GetAllUserProjectsForSitemapService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllUserProjectsForSitemapServiceDto Execute()
        {
            var result = _context.UserProjects
                .Select(x => new GetAllUserProjectsForSitemapServiceDto
                {
                    InsertDateTime = x.InsertDateTime,
                    Slug = x.Slug,
                    UniqueCode = x.UniqueCode,
                    Username = _context.Users.FirstOrDefault(y => y.Id == x.UserId).Username
                })
                .ToList();
            return new ResultGetAllUserProjectsForSitemapServiceDto
            {
                Result = result
            };
        }
    }
}
