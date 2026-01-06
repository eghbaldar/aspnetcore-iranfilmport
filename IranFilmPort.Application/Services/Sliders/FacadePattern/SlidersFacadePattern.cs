using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Sliders.Commands.DeleteSlider;
using IranFilmPort.Application.Services.Sliders.Commands.PostSlider;
using IranFilmPort.Application.Services.Sliders.Commands.UpdateSlider;
using IranFilmPort.Application.Services.Sliders.Queries.GetSliders;
using IranFilmPort.Application.Services.Sliders.Queries.GetSlidersForAdmin;

namespace IranFilmPort.Application.Services.Sliders.FacadePattern
{
    public class SlidersFacadePattern: ISlidersFacadePattern
    {
        private readonly IDataBaseContext _context;
        public SlidersFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // PostSliderService
        public PostSliderService _postSliderService;
        public PostSliderService PostSliderService
        {
            get { return _postSliderService = _postSliderService ?? new PostSliderService(_context); }
        }
        // GetSlidersService
        public GetSlidersService _getSlidersService;
        public GetSlidersService GetSlidersService
        {
            get { return _getSlidersService = _getSlidersService ?? new GetSlidersService(_context); }
        }
        // GetSlidersForAdminService
        public GetSlidersForAdminService _getSlidersForAdminService;
        public GetSlidersForAdminService GetSlidersForAdminService
        {
            get { return _getSlidersForAdminService = _getSlidersForAdminService ?? new GetSlidersForAdminService(_context); }
        }
        // UpdateSliderService
        public UpdateSliderService _updateSliderService;
        public UpdateSliderService UpdateSliderService
        {
            get { return _updateSliderService = _updateSliderService ?? new UpdateSliderService(_context); }
        }
        // DeleteSliderService
        public DeleteSliderService _deleteSliderService;
        public DeleteSliderService DeleteSliderService
        {
            get { return _deleteSliderService = _deleteSliderService ?? new DeleteSliderService(_context); }
        }
    }
}
