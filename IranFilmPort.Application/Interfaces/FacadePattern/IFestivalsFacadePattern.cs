using IranFilmPort.Application.Services.Festivals.Commands.PostFestival;
using IranFilmPort.Application.Services.Festivals.Commands.UpdateFestival;
using IranFilmPort.Application.Services.Festivals.Queries.GetAllFestivalsForAdminService;
using IranFilmPort.Application.Services.Festivals.Queries.GetFestival;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IFestivalsFacadePattern
    {
        public GetFestivalService GetFestivalService { get; }
        public GetAllFestivalsForAdminService GetAllFestivalsForAdminService { get; }
        public PostFestivalService PostFestivalService { get; }
        public UpdateFestivalService UpdateFestivalService { get; }
    }
}
