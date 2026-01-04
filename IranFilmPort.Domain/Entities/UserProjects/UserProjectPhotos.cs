using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.UserProjects
{
    public class UserProjectPhotos:BaseEntity
    {
        public Guid ProjectId { get; set; } // derived from UserProjects.cs
        public string File { get; set; }
        public byte Type { get; set; } // UserProjectPhotoTypes.cs
        public byte Status { get; set; } // StatusConstants.cs
    }
}
