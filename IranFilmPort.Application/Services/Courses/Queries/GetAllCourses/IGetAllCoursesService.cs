using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Teacher { get; set; }
        public string Image { get; set; }
        public string TeacherHeadshot { get; set; }
        public string Detail { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResutlGetAllCoursesServiceDto
    {
        public List<GetAllCoursesServiceDto> Result { get; set; }
    }
    public interface IGetAllCoursesService
    {
        ResutlGetAllCoursesServiceDto Execute();
    }
    public class GetAllCoursesService : IGetAllCoursesService
    {
        private readonly IDataBaseContext _context;
        public GetAllCoursesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResutlGetAllCoursesServiceDto Execute()
        {
            var result = _context.Courses
                .Select(x => new GetAllCoursesServiceDto
                {
                    Detail = x.Detail,
                    Id = x.Id,
                    Image = x.Image,
                    InsertDateTime = x.InsertDateTime,
                    Teacher = x.Teacher,
                    TeacherHeadshot = x.TeacherHeadshot,
                    Title = x.Title
                })
                .OrderByDescending(x => x.InsertDateTime)
                .ToList();
            return new ResutlGetAllCoursesServiceDto
            {
                Result = result,
            };
        }
    }
}
