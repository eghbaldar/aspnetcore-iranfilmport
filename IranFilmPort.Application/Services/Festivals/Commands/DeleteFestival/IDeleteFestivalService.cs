using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Festivals.Commands.DeleteFestival
{
    public class RequestDeleteFestivalServiceDto
    {
        public Guid Id { get; set; }
    }
    public interface IDeleteFestivalService
    {
        ResultDto Execute(RequestDeleteFestivalServiceDto req);
    }
    public class DeleteFestivalService : IDeleteFestivalService
    {
        private readonly IDataBaseContext _context;
        public DeleteFestivalService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteFestivalServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty) return new ResultDto { IsSuccess = false };
            var festival = _context.Festivals.FirstOrDefault(x => x.Id == req.Id);
            if (festival == null) return new ResultDto { IsSuccess = false };
            festival.DeleteDateTime = DateTime.Now;
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
