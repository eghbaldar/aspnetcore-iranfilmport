using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using IranFilmPort.Common.Constants;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Users.Commands.UpdateMeliCard
{
    public class RequestUpdateMeliCardServiceDto
    {
        public Guid UserId { get; set; }
        public IFormFile? MeliCardFile { get; set; }
    }
    public interface IUpdateMeliCardService
    {
        ResultDto Execute(RequestUpdateMeliCardServiceDto req);
    }
    public class UpdateMeliCardService : IUpdateMeliCardService
    {
        private readonly IDataBaseContext _context;
        public UpdateMeliCardService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateMeliCardServiceDto req)
        {
            if (req == null ||
                req.UserId == Guid.Empty ||
                req.MeliCardFile == null
                )
                return new ResultDto { IsSuccess = false };

            var user = _context.Users
                .FirstOrDefault(x => x.Id == req.UserId);
            if (user == null) return new ResultDto { IsSuccess = false };

            // upload the main photo

            if (req.MeliCardFile != null)
            {
                var file = CreateFilename(req.MeliCardFile, false);
                switch (file.IsSuccess)
                {
                    case true:
                        user.MeliCard = file.Filename;
                        user.MeliCardStatus = StatusConstants.UnderConsideration;
                        break;
                    case false:
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = file.Message,
                        };
                }
            }
           
            // put & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }

        private ResultUploadDto CreateFilename(IFormFile file, bool AllowedOver150)
        {
            UploadFileService uploadFileService = new UploadFileService();
            var filename = uploadFileService.UploadFile(new RequestUploadFileServiceDto
            {
                Type = false,
                DirectoryROOT = "users",
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "user-melicard",
                Extension = new string[] { ".webp", ".png", ".jpg" },
                FileSize = (AllowedOver150) ? "1600000" : "160000",
                File = file,
                Scales = new Dictionary<string, string>
                {
                    {"original","1500"},
                    {"thumb","600"},
                }
            });
            return filename;
        }
    }
}
