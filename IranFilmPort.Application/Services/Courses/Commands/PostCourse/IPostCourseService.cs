using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Courses.Commands.PostCourse
{
    public class RequestPostCourseServiceDto
    {
        public string Title { get; set; }
        public string Teacher { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile TeacherHeadshot { get; set; }
        public string Detail { get; set; }
    }
    public interface IPostCourseService
    {
        ResultDto Execute(RequestPostCourseServiceDto req);
    }
    public class PostCourseService : IPostCourseService
    {
        private readonly IDataBaseContext _context;
        public PostCourseService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostCourseServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Title) ||
                string.IsNullOrEmpty(req.Teacher) ||
                string.IsNullOrEmpty(req.Detail) ||
                req.Image == null ||
                req.TeacherHeadshot == null
                )
            { return new ResultDto { IsSuccess = false }; }

            IranFilmPort.Domain.Entities.Courses.Courses courses
                = new IranFilmPort.Domain.Entities.Courses.Courses()
                {
                    Detail = req.Detail,
                    Teacher = WebUtility.HtmlDecode(req.Teacher),
                    Title = WebUtility.HtmlDecode(req.Title),
                };

            var image = CreateFilename(req.Image, false);
            switch (image.IsSuccess)
            {
                case true:
                    courses.Image = image.Filename;
                    break;
                case false:
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = image.Message,
                    };
            }
            var teacherheadshot = CreateFilename(req.TeacherHeadshot, false);
            switch (teacherheadshot.IsSuccess)
            {
                case true:
                    courses.TeacherHeadshot = teacherheadshot.Filename;
                    break;
                case false:
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = teacherheadshot.Message,
                    };
            }
            // set into database

            _context.Courses.Add(courses);
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
                DirectoryNameLevelChild = "admin-teacher-images",
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
