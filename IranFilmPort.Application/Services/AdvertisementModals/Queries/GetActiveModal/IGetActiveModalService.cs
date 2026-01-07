using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.AdvertisementModals.Queries.GetActiveModal
{
    public class GetActiveModalServiceDto
    {
        public string Title { get; set; }
        public string BlinkText { get; set; }
        public string SubText1 { get; set; }
        public string LinkSubText1 { get; set; }
        public string SubText2 { get; set; }
        public string LinkSubText2 { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }
    }
   public interface IGetActiveModalService
    {
        GetActiveModalServiceDto Execute();
    }
    public class GetActiveModalService : IGetActiveModalService
    {
        private readonly IDataBaseContext _context;
        public GetActiveModalService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetActiveModalServiceDto Execute()
        {
            return _context.AdvertisementModals
                .Where(x => x.Active)
                .Select(x => new GetActiveModalServiceDto
                {
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
