using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePatternDapper;
using Microsoft.AspNetCore.Http;

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
        // قسمت زیر ترکیبی شده 
        // چون در وب سایت قبلی جدولی با عنوان
        // tbl_posterOFCustomer
        // داشتیم که نمیخواستم براش جدول جدا بذارم
        public byte ArtworkType { get; set; } // ArtworkTypeConstants.cs
        public string? Director { get; set; }
        public string? PosterFile { get; set; }
        public string? TrailerLink { get; set; }
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
                    ArtworkType = x.ArtworkType,
                    Director = x.Director,
                    PosterFile = x.PosterFile,
                    TrailerLink = x.TrailerLink
                }).FirstOrDefault();

            return result;
        }
    }
}
