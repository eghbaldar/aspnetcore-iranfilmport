using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Guest
{
    public class JobRequests: BaseEntity
    {
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte Category { get; set; } // JobRequestCategoryConstants.cs
        public string Resume { get; set; }
        public string IP { get; set; }
        public byte Status { get; set; } // StatusConstants.cs
    }
}
