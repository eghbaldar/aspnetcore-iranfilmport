using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Festival
{
    public class FestivalSections : BaseEntity
    {
        public Guid FestivalId { get; set; }
        public virtual Festivals Festival { get; set; }
        public string Title { get; set; }
        public ICollection<FestivalDeadlines> FestivalDeadlines { get; set; }
    }
}
