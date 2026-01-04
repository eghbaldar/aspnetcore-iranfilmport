using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.UserProjects.Queries.GetAllProjectsByUserId
{
    public class RequestGetAllProjectsByUserIdServiceDto
    {
        public Guid UserId { get; set; }
    }
    public class GetAllProjectsByUserIdServiceDto
    {
        public Guid Id { get; set; }
        public string TitleFa { get; set; }
        public byte Status { get; set; }
        public bool Genuine { get; set; }
        public int Visit { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetAllProjectsByUserIdServiceDto
    {
        public List<GetAllProjectsByUserIdServiceDto> Result { get; set; }
    }
    public interface IGetAllProjectsByUserIdService
    {
        ResultGetAllProjectsByUserIdServiceDto Execute(RequestGetAllProjectsByUserIdServiceDto req);
    }
    public class GetAllProjectsByUserIdService : IGetAllProjectsByUserIdService
    {
        private readonly IDataBaseContext _context;
        public GetAllProjectsByUserIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllProjectsByUserIdServiceDto Execute(RequestGetAllProjectsByUserIdServiceDto req)
        {
            var result = _context.UserProjects
                .Where(x => x.UserId == req.UserId)
                .Select(x => new GetAllProjectsByUserIdServiceDto
                {
                    Id = x.Id,
                    Status = x.Status,
                    TitleFa = x.TitleFa,
                    InsertDateTime = x.InsertDateTime,
                    Genuine = x.Genuine,
                    Visit = x.Visit,
                })
                .OrderByDescending(x => x.InsertDateTime)
                .ToList();
            return new ResultGetAllProjectsByUserIdServiceDto
            {
                Result = result
            };
        }
    }
}
