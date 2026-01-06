using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Testimonials
{
    public class Testimonials : BaseEntity
    {
        public string Name { get; set; }
        public string File { get; set; }
        public bool Type { get; set; } // false: image true:audio
    }
}
