using IranFilmPort.Application.Services.FestivalDeadlines.Commands.DeleteFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.PostFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Queries.GetDeadlinesByFestivalSectionId;
using IranFilmPort.Application.Services.FestivalSection.Commands.UpdateFestivalSection;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IFestivalDeadlinesFacadePattern
    {
        public GetDeadlinesByFestivalSectionIdService GetDeadlinesByFestivalSectionIdService { get;}
        public UpdateFestivalSectionService UpdateFestivalSectionService { get;}
        public PostFestivalDeadlineService PostFestivalDeadlineService { get;}
        public DeleteFestivalDeadlineService DeleteFestivalDeadlineService { get;}
    }
}
