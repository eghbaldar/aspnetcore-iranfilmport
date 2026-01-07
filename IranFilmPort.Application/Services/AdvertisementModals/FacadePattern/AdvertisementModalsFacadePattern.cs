using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.AdvertisementModals.Commands.PostAdvertisementModal;
using IranFilmPort.Application.Services.AdvertisementModals.Commands.UpdateActiveModal;
using IranFilmPort.Application.Services.AdvertisementModals.Commands.UpdateAdvertisementModal;
using IranFilmPort.Application.Services.AdvertisementModals.Queries.GetActiveModal;
using IranFilmPort.Application.Services.AdvertisementModals.Queries.GetAdvertisementModalById;
using IranFilmPort.Application.Services.AdvertisementModals.Queries.GetAllModals;

namespace IranFilmPort.Application.Services.AdvertisementModals.FacadePattern
{
    public class AdvertisementModalsFacadePattern: IAdvertisementModalsFacadePattern
    {
        private readonly IDataBaseContext _context;
        public AdvertisementModalsFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // GetActiveModalService
        public GetActiveModalService _getActiveModalService;
        public GetActiveModalService GetActiveModalService
        {
            get { return _getActiveModalService = _getActiveModalService ?? new GetActiveModalService(_context); }
        }
        // GetAllModalsService
        public GetAllModalsService _getAllModalsService;
        public GetAllModalsService GetAllModalsService
        {
            get { return _getAllModalsService = _getAllModalsService ?? new GetAllModalsService(_context); }
        }
        // UpdateAdvertisementModalService
        public UpdateAdvertisementModalService _updateAdvertisementModalService;
        public UpdateAdvertisementModalService UpdateAdvertisementModalService
        {
            get { return _updateAdvertisementModalService = _updateAdvertisementModalService ?? new UpdateAdvertisementModalService(_context); }
        }
        // PostAdvertisementModalService
        public PostAdvertisementModalService _postAdvertisementModalService;
        public PostAdvertisementModalService PostAdvertisementModalService
        {
            get { return _postAdvertisementModalService = _postAdvertisementModalService ?? new PostAdvertisementModalService(_context); }
        }
        // GetAdvertisementModalByIdService
        public GetAdvertisementModalByIdService _getAdvertisementModalByIdService;
        public GetAdvertisementModalByIdService GetAdvertisementModalByIdService
        {
            get { return _getAdvertisementModalByIdService = _getAdvertisementModalByIdService ?? new GetAdvertisementModalByIdService(_context); }
        }
        // UpdateActiveModalService
        public UpdateActiveModalService _updateActiveModalService;
        public UpdateActiveModalService UpdateActiveModalService
        {
            get { return _updateActiveModalService = _updateActiveModalService ?? new UpdateActiveModalService(_context); }
        }
    }
}
