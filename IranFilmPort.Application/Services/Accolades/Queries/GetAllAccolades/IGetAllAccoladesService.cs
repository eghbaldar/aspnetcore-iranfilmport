using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePatternDapper;
using IranFilmPort.Common.Helpers;
using IranFilmPort.Domain.Entities.User;

namespace IranFilmPort.Application.Services.Accolades.Queries.GetAllAccolades
{
    public class RequestGetAllAccoladesServiceDto
    {
        public int CurrentPage { get; set; } // current page
    }
    public class GetAllAccoladesServiceDto
    {
        public Guid Id { get; set; }
        public long FilmId { get; set; }
        public string FilmTitle { get; set; }
        public string AccoladeFa { get; set; }
        public string? AccoladeEn { get; set; }
        public int Priority { get; set; }
    }
    public class ResutlGetAllAccoladesServiceDto
    {
        public List<GetAllAccoladesServiceDto> Result { get; set; }
        public int RowCount { get; set; }//  <---- pagination
        public int RowsOnEachPage { get; set; }//  <---- pagination
    }
    public interface IGetAllAccoladesService
    {
        ResutlGetAllAccoladesServiceDto Execute(RequestGetAllAccoladesServiceDto req);
    }
    public class GetAllAccoladesService : IGetAllAccoladesService
    {
        private readonly IDataBaseContext _context;
        private readonly IFilmFacadePatternDapper _filmFacadePatternDapper;
        public GetAllAccoladesService(IDataBaseContext context, IFilmFacadePatternDapper filmFacadePatternDapper)
        {
            _context = context;
            _filmFacadePatternDapper = filmFacadePatternDapper;
        }
        public ResutlGetAllAccoladesServiceDto Execute(RequestGetAllAccoladesServiceDto req)
        {
            int RowsCount; //<------ pagination
            int RowsOnEachPage = 50; //<------ pagination

            var saveInMemory = _context.Accolades
                .Select(x => new GetAllAccoladesServiceDto
                {
                    AccoladeEn = x.AccoladeEn,
                    AccoladeFa = x.AccoladeFa,
                    FilmId = x.FilmId,
                    Id = x.Id,
                    Priority = x.Priority,
                    FilmTitle = _filmFacadePatternDapper.GetFilmByIdServiceDapper.Execute(new ServicesDapper.Films.Queries.GetFilmById.RequestGetFilmByIdServiceDapperDto
                    {
                        Id = x.FilmId
                    }).Result.FullTitle
                })
                .ToPaged(req.CurrentPage, RowsOnEachPage, out RowsCount) //  <----  pagination
                .OrderByDescending(x => x.Priority);

            var result = saveInMemory.ToList();

            return new ResutlGetAllAccoladesServiceDto
            {
                Result = result,
                RowCount = RowsCount, //  <---- pagination
                RowsOnEachPage = RowsOnEachPage, //  <---- pagination
            };
        }
    }
}
