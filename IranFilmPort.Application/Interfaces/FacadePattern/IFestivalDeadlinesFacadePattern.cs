using IranFilmPort.Application.Services.FestivalDeadlines.Commands.DeleteFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.PostFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.UpdateFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Queries.GetDeadlinesByFestivalId;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IFestivalDeadlinesFacadePattern
    {
        public GetDeadlinesByFestivalIdService GetDeadlinesByFestivalIdService { get;}
        public UpdateFestivalDeadlineService UpdateFestivalDeadlineService { get;}
        public PostFestivalDeadlineService PostFestivalDeadlineService { get;}
        public DeleteFestivalDeadlineService DeleteFestivalDeadlineService { get;}
    }
}
