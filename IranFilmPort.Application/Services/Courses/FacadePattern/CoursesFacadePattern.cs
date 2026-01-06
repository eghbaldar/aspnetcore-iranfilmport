using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Courses.Commands.PostCourse;
using IranFilmPort.Application.Services.Courses.Commands.UpdateCourse;
using IranFilmPort.Application.Services.Courses.Queries.GetAllCourses;
using IranFilmPort.Application.Services.Courses.Queries.GetCourseById;

namespace IranFilmPort.Application.Services.Courses.FacadePattern
{
    public class CoursesFacadePattern: ICoursesFacadePattern
    {
        private readonly IDataBaseContext _context;
        public CoursesFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // PostCourseService
        public PostCourseService _postCourseService;
        public PostCourseService PostCourseService
        {
            get { return _postCourseService = _postCourseService ?? new PostCourseService(_context); }
        }
        // UpdateCourseService
        public UpdateCourseService _updateCourseService;
        public UpdateCourseService UpdateCourseService
        {
            get { return _updateCourseService = _updateCourseService ?? new UpdateCourseService(_context); }
        }
        // GetCourseByIdService
        public GetCourseByIdService _getCourseByIdService;
        public GetCourseByIdService GetCourseByIdService
        {
            get { return _getCourseByIdService = _getCourseByIdService ?? new GetCourseByIdService(_context); }
        }
        // GetAllCoursesService
        public GetAllCoursesService _getAllCoursesService;
        public GetAllCoursesService GetAllCoursesService
        {
            get { return _getAllCoursesService = _getAllCoursesService ?? new GetAllCoursesService(_context); }
        }
    }
}
