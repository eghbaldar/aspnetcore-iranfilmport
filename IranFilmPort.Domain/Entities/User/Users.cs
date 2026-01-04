using IranFilmPort.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace IranFilmPort.Domain.Entities.User
{
    public class Users : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public byte ProviderId { get; set; } // ProviderConstants.cs
        public Guid RoleId { get; set; } // RoleConstants.cs

        // MORE INFORMATION

        [MaxLength(100)]
        public string? Firstname_En { get; set; }
        [MaxLength(100)]
        public string? Lastname_En { get; set; }
        [MaxLength(3000)]
        public string? Resume { get; set; }
        [MaxLength(3000)]
        public string? Resume_En { get; set; }
        public DateTime? Birthday { get; set; }
        public byte Position { get; set; } // PositionContants.cs
        public bool? Phone_Visibility { get; set; }
        public bool? Email_Visibility { get; set; }
        public byte? Degree { get; set; } // DegreeContants.cs
        public string? DegreeField { get; set; }
        [MaxLength(50)]
        public string? Website { get; set; }
        [MaxLength(30)]
        public string? Twitter { get; set; }
        [MaxLength(30)]
        public string? Facebook { get; set; }
        [MaxLength(30)]
        public string? Instagram { get; set; }
        [MaxLength(220)]
        public string? IMDb { get; set; }

        public string? Headshot { get; set; }
        public byte? HeadshotStatus { get; set; } // StatusConstants.cs
        public string? HeadshotStatusMessage { get; set; }  // ادمین میتواند پیغامی برای کاربر بگذارد


        public string? MeliCard { get; set; }
        public byte? MeliCardStatus { get; set; } // StatusConstants.cs
        public string? MeliCardStatusMessage { get; set; }  // ادمین میتواند پیغامی برای کاربر بگذارد

        public byte MainStatus { get; set; } // StatusConstants.cs
        public string? MainStatusMessage { get; set; }  // ادمین میتواند پیغامی برای کاربر بگذارد

        // relationships...

        public ICollection<IranFilmPort.Domain.Entities.UserProjects.UserProjects> UserProjects { get; set; }
        public ICollection<UsersSuspicious> UsersSuspicious { get; set; }
        public ICollection<UsersLogs> UsersLogs { get; set; }
        public ICollection<UserRefreshToken> UserRefreshToken { get; set; }
    }
}
