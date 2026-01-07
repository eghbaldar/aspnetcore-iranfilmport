using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.AdvertisementModals.Commands.UpdateActiveModal
{
    public class RequestUpdateActiveModalServiceDto
    {
        public Guid Id { get; set; }
    }
    public interface IUpdateActiveModalService
    {
        ResultDto Execute(RequestUpdateActiveModalServiceDto req);
    }
    public class UpdateActiveModalService : IUpdateActiveModalService
    {
        private readonly IDataBaseContext _context;
        public UpdateActiveModalService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateActiveModalServiceDto req)
        {
            // deactivate all ADVs
            var advModals = _context.AdvertisementModals.ToList();
            foreach (var ad in advModals) { ad.Active = false; }
            _context.SaveChanges();
            // active a modal
            var advModal = _context.AdvertisementModals.FirstOrDefault(x => x.Id == req.Id);
            if (advModal == null) return new ResultDto { IsSuccess = false };
            advModal.Active = true;

            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
