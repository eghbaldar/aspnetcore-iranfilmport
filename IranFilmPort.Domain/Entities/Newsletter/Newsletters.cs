using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Newsletter
{
    public class Newsletters : BaseEntity
    {
        public string Email { get; set; }
        public string IP { get; set; }
    }
}
