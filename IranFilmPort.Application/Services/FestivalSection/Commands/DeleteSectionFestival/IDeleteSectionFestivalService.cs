using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using System.Net;

namespace IranFilmPort.Application.Services.FestivalSection.Commands.DeleteSectionFestival
{
    public class RequestDeleteSectionFestivalServiceDto
    {
        public Guid Id { get; set; }
    }
    public interface IDeleteSectionFestivalService
    {
        ResultDto Execute(RequestDeleteSectionFestivalServiceDto req);
    }
    public class DeleteSectionFestivalService : IDeleteSectionFestivalService
    {
        private readonly IDataBaseContext _context;
        public DeleteSectionFestivalService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteSectionFestivalServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty) return new ResultDto { IsSuccess = false };
            var section = _context.FestivalSections.FirstOrDefault(x => x.Id == req.Id);
            if (section == null) return new ResultDto { IsSuccess = false };
            section.DeleteDateTime = DateTime.Now;
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
