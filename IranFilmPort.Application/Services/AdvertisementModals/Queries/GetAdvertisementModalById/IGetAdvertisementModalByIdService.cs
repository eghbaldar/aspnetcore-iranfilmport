using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.AdvertisementModals.Queries.GetAdvertisementModalById
{
    public class RequestGetAdvertisementModalByIdServiceDto
    {
        public Guid Id { get; set; }
    }
    public class GetAdvertisementModalByIdServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BlinkText { get; set; }
        public string SubText1 { get; set; }
        public string LinkSubText1 { get; set; }
        public string SubText2 { get; set; }
        public string LinkSubText2 { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }
    }
    public interface IGetAdvertisementModalByIdService
    {
        GetAdvertisementModalByIdServiceDto Execute(RequestGetAdvertisementModalByIdServiceDto req);
    }
    public class GetAdvertisementModalByIdService : IGetAdvertisementModalByIdService
    {
        private readonly IDataBaseContext _context;
        public GetAdvertisementModalByIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetAdvertisementModalByIdServiceDto Execute(RequestGetAdvertisementModalByIdServiceDto req)
        {
            return _context.AdvertisementModals
                .Where(x => x.Id == req.Id)
                .Select(x => new GetAdvertisementModalByIdServiceDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    BlinkText = x.BlinkText,
                    Color = x.Color,
                    LinkSubText1 = x.LinkSubText1,
                    LinkSubText2 = x.LinkSubText2,
                    Photo = x.Photo,
                    SubText1 = x.SubText1,
                    SubText2 = x.SubText2,
                })
                .FirstOrDefault();
        }
    }
}
