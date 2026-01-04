using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.UserProjects.Queries.GetUserProjectByIdForAdmin
{
    public class RequestGetUserProjectByIdForAdminDto
    {
        public Guid Id { get; set; }
    }
    public class GetUserProjectByIdForAdminDto
    {
        public int UniqueCode { get; set; }
        public string Username { get; set; }
        public string Slug { get; set; }
        public byte Type { get; set; } // UserProjectTypeConstants.cs
        public string TitleFa { get; set; }
        public string? TitleEn { get; set; }
        public string SynopsisFa { get; set; }
        public string? SynopsisEn { get; set; }
        public DateTime ProductionDate { get; set; }
        public string? PageLink { get; set; }
        public byte Status { get; set; } // StatusConstants.cs
        public string? Director { get; set; }
        public string? DirectorEn { get; set; }
        public string? Writer { get; set; }
        public string? WriterEn { get; set; }
        public string? Producer { get; set; }
        public string? ProducerEn { get; set; }
        public string? Detail { get; set; }
        public string? DetailEn { get; set; }
        public bool Genuine { get; set; } // false: the user didnt' send his work yet true: we checked it
        public string? ArtworkLink { get; set; }
        public string? ArtworkPassword { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public interface IGetUserProjectByIdForAdmin
    {
        GetUserProjectByIdForAdminDto Execute(RequestGetUserProjectByIdForAdminDto req);
    }
    public class GetUserProjectByIdForAdmin : IGetUserProjectByIdForAdmin
    {
        private readonly IDataBaseContext _context;
        public GetUserProjectByIdForAdmin(IDataBaseContext context)
        {
            _context = context;
        }
        public GetUserProjectByIdForAdminDto Execute(RequestGetUserProjectByIdForAdminDto req)
        {
            var result = _context.UserProjects
                .Where(x => x.Id == req.Id)
                .Select(x => new GetUserProjectByIdForAdminDto
                {
                    InsertDateTime = x.InsertDateTime,
                    Slug = x.Slug,
                    UniqueCode = x.UniqueCode,
                    Username = _context.Users.FirstOrDefault(y => y.Id == x.UserId).Username,
                    Status = x.Status,
                    ArtworkLink = x.ArtworkLink,
                    ArtworkPassword = x.ArtworkPassword,
                    Detail = x.Detail,
                    Genuine = x.Genuine,
                    PageLink = x.PageLink,
                    Producer = x.Producer,
                    ProductionDate = x.ProductionDate,
                    SynopsisEn = x.SynopsisEn,
                    SynopsisFa = x.SynopsisFa,
                    TitleEn = x.TitleEn,
                    TitleFa = x.TitleFa,
                    Type = x.Type,
                    Writer = x.Writer,
                    Director = x.Director,
                    DetailEn = x.DetailEn,
                    DirectorEn = x.DirectorEn,
                    ProducerEn = x.ProduerEn,
                    WriterEn = x.WriterEn
                })
                .First();
            return result;
        }
    }
}
