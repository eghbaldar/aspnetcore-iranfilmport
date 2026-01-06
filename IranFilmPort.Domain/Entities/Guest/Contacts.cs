using IranFilmPort.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace IranFilmPort.Domain.Entities.Guest
{
    public class Contacts : BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string IP { get; set; }
        [MaxLength(3000)]
        public string Message { get; set; }
        public bool Status { get; set; } // 0:unread 1:read
    }
}
