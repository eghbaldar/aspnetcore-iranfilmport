using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.Users.Queries.GetUserHeadshots
{
    public class GetUserHeadshotsServiceDto
    {
        public Guid UserId { get; set; }
        public string Fullname { get; set; }
        public string Headshot { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetUserHeadshotsServiceDto
    {
        public List<GetUserHeadshotsServiceDto> Result { get; set; }
    }
    public interface IGetUserHeadshotsService
    {
        ResultGetUserHeadshotsServiceDto Execute();
    }
    public class GetUserHeadshotsService : IGetUserHeadshotsService
    {
        private readonly IDataBaseContext _context;
        public GetUserHeadshotsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserHeadshotsServiceDto Execute()
        {
            var result = _context.Users
                .Where(x => x.HeadshotStatus == StatusConstants.UnderConsideration)
                .Select(x => new GetUserHeadshotsServiceDto
                {
                    UserId = x.Id,
                    Fullname = $"{x.Firstname} {x.Lastname}",
                    Headshot = x.Headshot,
                    InsertDateTime = x.InsertDateTime
                })
                .ToList();
            return new ResultGetUserHeadshotsServiceDto
            {
                Result = result
            };
        }
    }
}
