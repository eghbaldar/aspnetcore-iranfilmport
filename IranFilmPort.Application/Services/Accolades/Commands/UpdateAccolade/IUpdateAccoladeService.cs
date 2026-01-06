using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using System.Net;

namespace IranFilmPort.Application.Services.Accolades.Commands.UpdateAccolade
{
    public class RequestUpdateAccoladeServiceDto
    {
        public long FilmId { get; set; }
        public string AccoladeFa { get; set; }
        public string? AccoladeEn { get; set; }
        public int Priority { get; set; }
    }
    public interface IUpdateAccoladeService
    {
        ResultDto Execute(RequestUpdateAccoladeServiceDto req);
    }
    public class UpdateAccoladeService : IUpdateAccoladeService
    {
        private readonly IDataBaseContext _context;
        public UpdateAccoladeService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateAccoladeServiceDto req)
        {
            if (req == null ||
                           string.IsNullOrEmpty(req.AccoladeFa) ||
                           string.IsNullOrEmpty(req.AccoladeEn) ||
                           req.FilmId == 0)
                return new ResultDto { IsSuccess = false };

            var accolade = _context.Accolades.FirstOrDefault(x => x.FilmId == req.FilmId);
            if (accolade == null) return new ResultDto { IsSuccess = false };

            accolade.AccoladeEn = req.AccoladeEn;
            accolade.AccoladeFa = req.AccoladeFa;
            accolade.Priority = req.Priority;
            
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
