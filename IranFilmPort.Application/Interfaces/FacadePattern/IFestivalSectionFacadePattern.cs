using IranFilmPort.Application.Services.FestivalSection.Commands.DeleteSectionFestival;
using IranFilmPort.Application.Services.FestivalSection.Commands.PostFestivalSection;
using IranFilmPort.Application.Services.FestivalSection.Commands.UpdateFestivalSection;
using IranFilmPort.Application.Services.FestivalSection.Queries.GetSectionsByFestivalId;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IFestivalSectionFacadePattern
    {
        public DeleteSectionFestivalService DeleteSectionFestivalService { get; }
        public UpdateFestivalSectionService UpdateFestivalSectionService { get; }
        public PostFestivalSectionService PostFestivalSectionService { get; }
        public GetSectionsByFestivalIdService GetSectionsByFestivalIdService { get; }
    }
}
