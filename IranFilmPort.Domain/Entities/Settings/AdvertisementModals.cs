using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Settings
{
    public class AdvertisementModals:BaseEntity
    {
        public string Title { get; set; }
        public string BlinkText { get; set; }
        public string SubText1 { get; set; }
        public string LinkSubText1 { get; set; }
        public string SubText2 { get; set; }
        public string LinkSubText2 { get; set; }
        public string Color { get; set; }        
        public string Photo { get; set; }
        public long Visit { get; set; }
        public bool Active { get; set; } // only one record can be activated
    }
}
