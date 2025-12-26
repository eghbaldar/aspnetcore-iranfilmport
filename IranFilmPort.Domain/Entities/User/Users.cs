using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.User
{
    public class Users : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public byte ProviderId { get; set; } // ProviderConstants.cs
        public Guid RoleId { get; set; } // RoleConstants.cs
        public ICollection<UsersSuspicious> UsersSuspicious { get; set; }
        public ICollection<UsersLogs> UsersLogs { get; set; }
        public ICollection<UserRefreshToken> UserRefreshToken { get; set; }
    }
}
