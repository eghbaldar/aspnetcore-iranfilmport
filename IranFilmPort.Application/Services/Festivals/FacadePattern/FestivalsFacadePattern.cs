using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Festivals.Commands.DeleteFestival;
using IranFilmPort.Application.Services.Festivals.Commands.PostFestival;
using IranFilmPort.Application.Services.Festivals.Commands.UpdateFestival;
using IranFilmPort.Application.Services.Festivals.Queries.GetAllFestivalsForAdminService;
using IranFilmPort.Application.Services.Festivals.Queries.GetAllFestivalsForSitemap;
using IranFilmPort.Application.Services.Festivals.Queries.GetFestival;
using IranFilmPort.Application.Services.Festivals.Queries.GetIdByUniqueCode;

namespace IranFilmPort.Application.Services.Festivals.FacadePattern
{
    public class FestivalsFacadePattern: IFestivalsFacadePattern
    {
        private readonly IDataBaseContext _context;
        private readonly IServiceProvider _serviceProvider;
        public FestivalsFacadePattern(IDataBaseContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
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
            get { return _postFestivalService = _postFestivalService ?? new PostFestivalService(_context, _serviceProvider); }
        }
        // UpdateFestivalService
        public UpdateFestivalService _updateFestivalService;
        public UpdateFestivalService UpdateFestivalService
        {
            get { return _updateFestivalService = _updateFestivalService ?? new UpdateFestivalService(_context, _serviceProvider); }
        }
        // DeleteFestivalService
        public DeleteFestivalService _deleteFestivalService;
        public DeleteFestivalService DeleteFestivalService
        {
            get { return _deleteFestivalService = _deleteFestivalService ?? new DeleteFestivalService(_context); }
        }
        // GetIdByUniqueCodeService
        public GetIdByUniqueCodeService _getIdByUniqueCodeService;
        public GetIdByUniqueCodeService GetIdByUniqueCodeService
        {
            get { return _getIdByUniqueCodeService = _getIdByUniqueCodeService ?? new GetIdByUniqueCodeService(_context); }
        }
        // GetAllFestivalsForSitemapService
        public GetAllFestivalsForSitemapService _getAllFestivalsForSitemapService;
        public GetAllFestivalsForSitemapService GetAllFestivalsForSitemapService
        {
            get { return _getAllFestivalsForSitemapService = _getAllFestivalsForSitemapService ?? new GetAllFestivalsForSitemapService(_context); }
        }
    }
}
