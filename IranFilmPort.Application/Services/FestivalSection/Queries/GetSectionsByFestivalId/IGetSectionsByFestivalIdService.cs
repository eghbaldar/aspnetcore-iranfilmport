using IranFilmPort.Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace IranFilmPort.Application.Services.FestivalSection.Queries.GetSectionsByFestivalId
{
    public class RequestGetSectionsByFestivalIdServiceDto
    {
        public Guid FestivalId { get; set; }
    }
    public class GetSectionsByFestivalIdServiceDto
    {
        public Guid SectionId { get; set; }
        public string SectionTitle { get; set; }
    }
    public class ResultGetSectionsByFestivalIdServiceDto
    {
        public List<GetSectionsByFestivalIdServiceDto> Result { get; set; }
    }
    public interface IGetSectionsByFestivalIdService
    {
        ResultGetSectionsByFestivalIdServiceDto Execute(RequestGetSectionsByFestivalIdServiceDto req);
    }
    public class GetSectionsByFestivalIdService: IGetSectionsByFestivalIdService
    {
        private readonly IDataBaseContext _context;
        public GetSectionsByFestivalIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetSectionsByFestivalIdServiceDto Execute(RequestGetSectionsByFestivalIdServiceDto req)
        {
            if (req == null || req.FestivalId == Guid.Empty) return null;
            var result = _context.FestivalSections
                .Where(x => x.FestivalId == req.FestivalId)
                .Select(x => new GetSectionsByFestivalIdServiceDto
                {
                    SectionTitle = x.Title,
                    SectionId = x.Id,
                })
                .ToList();
            return new ResultGetSectionsByFestivalIdServiceDto
            {
                Result = result,
            };
        }
    }
}
