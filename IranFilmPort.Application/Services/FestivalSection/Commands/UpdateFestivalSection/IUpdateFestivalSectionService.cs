using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using System.Net;

namespace IranFilmPort.Application.Services.FestivalSection.Commands.UpdateFestivalSection
{
    public class RequestUpdateFestivalSectionServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
    public interface IUpdateFestivalSectionService
    {
        ResultDto Execute(RequestUpdateFestivalSectionServiceDto req);
    }
    public class UpdateFestivalSectionService : IUpdateFestivalSectionService
    {
        private readonly IDataBaseContext _context;
        public UpdateFestivalSectionService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateFestivalSectionServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty || string.IsNullOrEmpty(req.Title)) return new ResultDto { IsSuccess = false };
            var section = _context.FestivalSections.FirstOrDefault(x => x.Id == req.Id);
            if (section == null) return new ResultDto { IsSuccess = false };
            section.Title = WebUtility.HtmlDecode(req.Title.Trim());
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
