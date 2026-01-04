using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using IranFilmPort.Common.Constants;
using Microsoft.AspNetCore.Http;

namespace IranFilmPort.Application.Services.UserProjectPhotos.Commands.PostUserProjectPhoto
{
    public class RequestPostUserProjectPhotoServiceDto
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; } // derived from UserProjects.cs
        public IFormFile File { get; set; }
        public byte Type { get; set; } // UserProjectPhotoTypes.cs
    }
    public interface IPostUserProjectPhotoService
    {
        ResultDto Execute(RequestPostUserProjectPhotoServiceDto req);
    }
    public class PostUserProjectPhotoService : IPostUserProjectPhotoService
    {
        private readonly IDataBaseContext _context;
        public PostUserProjectPhotoService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostUserProjectPhotoServiceDto req)
        {
            // check dto
            if (req == null || req.ProjectId == Guid.Empty || req.File == null) return new ResultDto { IsSuccess = false };
            // check project
            var project = _context.UserProjects.FirstOrDefault(x => x.Id == req.ProjectId && x.UserId == req.UserId);
            if (project == null) return new ResultDto { IsSuccess = false };
            // check the valid numbers
            var projectphotos = _context.UserProjectPhotos
                .Where(x => x.ProjectId == req.ProjectId);
            if (req.Type == UserProjectPhotoTypes.Poster)
            {
                var poster = projectphotos.Any(x => x.Type == UserProjectPhotoTypes.Poster);
                if (poster)
                {
                    return new ResultDto { IsSuccess = false, Message = "پوستر/کاور پیش از این ارسال شده است." };
                }
            }
            else if (req.Type == UserProjectPhotoTypes.Backstage)
            {
                var backstages = projectphotos.Count(x => x.Type == UserProjectPhotoTypes.Backstage);
                if (backstages == 5)
                {
                    return new ResultDto { IsSuccess = false, Message = "ماکسیسم تعداد تصاویر پشت صحنه 5 عدد می باشد." };
                }
            }
            else if (req.Type == UserProjectPhotoTypes.Scene)
            {
                var scenes = projectphotos.Count(x => x.Type == UserProjectPhotoTypes.Scene);
                if (scenes == 5)
                {
                    return new ResultDto { IsSuccess = false, Message = "ماکسیسم تعداد تصاویر صحنه 5 عدد می باشد." };
                }
            }
            // add into entity
            IranFilmPort.Domain.Entities.UserProjects.UserProjectPhotos
                 userProjectPhotos = new Domain.Entities.UserProjects.UserProjectPhotos()
                 {
                     ProjectId = req.ProjectId,
                     Status = StatusConstants.UnderConsideration,
                     Type = req.Type,
                 };
            var file = CreateFilename(req.File, false);
            switch (file.IsSuccess)
            {
                case true:
                    userProjectPhotos.File = file.Filename;
                    break;
                case false:
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = file.Message,
                    };
            }
            _context.UserProjectPhotos.Add(userProjectPhotos);
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
                DirectoryROOT = "users",
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "user-project-images",
                Extension = new string[] { ".webp" },
                FileSize = (AllowedOver150) ? "1600000" : "160000",
                File = file,
                Scales = new Dictionary<string, string>
                {
                    {"original","1500"},
                    {"thumbnail","800"}
                }
            });
            return filename;
        }
    }
}
