using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Testimonals.Commands.PostTestimonal
{
    public class RequestPostTestimonalServiceDto
    {
        public string Name { get; set; }
        public bool Type { get; set; }// false: image true:audio
        public IFormFile File { get; set; }
    }
    public interface IPostTestimonalService
    {
        ResultDto Execute(RequestPostTestimonalServiceDto req);
    }
    public class PostTestimonalService : IPostTestimonalService
    {
        private readonly IDataBaseContext _context;
        public PostTestimonalService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostTestimonalServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Name) ||
                req.File == null
                )
            { return new ResultDto { IsSuccess = false }; }

            IranFilmPort.Domain.Entities.Testimonials.Testimonials testimonial
                = new IranFilmPort.Domain.Entities.Testimonials.Testimonials()
                {
                    Name = WebUtility.HtmlDecode(req.Name),
                    Type = req.Type
                };

            if (req.Type) // false: image true:audio
            {
                var file = CreateFilenameAudio(req.File, false);
                switch (file.IsSuccess)
                {
                    case true:
                        testimonial.File = file.Filename;
                        break;
                    case false:
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = file.Message,
                        };
                }
            }
            else
            {
                var file = CreateFilenameImage(req.File, false);
                switch (file.IsSuccess)
                {
                    case true:
                        testimonial.File = file.Filename;
                        break;
                    case false:
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = file.Message,
                        };
                }
            }

             // set into database
            _context.Testimonials.Add(testimonial);
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
        private ResultUploadDto CreateFilenameAudio(IFormFile file, bool AllowedOver150)
        {
            UploadFileService uploadFileService = new UploadFileService();
            var filename = uploadFileService.UploadFile(new RequestUploadFileServiceDto
            {
                Type = true,
                DirectoryROOT = "admin",
                DirectoryNameLevelParent = "audios",
                DirectoryNameLevelChild = "admin-testimonal-audios",
                Extension = new string[] { ".ogg" },
                FileSize = (AllowedOver150) ? "1600000" : "5000000",
                File = file,
                Scales = new Dictionary<string, string>
                {
                    {"original","1500"},
                }
            });
            return filename;
        }
        private ResultUploadDto CreateFilenameImage(IFormFile file, bool AllowedOver150)
        {
            UploadFileService uploadFileService = new UploadFileService();
            var filename = uploadFileService.UploadFile(new RequestUploadFileServiceDto
            {
                Type = false,
                DirectoryROOT = "admin",
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "admin-testimonal-images",
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
