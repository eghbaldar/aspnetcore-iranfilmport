using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Sliders.Commands.DeleteSlider
{
    public class RequestDeleteSliderServiceDto
    {
        public Guid Id { get; set; }
    }
    public interface IDeleteSliderService
    {
        ResultDto Execute(RequestDeleteSliderServiceDto req);
    }
    public class DeleteSliderService : IDeleteSliderService
    {
        private readonly IDataBaseContext _context;
        public DeleteSliderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteSliderServiceDto req)
        {
            if (req == null ||
                req.Id == Guid.Empty)
            { return new ResultDto { IsSuccess = false }; }

            var slider = _context.Sliders.FirstOrDefault(x => x.Id == req.Id);
            if (slider == null) return new ResultDto { IsSuccess = false };
            slider.DeleteDateTime = DateTime.Now;
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
