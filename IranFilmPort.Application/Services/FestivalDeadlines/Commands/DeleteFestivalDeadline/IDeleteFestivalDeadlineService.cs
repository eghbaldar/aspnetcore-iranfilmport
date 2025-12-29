using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.FestivalDeadlines.Commands.DeleteFestivalDeadline
{
    public class RequestDeleteFestivalDeadlineServiceDto
    {
        public Guid Id { get; set; }
    }
    public interface IDeleteFestivalDeadlineService
    {
        ResultDto Execute(RequestDeleteFestivalDeadlineServiceDto req);
    }
    public class DeleteFestivalDeadlineService : IDeleteFestivalDeadlineService
    {
        private readonly IDataBaseContext _context;
        public DeleteFestivalDeadlineService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteFestivalDeadlineServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty) return new ResultDto { IsSuccess = false };
            var deadline = _context.FestivalDeadlines.FirstOrDefault(x => x.Id == req.Id);
            if (deadline == null) return new ResultDto { IsSuccess = false };
            deadline.DeleteDateTime = DateTime.Now;
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
