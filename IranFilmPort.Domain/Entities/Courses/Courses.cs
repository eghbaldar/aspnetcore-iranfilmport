using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Courses
{
    public class Courses : BaseEntity
    {
        public string Title { get; set; }
        public string Teacher { get; set; }
        public string Image { get; set; }
        public string TeacherHeadshot { get; set; }
        public string Detail { get; set; }
    }
}
