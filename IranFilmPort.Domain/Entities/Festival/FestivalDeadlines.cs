using IranFilmPort.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace IranFilmPort.Domain.Entities.Festival
{
    public class FestivalDeadlines : BaseEntity
    {
        public Guid FestivalSectionId { get; set; }
        public virtual FestivalSections FestivalSection { get; set; }
        public DateTime Deadline { get; set; }
        [MaxLength(3)]
        public string Fee { get; set; }
    }
}
