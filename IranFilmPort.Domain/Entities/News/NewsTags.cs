using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.News
{
    public class NewsTags : BaseEntity
    {
        public string Title { get; set; }
        public Guid NewsId { get; set; }
        public virtual News News { get; set; }
    }
}
