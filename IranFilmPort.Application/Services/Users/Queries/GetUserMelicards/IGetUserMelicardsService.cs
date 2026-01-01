using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.Users.Queries.GetUserMelicards
{
    public class GetUserMelicardsServiceDto
    {
        public Guid UserId { get; set; }
        public string Fullname { get; set; }
        public string Melicard { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetUserMelicardsServiceDto
    {
        public List<GetUserMelicardsServiceDto> Result { get; set; }
    }
    public interface IGetUserMelicardsService
    {
        ResultGetUserMelicardsServiceDto Execute();
    }
    public class GetUserMelicardsService : IGetUserMelicardsService
    {
        private readonly IDataBaseContext _context;
        public GetUserMelicardsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserMelicardsServiceDto Execute()
        {
            var result = _context.Users
                .Where(x => x.MeliCardStatus == StatusConstants.UnderConsideration)
                .Select(x => new GetUserMelicardsServiceDto
                {
                    UserId = x.Id,
                    Fullname = $"{x.Firstname} {x.Lastname}",
                    Melicard = x.MeliCard,
                    InsertDateTime = x.InsertDateTime
                })
                .ToList();
            return new ResultGetUserMelicardsServiceDto
            {
                Result = result
            };
        }
    }
}
