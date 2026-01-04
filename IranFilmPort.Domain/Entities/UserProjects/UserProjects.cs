using IranFilmPort.Domain.Common;
using IranFilmPort.Domain.Entities.User;

namespace IranFilmPort.Domain.Entities.UserProjects
{
    public class UserProjects : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual Users User { get; set; }
        public int UniqueCode { get; set; }
        public byte Type { get; set; } // UserProjectTypeConstants.cs
        public string TitleFa { get; set; }
        public string? TitleEn { get; set; }
        public string Slug { get; set; }        
        public string SynopsisFa { get; set; }
        public string? SynopsisEn { get; set; }
        public DateTime ProductionDate { get; set; }
        public string? PageLink { get; set; }
        public byte Status { get; set; } // StatusConstants.cs

        public string? Director { get; set; }
        public string? DirectorEn { get; set; }
        public string? Writer { get; set; }
        public string? WriterEn { get; set; }
        public string? Producer { get; set; }
        public string? ProduerEn { get; set; }
        public string? Detail { get; set; }
        public string? DetailEn { get; set; }

        public bool Genuine { get; set; } // false: the user didnt' send his work yet true: we checked it
        public string? ArtworkLink { get; set; }
        public string? ArtworkPassword { get; set; }

        public int Visit { get; set; }
        public ICollection<UserProjectPhotos> UserProjectPhotos { get; set; }
    }
}
