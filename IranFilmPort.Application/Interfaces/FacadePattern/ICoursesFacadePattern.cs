using IranFilmPort.Application.Services.Courses.Commands.PostCourse;
using IranFilmPort.Application.Services.Courses.Commands.UpdateCourse;
using IranFilmPort.Application.Services.Courses.Queries.GetAllCourses;
using IranFilmPort.Application.Services.Courses.Queries.GetCourseById;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface ICoursesFacadePattern
    {
        public PostCourseService PostCourseService { get; }
        public UpdateCourseService UpdateCourseService { get; }
        public GetCourseByIdService GetCourseByIdService { get; }
        public GetAllCoursesService GetAllCoursesService { get; }
    }
}
