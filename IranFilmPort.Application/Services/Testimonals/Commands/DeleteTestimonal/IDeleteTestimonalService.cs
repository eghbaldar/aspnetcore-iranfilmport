using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Testimonals.Commands.DeleteTestimonal
{
    public class RequestDeleteTestimonalServiceDto
    {
        public Guid Id { get; set; }
    }
    public interface IDeleteTestimonalService
    {
        ResultDto Execute(RequestDeleteTestimonalServiceDto req);
    }
    public class DeleteTestimonalService : IDeleteTestimonalService
    {
        private readonly IDataBaseContext _context;
        public DeleteTestimonalService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteTestimonalServiceDto req)
        {
            if (req == null ||
                req.Id == Guid.Empty)
            { return new ResultDto { IsSuccess = false }; }

            var testimonial = _context.Testimonials.FirstOrDefault(x => x.Id == req.Id);
            if (testimonial == null) return new ResultDto { IsSuccess = false };
            testimonial.DeleteDateTime = DateTime.Now;
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
