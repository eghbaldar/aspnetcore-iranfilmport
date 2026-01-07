using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Pages.Commands.UpdatePageBySelector;
using IranFilmPort.Application.Services.Pages.Queries.GetPageBySelector;

namespace IranFilmPort.Application.Services.Pages.FacadePattern
{
    public class PagesFacadePattern : IPagesFacadePattern
    {
        private readonly IDataBaseContext _context;
        public PagesFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        //UpdatePageBySelectorService
        public UpdatePageBySelectorService _updatePageBySelectorService;
        public UpdatePageBySelectorService UpdatePageBySelectorService
        {
            get { return _updatePageBySelectorService = _updatePageBySelectorService ?? new UpdatePageBySelectorService(_context); }
        }
        //GetPageBySelectorService
        public GetPageBySelectorService _getPageBySelectorService;
        public GetPageBySelectorService GetPageBySelectorService
        {
            get { return _getPageBySelectorService = _getPageBySelectorService ?? new GetPageBySelectorService(_context); }
        }
    }
}
