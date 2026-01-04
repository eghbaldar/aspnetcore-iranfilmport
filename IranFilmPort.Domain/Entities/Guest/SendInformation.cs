using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Guest
{
    public class SendInformation : BaseEntity
    {
        // در این جدول کاربران میتوانند اطلاعات فیلم و یا فیلمنامه اشان را جهت بررسی ارسال کنند
        public string Fullname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string WhichWay { get; set; } // SendInformationWhichWayContants.cs
        public string? Link { get; set; }
        public string? Password { get; set; }
        public byte Status { get; set; } // StatusContants.cs
    }
}
