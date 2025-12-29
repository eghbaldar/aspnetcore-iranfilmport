using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.DeleteFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.PostFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Queries.GetDeadlinesByFestivalSectionId;
using IranFilmPort.Application.Services.FestivalSection.Commands.UpdateFestivalSection;

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
        public GetDeadlinesByFestivalSectionIdService _getDeadlinesByFestivalSectionIdService;
        public GetDeadlinesByFestivalSectionIdService GetDeadlinesByFestivalSectionIdService
        {
            get { return _getDeadlinesByFestivalSectionIdService = _getDeadlinesByFestivalSectionIdService ?? new GetDeadlinesByFestivalSectionIdService(_context); }
        }
        // UpdateFestivalSectionService
        public UpdateFestivalSectionService _updateFestivalSectionService;
        public UpdateFestivalSectionService UpdateFestivalSectionService
        {
            get { return _updateFestivalSectionService = _updateFestivalSectionService ?? new UpdateFestivalSectionService(_context); }
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