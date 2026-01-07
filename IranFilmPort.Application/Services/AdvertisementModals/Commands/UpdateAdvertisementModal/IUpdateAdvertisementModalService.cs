using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.AdvertisementModals.Commands.UpdateAdvertisementModal
{
    public class RequestUpdateAdvertisementModalServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BlinkText { get; set; }
        public string SubText1 { get; set; }
        public string LinkSubText1 { get; set; }
        public string SubText2 { get; set; }
        public string LinkSubText2 { get; set; }
        public string Color { get; set; }
        public IFormFile? Photo { get; set; }
        public long Visit { get; set; }
        public bool Active { get; set; } // only one record can be activated
    }
    public interface IUpdateAdvertisementModalService
    {
        ResultDto Execute(RequestUpdateAdvertisementModalServiceDto req);
    }
    public class UpdateAdvertisementModalService : IUpdateAdvertisementModalService
    {
        private readonly IDataBaseContext _context;
        public UpdateAdvertisementModalService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateAdvertisementModalServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Title) ||
                string.IsNullOrEmpty(req.SubText1) ||
                string.IsNullOrEmpty(req.LinkSubText1) ||
                string.IsNullOrEmpty(req.SubText2) ||
                string.IsNullOrEmpty(req.LinkSubText2) ||
                string.IsNullOrEmpty(req.Color) ||
                string.IsNullOrEmpty(req.BlinkText)
                )
            { return new ResultDto { IsSuccess = false }; }

            var advModal = _context.AdvertisementModals.FirstOrDefault(x => x.Id == req.Id);
            if (advModal == null) return new ResultDto { IsSuccess = false };

            advModal.Title = WebUtility.HtmlDecode(req.Title);
            advModal.SubText1 = WebUtility.HtmlDecode(req.SubText1);
            advModal.LinkSubText1 = WebUtility.HtmlDecode(req.LinkSubText1);
            advModal.SubText2 = WebUtility.HtmlDecode(req.SubText2);
            advModal.LinkSubText2 = WebUtility.HtmlDecode(req.LinkSubText2);
            advModal.BlinkText = WebUtility.HtmlDecode(req.BlinkText);
            advModal.Color = WebUtility.HtmlDecode(req.Color);
            advModal.Active = req.Active;

            if (req.Photo != null)
            {
                var _advModal = CreateFilename(req.Photo, false);
                switch (_advModal.IsSuccess)
                {
                    case true:
                        advModal.Photo= _advModal.Filename;
                        break;
                    case false:
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = _advModal.Message,
                        };
                }
            }

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
