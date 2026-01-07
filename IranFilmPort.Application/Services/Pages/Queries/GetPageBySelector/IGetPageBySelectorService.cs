using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.Pages.Queries.GetPageBySelector
{
    public class GetPageBySelectorServiceDto
    {
        public string? Value { get; set; }
        public string? ValueEn { get; set; }
    }
    public interface IGetPageBySelectorService
    {
        GetPageBySelectorServiceDto Execute(byte Selector);
    }
    public class GetPageBySelectorService : IGetPageBySelectorService
    {
        private readonly IDataBaseContext _context;
        public GetPageBySelectorService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetPageBySelectorServiceDto Execute(byte selector)
        {
            var _page = _context.Pages.FirstOrDefault();
            if (_page == null) return null;
            switch (selector)
            {
                case PageSelectorConstants.Resume:
                    return new GetPageBySelectorServiceDto { Value = _page.ResumeFa, ValueEn = _page.ResumeEn };
                case PageSelectorConstants.Advertisements:
                    return new GetPageBySelectorServiceDto { Value = _page.Advertisements };
                case PageSelectorConstants.ParticipatePlan:
                    return new GetPageBySelectorServiceDto { Value = _page.ParticipatePlan };
                case PageSelectorConstants.About:
                    return new GetPageBySelectorServiceDto { Value = _page.AboutFa, ValueEn = _page.AboutEn };
                case PageSelectorConstants.Agents:
                    return new GetPageBySelectorServiceDto { Value = _page.AgentsFa, ValueEn = _page.AgentsEn };
                case PageSelectorConstants.Script:
                    return new GetPageBySelectorServiceDto { Value = _page.ScriptFa };
                case PageSelectorConstants.Features:
                    return new GetPageBySelectorServiceDto { Value = _page.Features };
                default:
                    return null;
            }
        }
    }
}
