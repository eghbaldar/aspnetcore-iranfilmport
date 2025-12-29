using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using System.Net;

namespace IranFilmPort.Application.Services.FestivalSection.Commands.PostFestivalSection
{
    public class RequestPostFestivalSectionServiceDto
    {
        public Guid FestivalId { get; set; }
        public string Title { get; set; }
    }
    public interface IPostFestivalSectionService
    {
        ResultDto Execute(RequestPostFestivalSectionServiceDto req);
    }
    public class PostFestivalSectionService : IPostFestivalSectionService
    {
        private readonly IDataBaseContext _context;
        public PostFestivalSectionService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostFestivalSectionServiceDto req)
        {
            if (req == null || string.IsNullOrEmpty(req.Title) || req.FestivalId == Guid.Empty) return new ResultDto { IsSuccess = false };
            IranFilmPort.Domain.Entities.Festival.FestivalSections festivalSection =
                            new Domain.Entities.Festival.FestivalSections()
                            {
                                FestivalId = req.FestivalId,
                                Title = WebUtility.HtmlDecode(req.Title.Trim()),
                            };
            _context.FestivalSections.Add(festivalSection);
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
