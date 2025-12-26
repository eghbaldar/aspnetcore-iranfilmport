using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.User
{
    public class UsersSuspicious : BaseEntity
    {
        public Guid? UserId { get; set; } // [UserId != null] => if the user is authenticated & [UserId == null] if the user is unauthenticated
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public DateTime BanDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? Reason { get; set; }
    }
}
