using IranFilmPort.Application.Services.FestivalDeadlines.Queries.GetDeadlinesByFestivalId;
using IranFilmPort.Application.Services.FestivalSection.Queries.GetSectionsByFestivalId;

namespace Endpoint.Website.Models.FestivalSectionDeadline
{
    public class ModelFestivalSectionDeadline
    {
        public ResultGetSectionsByFestivalIdServiceDto ResultGetSectionsByFestivalIdServiceDto { get; set; }
        public ResultGetDeadlinesByFestivalIdServiceDto ResultGetDeadlinesByFestivalIdServiceDto { get; set; }
        public int UniqueCode { get; set; }
        public Guid FestivalId { get; set; }
    }
}
