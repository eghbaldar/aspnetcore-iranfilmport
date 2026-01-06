using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Sliders
{
    public class Sliders : BaseEntity
    {
        public string File { get; set; }
        public string Text { get; set; }
        public string TextEn { get; set; }
        public string SubText { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
    }
}
