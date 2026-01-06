using IranFilmPort.Application.Services.Sliders.Commands.DeleteSlider;
using IranFilmPort.Application.Services.Sliders.Commands.PostSlider;
using IranFilmPort.Application.Services.Sliders.Commands.UpdateSlider;
using IranFilmPort.Application.Services.Sliders.Queries.GetSliders;
using IranFilmPort.Application.Services.Sliders.Queries.GetSlidersForAdmin;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface ISlidersFacadePattern
    {
        public PostSliderService PostSliderService { get;}
        public GetSlidersService GetSlidersService { get;}
        public GetSlidersForAdminService GetSlidersForAdminService { get;}
        public UpdateSliderService UpdateSliderService { get;}
        public DeleteSliderService DeleteSliderService { get;}
    }
}
