using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Festivals.Commands.PostFestival;
using IranFilmPort.Application.Services.Festivals.Commands.UpdateFestival;
using IranFilmPort.Application.Services.Festivals.Queries.GetAllFestivalsForAdminService;
using IranFilmPort.Application.Services.Festivals.Queries.GetFestival;

namespace IranFilmPort.Application.Services.Festivals.FacadePattern
{
    public class FestivalsFacadePattern: IFestivalsFacadePattern
    {
        private readonly IDataBaseContext _context;
        public FestivalsFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // DeleteNewsService
        public GetFestivalService _getFestivalService;
        public GetFestivalService GetFestivalService
        {
            get { return _getFestivalService = _getFestivalService ?? new GetFestivalService(_context); }
        }
        // GetAllFestivalsForAdminService
        public GetAllFestivalsForAdminService _getAllFestivalsForAdminService;
        public GetAllFestivalsForAdminService GetAllFestivalsForAdminService
        {
            get { return _getAllFestivalsForAdminService = _getAllFestivalsForAdminService ?? new GetAllFestivalsForAdminService(_context); }
        }
        // PostFestivalService
        public PostFestivalService _postFestivalService;
        public PostFestivalService PostFestivalService
        {
            get { return _postFestivalService = _postFestivalService ?? new PostFestivalService(_context); }
        }
        // UpdateFestivalService
        public UpdateFestivalService _updateFestivalService;
        public UpdateFestivalService UpdateFestivalService
        {
            get { return _updateFestivalService = _updateFestivalService ?? new UpdateFestivalService(_context); }
        }
    }
}
