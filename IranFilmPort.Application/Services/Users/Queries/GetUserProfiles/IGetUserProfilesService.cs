using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.Users.Queries.GetUserProfiles
{
    public class GetUserProfilesServiceDto
    {
        public Guid UserId { get; set; }
        public string Fullname { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetUserProfilesServiceDto
    {
        public List<GetUserProfilesServiceDto> Result { get; set; }
    }
    public interface IGetUserProfilesService
    {
        ResultGetUserProfilesServiceDto Execute();
    }
    public class GetUserProfilesService : IGetUserProfilesService
    {
        private readonly IDataBaseContext _context;
        public GetUserProfilesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserProfilesServiceDto Execute()
        {
            var result = _context.Users
                .Where(x => x.MainStatus == StatusConstants.UnderConsideration)
                .Select(x => new GetUserProfilesServiceDto
                {
                    UserId = x.Id,
                    Fullname = $"{x.Firstname} {x.Lastname}",
                    InsertDateTime = DateTime.Now,
                })
                .ToList();
            return new ResultGetUserProfilesServiceDto
            {
                Result = result
            };
        }
    }
}
