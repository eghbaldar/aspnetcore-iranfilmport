using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using System.Net;

namespace IranFilmPort.Application.Services.FestivalDeadlines.Commands.UpdateFestivalDeadline
{
    public class RequestUpdateFestivalDeadlineServiceDto
    {
        public Guid Id { get; set; }
        public DateTime Deadline { get; set; }
        public string Fee { get; set; }
    }
    public interface IUpdateFestivalDeadlineService
    {
        ResultDto Execute(RequestUpdateFestivalDeadlineServiceDto req);
    }
    public class UpdateFestivalDeadlineService : IUpdateFestivalDeadlineService
    {
        private readonly IDataBaseContext _context;
        public UpdateFestivalDeadlineService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateFestivalDeadlineServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty ||
                string.IsNullOrEmpty(req.Fee)) return new ResultDto { IsSuccess = false };
            var deadline = _context.FestivalDeadlines.FirstOrDefault(x => x.Id == req.Id);
            if (deadline == null) return new ResultDto { IsSuccess = false };
            deadline.Deadline = req.Deadline;
            deadline.Fee = req.Fee.Trim();
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
