using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Festival
{
    public class Festivals : BaseEntity
    {
        public int UniqueCode { get; set; }
        public byte Level { get; set; } // FestivalLevels.cs
        public string Genres { get; set; } // value => "1,2,3"
        public byte ShortFeature { get; set; } // FestivalShortFeatureConstants.cs
        public string TitleEn { get; set; }
        public string TitleFa { get; set; }
        public string Address { get; set; }
        public byte CountryCode { get; set; } // CountryCode.cs
        public DateTime OpeningDate { get; set; }
        public DateTime NotificationDate { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string Website { get; set; }
        public string Detail { get; set; }
        public string Attribute { get; set; }
        public string Logo { get; set; }
        public byte Premiere { get; set; } // FestivalPremiereConstants.cs
        public string Rules { get; set; }
        public byte Platform { get; set; } // FestivalPlatformConstants.cs
        public string Submitway { get; set; }
        public bool Active { get; set; }
        public int Visit { get; set; }
        public ICollection<FestivalSections> FestivalSections { get; set; }
    }
}
