using IranFilmPort.Application.Services.Testimonals.Commands.DeleteTestimonal;
using IranFilmPort.Application.Services.Testimonals.Commands.PostTestimonal;
using IranFilmPort.Application.Services.Testimonals.Queries.GetAllTestimonials;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface ITestimonalsFacadePattern
    {
        public PostTestimonalService PostTestimonalService { get; }
        public DeleteTestimonalService DeleteTestimonalService { get; }
        public GetAllTestimonialsService GetAllTestimonialsService { get; }
    }
}
