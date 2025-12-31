using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Countries
{
    public class Countries:BaseEntity
    {
        public byte CountryCode { get; set; }
        public string NameFa { get; set; }
        public string NameEn { get; set; }
    }
}
