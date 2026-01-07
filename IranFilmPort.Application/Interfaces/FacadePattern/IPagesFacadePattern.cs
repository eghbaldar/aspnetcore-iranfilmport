using IranFilmPort.Application.Services.Pages.Commands.UpdatePageBySelector;
using IranFilmPort.Application.Services.Pages.Queries.GetPageBySelector;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IPagesFacadePattern
    {
        public UpdatePageBySelectorService UpdatePageBySelectorService { get;}
        public GetPageBySelectorService GetPageBySelectorService { get;}
    }
}
