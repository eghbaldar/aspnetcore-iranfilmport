using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePatternDapper;

namespace IranFilmPort.Application.Services.Accolades.Queries.GetAccoladeById
{

    public class RequestGetAccoladeByIdServiceDto
    {
        public long FilmId { get; set; }
    }
    public class GetAccoladeByIdServiceDto
    {
        public Guid Id { get; set; }
        public long FilmId { get; set; }
        public string AccoladeFa { get; set; }
        public string? AccoladeEn { get; set; }
        public int Priority { get; set; }
    }
    public interface IGetAccoladeByIdService
    {
        GetAccoladeByIdServiceDto Execute(RequestGetAccoladeByIdServiceDto req);
    }
    public class GetAccoladeByIdService : IGetAccoladeByIdService
    {
        private readonly IDataBaseContext _context;
        public GetAccoladeByIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetAccoladeByIdServiceDto Execute(RequestGetAccoladeByIdServiceDto req)
        {

            var result = _context.Accolades
                .Where(x => x.FilmId == req.FilmId)
                .Select(x => new GetAccoladeByIdServiceDto
                {
                    AccoladeEn = x.AccoladeEn,
                    AccoladeFa = x.AccoladeFa,
                    FilmId = x.FilmId,
                    Id = x.Id,
                    Priority = x.Priority,
                }).FirstOrDefault();

            return result;
        }
    }
}
