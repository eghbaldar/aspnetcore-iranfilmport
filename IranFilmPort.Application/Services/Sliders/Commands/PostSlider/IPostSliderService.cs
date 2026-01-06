using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Sliders.Commands.PostSlider
{
    public class RequestPostSliderServiceDto
    {
        public IFormFile File { get; set; }
        public string Text { get; set; }
        public string TextEn { get; set; }
        public string SubText { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
    }
    public interface IPostSliderService
    {
        ResultDto Execute(RequestPostSliderServiceDto req);
    }
    public class PostSliderService : IPostSliderService
    {
        private readonly IDataBaseContext _context;
        public PostSliderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostSliderServiceDto req)
        {
            if (req == null || 
                string.IsNullOrEmpty(req.Text) ||
                string.IsNullOrEmpty(req.TextEn) ||
                string.IsNullOrEmpty(req.Link) ||
                req.File == null
                ) 
            { return new ResultDto { IsSuccess = false }; }

            IranFilmPort.Domain.Entities.Sliders.Sliders sliders
                = new IranFilmPort.Domain.Entities.Sliders.Sliders()
                {
                    Active = req.Active,
                    Link = WebUtility.HtmlDecode(req.Link),
                    SubText = WebUtility.HtmlDecode(req.SubText),
                    Text = WebUtility.HtmlDecode(req.Text),
                    TextEn = WebUtility.HtmlDecode(req.TextEn),                    
                };

            var file = CreateFilename(req.File, false);
            switch (file.IsSuccess)
            {
                case true:
                    sliders.File = file.Filename;
                    break;
                case false:
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = file.Message,
                    };
            }
            // set into database

            _context.Sliders.Add(sliders);
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
                DirectoryNameLevelChild = "admin-slider-images",
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
