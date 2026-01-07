using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.Pages.Commands.UpdatePageBySelector
{
    public class RequestUpdatePageBySelectorServiceDto
    {
        public byte Selector { get; set; }
        public string Value { get; set; }
        public string? ValueEn { get; set; }
    }
    public interface IUpdatePageBySelectorService
    {
        ResultDto Execute(RequestUpdatePageBySelectorServiceDto req);
    }
    public class UpdatePageBySelectorService : IUpdatePageBySelectorService
    {
        private readonly IDataBaseContext _context;
        public UpdatePageBySelectorService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdatePageBySelectorServiceDto req)
        {
            var _page = _context.Pages.FirstOrDefault();
            if (_page == null)
            {
                IranFilmPort.Domain.Entities.Settings.Pages page = new Domain.Entities.Settings.Pages();
                switch (req.Selector)
                {
                    case PageSelectorConstants.Resume:
                        page.ResumeFa = req.Value;
                        page.ResumeEn = req.ValueEn;
                        break;
                    case PageSelectorConstants.Advertisements:
                        page.Advertisements = req.Value;
                        break;
                    case PageSelectorConstants.ParticipatePlan:
                        page.ParticipatePlan = req.Value;
                        break;
                    case PageSelectorConstants.About:
                        page.AboutFa = req.Value;
                        page.AboutEn = req.ValueEn;
                        break;
                    case PageSelectorConstants.Agents:
                        page.AgentsFa = req.Value;
                        page.AgentsEn = req.ValueEn;
                        break;
                    case PageSelectorConstants.Script:
                        page.ScriptFa = req.Value;
                        break;
                    case PageSelectorConstants.Features:
                        page.Features = req.Value;
                        break;
                }
                _context.Pages.Add(page);
                var output = _context.SaveChanges();
                if (output >= 0)
                    return new ResultDto { IsSuccess = true };
                else return new ResultDto { IsSuccess = false };
            }
            else
            {
                switch (req.Selector)
                {
                    case PageSelectorConstants.Resume:
                        _page.ResumeFa = req.Value;
                        _page.ResumeEn = req.ValueEn;
                        break;
                    case PageSelectorConstants.Advertisements:
                        _page.Advertisements = req.Value;
                        break;
                    case PageSelectorConstants.ParticipatePlan:
                        _page.ParticipatePlan = req.Value;
                        break;
                    case PageSelectorConstants.About:
                        _page.AboutFa = req.Value;
                        _page.AboutEn = req.ValueEn;
                        break;
                    case PageSelectorConstants.Agents:
                        _page.AgentsFa = req.Value;
                        _page.AgentsEn = req.ValueEn;
                        break;
                    case PageSelectorConstants.Script:
                        _page.ScriptFa = req.Value;
                        break;
                    case PageSelectorConstants.Features:
                        _page.Features = req.Value;
                        break;
                }
                var output = _context.SaveChanges();
                if (output >= 0)
                    return new ResultDto { IsSuccess = true };
                else return new ResultDto { IsSuccess = false };

            }
        }
    }
}