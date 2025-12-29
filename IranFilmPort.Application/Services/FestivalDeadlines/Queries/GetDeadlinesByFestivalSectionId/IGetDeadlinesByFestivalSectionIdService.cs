using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.FestivalDeadlines.Queries.GetDeadlinesByFestivalSectionId
{
    public class RequestGetDeadlinesByFestivalSectionIdServiceDto
    {
        public Guid FestivalSectionId { get; set; }
    }
    public class GetDeadlinesByFestivalSectionIdServiceDto
    {
        public Guid Id { get; set; }
        public DateTime Deadline { get; set; }
        public string Fee { get; set; }
    }
    public class ResultGetDeadlinesByFestivalSectionIdServiceDto
    {
        public List<GetDeadlinesByFestivalSectionIdServiceDto> Result { get; set; }
    }
    public interface IGetDeadlinesByFestivalSectionIdService
    {
        ResultGetDeadlinesByFestivalSectionIdServiceDto Execute(RequestGetDeadlinesByFestivalSectionIdServiceDto req);
    }
    public class GetDeadlinesByFestivalSectionIdService : IGetDeadlinesByFestivalSectionIdService
    {
        private readonly IDataBaseContext _context;
        public GetDeadlinesByFestivalSectionIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetDeadlinesByFestivalSectionIdServiceDto Execute(RequestGetDeadlinesByFestivalSectionIdServiceDto req)
        {
            if (req == null || req.FestivalSectionId == Guid.Empty) return null;
            var result = _context.FestivalDeadlines
                .Where(x => x.FestivalSectionId == req.FestivalSectionId)
                .Select(x => new GetDeadlinesByFestivalSectionIdServiceDto
                {
                    Deadline = x.Deadline,
                    Fee = x.Fee,
                    Id = x.Id
                })
                .ToList();
            return new ResultGetDeadlinesByFestivalSectionIdServiceDto
            {
                Result = result,
            };
        }
    }
}
