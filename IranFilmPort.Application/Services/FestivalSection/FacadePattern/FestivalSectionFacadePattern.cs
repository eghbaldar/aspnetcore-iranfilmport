using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.FestivalSection.Commands.DeleteSectionFestival;
using IranFilmPort.Application.Services.FestivalSection.Commands.PostFestivalSection;
using IranFilmPort.Application.Services.FestivalSection.Commands.UpdateFestivalSection;
using IranFilmPort.Application.Services.FestivalSection.Queries.GetSectionsByFestivalId;

namespace IranFilmPort.Application.Services.FestivalSection.FacadePattern
{
    public class FestivalSectionFacadePattern: IFestivalSectionFacadePattern
    {
        private readonly IDataBaseContext _context;
        public FestivalSectionFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // DeleteNewsService
        public DeleteSectionFestivalService _deleteSectionFestivalService;
        public DeleteSectionFestivalService DeleteSectionFestivalService
        {
            get { return _deleteSectionFestivalService = _deleteSectionFestivalService ?? new DeleteSectionFestivalService(_context); }
        }
        // UpdateFestivalSectionService
        public UpdateFestivalSectionService _updateFestivalSectionService;
        public UpdateFestivalSectionService UpdateFestivalSectionService
        {
            get { return _updateFestivalSectionService = _updateFestivalSectionService ?? new UpdateFestivalSectionService(_context); }
        }
        // PostFestivalSectionService
        public PostFestivalSectionService _postFestivalSectionService;
        public PostFestivalSectionService PostFestivalSectionService
        {
            get { return _postFestivalSectionService = _postFestivalSectionService ?? new PostFestivalSectionService(_context); }
        }
        // GetSectionsByFestivalIdService
        public GetSectionsByFestivalIdService _getSectionsByFestivalIdService;
        public GetSectionsByFestivalIdService GetSectionsByFestivalIdService
        {
            get { return _getSectionsByFestivalIdService = _getSectionsByFestivalIdService ?? new GetSectionsByFestivalIdService(_context); }
        }
    }
}
