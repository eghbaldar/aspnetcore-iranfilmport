using IranFilmPort.Application.Services.AdvertisementModals.Commands.PostAdvertisementModal;
using IranFilmPort.Application.Services.AdvertisementModals.Commands.UpdateActiveModal;
using IranFilmPort.Application.Services.AdvertisementModals.Commands.UpdateAdvertisementModal;
using IranFilmPort.Application.Services.AdvertisementModals.Queries.GetActiveModal;
using IranFilmPort.Application.Services.AdvertisementModals.Queries.GetAdvertisementModalById;
using IranFilmPort.Application.Services.AdvertisementModals.Queries.GetAllModals;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IAdvertisementModalsFacadePattern
    {
        public GetActiveModalService GetActiveModalService { get;}
        public GetAllModalsService GetAllModalsService { get;}
        public UpdateAdvertisementModalService UpdateAdvertisementModalService { get;}
        public PostAdvertisementModalService PostAdvertisementModalService { get;}
        public GetAdvertisementModalByIdService GetAdvertisementModalByIdService { get;}
        public UpdateActiveModalService UpdateActiveModalService { get;}
    }
}
