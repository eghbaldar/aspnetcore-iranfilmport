using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.DeleteFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.PostFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.UpdateFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Queries.GetDeadlinesByFestivalId;

namespace IranFilmPort.Application.Services.FestivalDeadlines.FacadePattern
{
    public class FestivalDeadlinesFacadePattern : IFestivalDeadlinesFacadePattern
    {
        private readonly IDataBaseContext _context;
        public FestivalDeadlinesFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // DeleteNewsService
        public GetDeadlinesByFestivalIdService _getDeadlinesByFestivalIdService;
        public GetDeadlinesByFestivalIdService GetDeadlinesByFestivalIdService
        {
            get { return _getDeadlinesByFestivalIdService = _getDeadlinesByFestivalIdService ?? new GetDeadlinesByFestivalIdService(_context); }
        }
        // UpdateFestivalSectionService
        public UpdateFestivalDeadlineService _updateFestivalDeadlineService;
        public UpdateFestivalDeadlineService UpdateFestivalDeadlineService
        {
            get { return _updateFestivalDeadlineService = _updateFestivalDeadlineService ?? new UpdateFestivalDeadlineService(_context); }
        }
        // PostFestivalDeadlineService
        public PostFestivalDeadlineService _postFestivalDeadlineService;
        public PostFestivalDeadlineService PostFestivalDeadlineService
        {
            get { return _postFestivalDeadlineService = _postFestivalDeadlineService ?? new PostFestivalDeadlineService(_context); }
        }
        // DeleteFestivalDeadlineService
        public DeleteFestivalDeadlineService _deleteFestivalDeadlineService;
        public DeleteFestivalDeadlineService DeleteFestivalDeadlineService
        {
            get { return _deleteFestivalDeadlineService = _deleteFestivalDeadlineService ?? new DeleteFestivalDeadlineService(_context); }
        }
    }
}