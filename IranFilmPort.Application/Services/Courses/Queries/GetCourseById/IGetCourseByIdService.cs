using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Courses.Queries.GetCourseById
{
    public class RequestGetCourseByIdServiceDto
    {
        public Guid Id { get; set; }
    }
    public class GetCourseByIdServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Teacher { get; set; }
        public string Image { get; set; }
        public string TeacherHeadshot { get; set; }
        public string Detail { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public interface IGetCourseByIdService
    {
        GetCourseByIdServiceDto Execute(RequestGetCourseByIdServiceDto req);
    }
    public class GetCourseByIdService : IGetCourseByIdService
    {
        private readonly IDataBaseContext _context;
        public GetCourseByIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetCourseByIdServiceDto Execute(RequestGetCourseByIdServiceDto req)
        {
            var result = _context.Courses
                .Where(x => x.Id == req.Id)
                .Select(x => new GetCourseByIdServiceDto
                {
                    Detail = x.Detail,
                    Id = x.Id,
                    Image = x.Image,
                    InsertDateTime = x.InsertDateTime,
                    Teacher = x.Teacher,
                    TeacherHeadshot = x.TeacherHeadshot,
                    Title = x.Title
                })
                .FirstOrDefault();
            return result;
        }
    }
}
