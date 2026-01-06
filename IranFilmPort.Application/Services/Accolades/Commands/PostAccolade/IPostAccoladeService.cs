using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using System.Net;

namespace IranFilmPort.Application.Services.Accolades.Commands.PostAccolade
{
    public class RequestPostAccoladeServiceDto
    {
        public long FilmId { get; set; }
        public string AccoladeFa { get; set; }
        public string? AccoladeEn { get; set; }
        public int Priority { get; set; }
    }
    public interface IPostAccoladeService
    {
        ResultDto Execute(RequestPostAccoladeServiceDto req);
    }
    public class PostAccoladeService : IPostAccoladeService
    {
        private readonly IDataBaseContext _context;
        public PostAccoladeService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostAccoladeServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.AccoladeFa) ||
                string.IsNullOrEmpty(req.AccoladeEn) ||
                req.FilmId == 0)
                return new ResultDto { IsSuccess = false };

            IranFilmPort.Domain.Entities.Accolades.Accolades accolades =
                new Domain.Entities.Accolades.Accolades()
                {
                    AccoladeEn = req.AccoladeEn,
                    AccoladeFa = req.AccoladeFa,
                    FilmId = req.FilmId,
                    Priority = req.Priority
                };
            _context.Accolades.Add(accolades);
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
