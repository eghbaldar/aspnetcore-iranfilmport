using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Sliders.Commands.UpdateSlider
{
    public class RequestUpdateSliderServiceDto
    {
        public Guid Id { get; set; }
        public IFormFile? File { get; set; }
        public string Text { get; set; }
        public string TextEn { get; set; }
        public string SubText { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
    }
    public interface IUpdateSliderService
    {
        ResultDto Execute(RequestUpdateSliderServiceDto req);
    }
    public class UpdateSliderService : IUpdateSliderService
    {
        private readonly IDataBaseContext _context;
        public UpdateSliderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateSliderServiceDto req)
        {
            if (req == null ||
                req.Id == Guid.Empty ||
                string.IsNullOrEmpty(req.Text) ||
                string.IsNullOrEmpty(req.TextEn) ||
                string.IsNullOrEmpty(req.Link)
                )
            { return new ResultDto { IsSuccess = false }; }

            var slider = _context.Sliders.FirstOrDefault(x => x.Id == req.Id);
            if (slider == null) return new ResultDto { IsSuccess = false };

            slider.Active = req.Active;
            slider.Link = WebUtility.HtmlDecode(req.Link);
            slider.SubText = WebUtility.HtmlDecode(req.SubText);
            slider.Text = WebUtility.HtmlDecode(req.Text);
            slider.TextEn = WebUtility.HtmlDecode(req.TextEn);

            if (req.File != null)
            {
                var file = CreateFilename(req.File, false);
                switch (file.IsSuccess)
                {
                    case true:
                        slider.File = file.Filename;
                        break;
                    case false:
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = file.Message,
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
