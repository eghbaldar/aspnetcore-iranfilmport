using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Festivals.Commands.UpdateFestival
{
    public class RequestUpdateFestivalServiceDto
    {
        public Guid Id { get; set; }
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
    public interface IUpdateFestivalService
    {
        ResultDto Execute(RequestUpdateFestivalServiceDto req);
    }
    public class UpdateFestivalService : IUpdateFestivalService
    {
        private readonly IDataBaseContext _context;
        public UpdateFestivalService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateFestivalServiceDto req)
        {
            if (req == null ||
                req.Id == Guid.Empty ||
                string.IsNullOrEmpty(req.TitleEn) ||
                string.IsNullOrEmpty(req.TitleFa) ||
                string.IsNullOrEmpty(req.Genres) ||
                string.IsNullOrEmpty(req.Detail) ||
                string.IsNullOrEmpty(req.Rules) ||
                string.IsNullOrEmpty(req.Website)
                )
            {
                return new ResultDto { IsSuccess = false };
            }

            // entity
            var festival = _context.Festivals
                .FirstOrDefault(x => x.Id == req.Id);
            if (festival == null) return new ResultDto { IsSuccess = false };

            // the main image
            if (req.Logo != null)
            {
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
            }

            festival.Active = req.Active;
            festival.Address = WebUtility.HtmlDecode(req.Address.Trim());
            festival.TitleEn = WebUtility.HtmlDecode(req.TitleEn.Trim());
            festival.TitleFa = WebUtility.HtmlDecode(req.TitleFa.Trim());
            festival.Attribute = WebUtility.HtmlDecode(req.Attribute.Trim());
            festival.Rules = WebUtility.HtmlDecode(req.Rules.Trim());
            festival.ShortFeature = req.ShortFeature;
            festival.CountryCode = req.CountryCode;
            festival.Detail = WebUtility.HtmlDecode(req.Detail.Trim());
            festival.EventStartDate = req.EventStartDate;
            festival.EventEndDate = req.EventEndDate;
            festival.Genres = req.Genres;
            festival.OpeningDate = req.OpeningDate;
            festival.NotificationDate = req.NotificationDate;
            festival.Level = req.Level;
            festival.Submitway = WebUtility.HtmlDecode(req.Submitway.Trim());
            festival.Premiere = req.Premiere;
            festival.Platform = req.Platform;
            festival.Website = WebUtility.HtmlDecode(req.Website.Trim());

            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
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
