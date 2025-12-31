using IranFilmPort.Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IranFilmPort.Application.Services.FestivalDeadlines.Queries.GetDeadlinesByFestivalId
{
    public class RequestGetDeadlinesByFestivalIdServiceDto
    {
        public int FestivalUniqueCode { get; set; }
    }
    public class GetDeadlinesByFestivalIdServiceDto
    {
        public Guid Id { get; set; }
        public DateTime Deadline { get; set; }
        public string Fee { get; set; }
    }
    public class ResultGetDeadlinesByFestivalIdServiceDto
    {
        public List<GetDeadlinesByFestivalIdServiceDto> Result { get; set; }
    }
    public interface IGetDeadlinesByFestivalIdService
    {
        ResultGetDeadlinesByFestivalIdServiceDto Execute(RequestGetDeadlinesByFestivalIdServiceDto req);
    }
    public class GetDeadlinesByFestivalIdService : IGetDeadlinesByFestivalIdService
    {
        private readonly IDataBaseContext _context;
        public GetDeadlinesByFestivalIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetDeadlinesByFestivalIdServiceDto Execute(RequestGetDeadlinesByFestivalIdServiceDto req)
        {
            if (req == null || req.FestivalUniqueCode == 0) return null;
            var festivalsections = _context.FestivalSections
                .Include(x => x.Festival)                
                .Where(x => x.Festival.UniqueCode == req.FestivalUniqueCode)
                .Select(x => x.Id)
                .ToList();
            if (festivalsections == null) return null;

            var result = _context.FestivalDeadlines
                .Where(x => festivalsections.Contains(x.FestivalSectionId))
                .Select(x => new GetDeadlinesByFestivalIdServiceDto
                {
                    Deadline = x.Deadline,
                    Fee = x.Fee,
                    Id = x.Id
                })
                .ToList();
            return new ResultGetDeadlinesByFestivalIdServiceDto
            {
                Result = result,
            };
        }
    }
}
