using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Courses.Commands.UpdateCourse
{
    public class RequestUpdateCourseServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Teacher { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? TeacherHeadshot { get; set; }
        public string Detail { get; set; }
    }
    public interface IUpdateCourseService
    {
        ResultDto Execute(RequestUpdateCourseServiceDto req);
    }
    public class UpdateCourseService : IUpdateCourseService
    {
        private readonly IDataBaseContext _context;
        public UpdateCourseService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateCourseServiceDto req)
        {
            if (req == null ||
                req.Id == Guid.Empty ||
                string.IsNullOrEmpty(req.Title) ||
                string.IsNullOrEmpty(req.Teacher) ||
                string.IsNullOrEmpty(req.Detail)
                )
            { return new ResultDto { IsSuccess = false }; }

            var course = _context.Courses.FirstOrDefault(x => x.Id == req.Id);
            if (course == null) return new ResultDto { IsSuccess = false };

            course.Title = WebUtility.HtmlDecode(req.Title);
            course.Teacher = WebUtility.HtmlDecode(req.Teacher);
            course.Detail = req.Detail;            

            if (req.Image != null)
            {
                var _course = CreateFilename(req.Image, false);
                switch (_course.IsSuccess)
                {
                    case true:
                        course.Image = _course.Filename;
                        break;
                    case false:
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = _course.Message,
                        };
                }
            }
            if (req.TeacherHeadshot != null)
            {
                var _teacherHeadshot = CreateFilename(req.TeacherHeadshot, false);
                switch (_teacherHeadshot.IsSuccess)
                {
                    case true:
                        course.TeacherHeadshot = _teacherHeadshot.Filename;
                        break;
                    case false:
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = _teacherHeadshot.Message,
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
