using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Festivals.Queries.GetFestival
{
    public class RequestGetFestivalServiceDto
    {
        public int UniqueCode { get; set; }
    }
    public class GetFestivalServiceDto
    {
        public Guid Id { get; set; }
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
        public DateTime InsertDate { get; set; }
    }
    public interface IGetFestivalService
    {
        GetFestivalServiceDto Execute(RequestGetFestivalServiceDto req);
    }
    public class GetFestivalService : IGetFestivalService
    {
        private readonly IDataBaseContext _context;
        public GetFestivalService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetFestivalServiceDto Execute(RequestGetFestivalServiceDto req)
        {
            var festivals = _context.Festivals
                .Select(x => new GetFestivalServiceDto
                {
                    UniqueCode = x.UniqueCode,
                    Active = x.Active,
                    Address = x.Address,
                    Attribute = x.Attribute,
                    CountryCode = x.CountryCode,
                    Detail = x.Detail,
                    EventEndDate = x.EventEndDate,
                    EventStartDate = x.EventStartDate,
                    Genres = x.Genres,
                    Id = x.Id,
                    InsertDate = x.InsertDateTime,
                    Level = x.Level,
                    Logo = x.Logo,
                    NotificationDate = x.NotificationDate,
                    OpeningDate = x.OpeningDate,
                    Platform = x.Platform,
                    Premiere = x.Premiere,
                    Rules = x.Rules,
                    ShortFeature = x.ShortFeature,
                    Submitway = x.Submitway,
                    TitleEn = x.TitleEn,
                    TitleFa = x.TitleFa,
                    Visit = x.Visit,
                    Website = x.Website,
                })
                .Where(x => x.UniqueCode == req.UniqueCode)
                .OrderByDescending(x => x.InsertDate)
                .FirstOrDefault();
            return festivals;
        }
    }
}
