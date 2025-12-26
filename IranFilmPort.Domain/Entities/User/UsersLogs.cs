using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.User
{
    public class UsersLogs:BaseEntity
    {
        public Guid? UserId { get; set; }
        public virtual Users User { get; set; }
        public string RequestPath { get; set; }
        public string Method { get; set; }
        public string IP { get; set; }
        public string? MethodName { get; set; }
        public string UserAgent { get; set; }
        public bool Auth { get; set; } // {true}: the user is authenticated  {false}: the user is unautheticated
        public DateTime InsertDateTime { get; set; } = DateTime.Now;
    }
}
