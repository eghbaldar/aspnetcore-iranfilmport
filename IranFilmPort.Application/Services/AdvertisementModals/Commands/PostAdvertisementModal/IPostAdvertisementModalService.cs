using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.AdvertisementModals.Commands.PostAdvertisementModal
{
    public class RequestPostAdvertisementModalServiceDto
    {
        public string Title { get; set; }
        public string BlinkText { get; set; }
        public string SubText1 { get; set; }
        public string LinkSubText1 { get; set; }
        public string SubText2 { get; set; }
        public string LinkSubText2 { get; set; }
        public string Color { get; set; }
        public IFormFile Photo { get; set; }
        public long Visit { get; set; }
    }
    public interface IPostAdvertisementModalService
    {
        ResultDto Execute(RequestPostAdvertisementModalServiceDto req);
    }
    public class PostAdvertisementModalService : IPostAdvertisementModalService
    {
        private readonly IDataBaseContext _context;
        public PostAdvertisementModalService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostAdvertisementModalServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Title) ||
                string.IsNullOrEmpty(req.SubText1) ||
                string.IsNullOrEmpty(req.LinkSubText1) ||
                string.IsNullOrEmpty(req.SubText2) ||
                string.IsNullOrEmpty(req.LinkSubText2) ||
                string.IsNullOrEmpty(req.Color) ||
                string.IsNullOrEmpty(req.BlinkText) ||
                req.Photo == null
                )
            { return new ResultDto { IsSuccess = false }; }

            IranFilmPort.Domain.Entities.Settings.AdvertisementModals advertisementModals
                = new IranFilmPort.Domain.Entities.Settings.AdvertisementModals()
                {
                    Title = WebUtility.HtmlDecode(req.Title),
                    SubText1 = WebUtility.HtmlDecode(req.SubText1),
                    LinkSubText1 = WebUtility.HtmlDecode(req.LinkSubText1),
                    SubText2 = WebUtility.HtmlDecode(req.SubText2),
                    LinkSubText2 = WebUtility.HtmlDecode(req.LinkSubText2),
                    BlinkText = WebUtility.HtmlDecode(req.BlinkText),
                    Color = WebUtility.HtmlDecode(req.Color),
                    Active = false,
                };

            var image = CreateFilename(req.Photo, false);
            switch (image.IsSuccess)
            {
                case true:
                    advertisementModals.Photo = image.Filename;
                    break;
                case false:
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = image.Message,
                    };
            }
            // set into database

            _context.AdvertisementModals.Add(advertisementModals);
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
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
                DirectoryNameLevelChild = "admin-advModal-images",
                Extension = new string[] { ".webp" },
                FileSize = (AllowedOver150) ? "1600000" : "160000",
                File = file,
                Scales = new Dictionary<string, string>
                {
                    {"original","1500"},
                }
            });
            return filename;
        }
    }
}
