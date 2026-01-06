using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Accolades
{
    public class Accolades : BaseEntity
    {
        public long FilmId { get; set; }
        public string AccoladeFa { get; set; }
        public string? AccoladeEn { get; set; }
        public int Priority { get; set; }
    }
}
