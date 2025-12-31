using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Festivals.Commands.PostFestival
{
    public class RequestPostFestivalServiceDto
    {
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
        public IFormFile Logo { get; set; }
        public bool AllowedOver150 { get; set; }
        public byte Premiere { get; set; } // FestivalPremiereConstants.cs
        public string Rules { get; set; }
        public byte Platform { get; set; } // FestivalPlatformConstants.cs
        public string Submitway { get; set; }
        public bool Active { get; set; }
        public int Visit { get; set; }
    }
    public interface IPostFestivalService
    {
        ResultDto Execute(RequestPostFestivalServiceDto req);
    }
    public class PostFestivalService : IPostFestivalService
    {
        private readonly IDataBaseContext _context;
        public PostFestivalService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostFestivalServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.TitleEn) ||
                string.IsNullOrEmpty(req.TitleFa) ||
                string.IsNullOrEmpty(req.Genres) ||
                string.IsNullOrEmpty(req.Detail) ||
                req.Logo == null ||
                string.IsNullOrEmpty(req.Rules) ||
                string.IsNullOrEmpty(req.Website)
                )
            {
                return new ResultDto { IsSuccess = false };
            }
            // generate slug & unique code
            int UNIQUECODE = EnsureUniqueCode(GenerateRandomLongValue());
            if (UNIQUECODE == 0) return new ResultDto { IsSuccess = false };
            // entity
            IranFilmPort.Domain.Entities.Festival.Festivals festival =
                new Domain.Entities.Festival.Festivals()
                {
                    UniqueCode = UNIQUECODE,
                    Website = WebUtility.HtmlDecode(req.Website.Trim()),
                    Rules = WebUtility.HtmlDecode(req.Rules.Trim()),
                    NotificationDate = req.NotificationDate,
                    OpeningDate = req.OpeningDate,
                    Platform = req.Platform,
                    Active = req.Active,
                    Address = WebUtility.HtmlDecode(req.Address.Trim()),
                    Attribute = WebUtility.HtmlDecode(req.Attribute.Trim()),
                    Detail = WebUtility.HtmlDecode(req.Detail.Trim()),
                    EventEndDate = req.EventEndDate,
                    Genres = req.Genres,
                    Level = req.Level,
                    CountryCode = req.CountryCode,
                    EventStartDate = req.EventStartDate,
                    Submitway = WebUtility.HtmlDecode(req.Submitway.Trim()),
                    TitleEn = WebUtility.HtmlDecode(req.TitleEn.Trim()),
                    TitleFa = WebUtility.HtmlDecode(req.TitleFa.Trim()),
                    ShortFeature = req.ShortFeature,
                    Premiere = req.Premiere,
                };

            // upload the main photo
            var file = CreateFilename(req.Logo, req.AllowedOver150);
            switch (file.IsSuccess)
            {
                case true:
                    festival.Logo = file.Filename;
                    break;
                case false:
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = file.Message,
                    };
            }
            _context.Festivals.Add(festival);
            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
        private static int GenerateRandomLongValue()
        {
            Random random = new Random();
            int len = random.Next(3, 11);
            const string characters = "0123456789";
            string randomString = new string(Enumerable.Range(0, len)
                .Select(_ => characters[random.Next(characters.Length)])
                .ToArray());
            return Convert.ToInt32(randomString);
        }
        private int EnsureUniqueCode(int baseUniqueCode)
        {
            int counter = 1;
            while (_context.Festivals.Any(x => x.UniqueCode == baseUniqueCode))
            {
                baseUniqueCode = GenerateRandomLongValue();
            }
            return baseUniqueCode;
        }
        private ResultUploadDto CreateFilename(IFormFile file, bool AllowedOver150)
        {
            UploadFileService uploadFileService = new UploadFileService();
            var filename = uploadFileService.UploadFile(new RequestUploadFileServiceDto
            {
                Type = false,
                DirectoryROOT = "admin",
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "admin-festival-images",
                Extension = new string[] { ".webp" },
                FileSize = (AllowedOver150) ? "1600000" : "160000",
                File = file,
                Scales = new Dictionary<string, string>
                {
                    {"original","1500"},
                    {"thumbnail","500"}
                }
            });
            return filename;
        }
    }
}
