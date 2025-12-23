using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.News
{
    public class NewsComments : BaseEntity
    {
        public Guid NewsId { get; set; }
        public virtual News News { get; set; }
        public string Comment { get; set; }
        public bool Admin { get; set; } // false: regular user
                                        // true: admin
        public Guid? ParentId { get; set; }
        public byte Active { get; set; } // NewsCommentActiveConstants.cs
        public string? Email { get; set; }
        public string? Fullname { get; set; }
    }
}
