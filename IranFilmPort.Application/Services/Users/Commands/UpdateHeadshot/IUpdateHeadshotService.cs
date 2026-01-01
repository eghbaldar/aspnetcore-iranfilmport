using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using IranFilmPort.Common.Constants;
using Microsoft.AspNetCore.Http;

namespace IranFilmPort.Application.Services.Users.Commands.UpdateHeadshot
{
    public class RequestUpdateHeadshotServiceDto
    {
        public Guid UserId { get; set; }
        public IFormFile? HeadshotFile { get; set; }
    }
    public interface IUpdateHeadshotService
    {
        ResultDto Execute(RequestUpdateHeadshotServiceDto req);
    }
    public class UpdateHeadshotService : IUpdateHeadshotService
    {
        private readonly IDataBaseContext _context;
        public UpdateHeadshotService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateHeadshotServiceDto req)
        {
            if (req == null ||
                req.UserId == Guid.Empty ||
                req.HeadshotFile == null
                )
                return new ResultDto { IsSuccess = false };

            var user = _context.Users
                .FirstOrDefault(x => x.Id == req.UserId);
            if (user == null) return new ResultDto { IsSuccess = false };

            // upload the main photo

            if (req.HeadshotFile != null)
            {
                var file = CreateFilename(req.HeadshotFile, false);
                switch (file.IsSuccess)
                {
                    case true:
                        user.Headshot = file.Filename;
                        user.HeadshotStatus = StatusConstants.UnderConsideration;
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
                DirectoryNameLevelChild = "user-headshot",
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
