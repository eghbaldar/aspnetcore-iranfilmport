using IranFilmPort.Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace IranFilmPort.Application.Services.FestivalSection.Queries.GetSectionsByFestivalId
{
    public class RequestGetSectionsByFestivalIdServiceDto
    {
        public int FestivalUniqueCode { get; set; }
    }
    public class GetSectionsByFestivalIdServiceDto
    {
        public Guid FestivalId { get; set; }
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
            if (req == null || req.FestivalUniqueCode == 0) return null;
            var festival = _context.Festivals.FirstOrDefault(x => x.UniqueCode == req.FestivalUniqueCode);
            if (festival == null) return null;
            var result = _context.FestivalSections
                .Where(x => x.FestivalId == festival.Id)
                .Select(x => new GetSectionsByFestivalIdServiceDto
                {
                    SectionTitle = x.Title,
                    SectionId = x.Id,
                    FestivalId = x.FestivalId,
                })
                .ToList();
            return new ResultGetSectionsByFestivalIdServiceDto
            {
                Result = result,
            };
        }
    }
}
