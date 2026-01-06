using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Testimonals.Commands.DeleteTestimonal;
using IranFilmPort.Application.Services.Testimonals.Commands.PostTestimonal;
using IranFilmPort.Application.Services.Testimonals.Queries.GetAllTestimonials;

namespace IranFilmPort.Application.Services.Testimonals.FacadePattern
{
    public class TestimonalsFacadePattern: ITestimonalsFacadePattern
    {
        private readonly IDataBaseContext _context;
        public TestimonalsFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // PostTestimonalService
        public PostTestimonalService _postTestimonalService;
        public PostTestimonalService PostTestimonalService
        {
            get { return _postTestimonalService = _postTestimonalService ?? new PostTestimonalService(_context); }
        }
        // DeleteTestimonalService
        public DeleteTestimonalService _deleteTestimonalService;
        public DeleteTestimonalService DeleteTestimonalService
        {
            get { return _deleteTestimonalService = _deleteTestimonalService ?? new DeleteTestimonalService(_context); }
        }
        // GetAllTestimonialsService
        public GetAllTestimonialsService _getAllTestimonialsService;
        public GetAllTestimonialsService GetAllTestimonialsService
        {
            get { return _getAllTestimonialsService = _getAllTestimonialsService ?? new GetAllTestimonialsService(_context); }
        }
    }
}
