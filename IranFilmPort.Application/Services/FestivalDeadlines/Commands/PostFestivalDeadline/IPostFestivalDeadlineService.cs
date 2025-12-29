using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.FestivalDeadlines.Commands.PostFestivalDeadline
{
    public class RequestPostFestivalDeadlineServiceDto
    {
        public Guid FestivalSectionId { get; set; }
        public DateTime Deadline { get; set; }
        public string Fee { get; set; }
    }
    public interface IPostFestivalDeadlineService
    {
        ResultDto Execute(RequestPostFestivalDeadlineServiceDto req);
    }
    public class PostFestivalDeadlineService : IPostFestivalDeadlineService
    {
        private readonly IDataBaseContext _context;
        public PostFestivalDeadlineService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostFestivalDeadlineServiceDto req)
        {
            if (req == null || string.IsNullOrEmpty(req.Fee) ||
                req.FestivalSectionId == Guid.Empty
                ) return new ResultDto { IsSuccess = false };
            IranFilmPort.Domain.Entities.Festival.FestivalDeadlines festivalDeadlines =
                            new Domain.Entities.Festival.FestivalDeadlines()
                            {
                                FestivalSectionId = req.FestivalSectionId,
                                Deadline = req.Deadline,
                                Fee = req.Fee.Trim(),
                            };
            _context.FestivalDeadlines.Add(festivalDeadlines);
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
