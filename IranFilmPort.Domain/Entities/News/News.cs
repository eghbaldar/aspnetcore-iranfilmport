using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.News
{
    public class News: BaseEntity
    {
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string Summary { get; set; }
        public string BodyText { get; set; }
        public string MainImage { get; set; } 
        public int Visit { get; set; }
        public string Author { get; set; }
        public string Reference { get; set; }
        public bool Active { get; set; }
        public long UniqueCode { get; set; }
        public DateTime FutureDateTime { get; set; } // FutureDateTime < DateTime.Now()

        public Guid NewsCategoryId{ get; set; }
        public  virtual NewsCategories NewsCategory { get; set; }

        public ICollection<NewsComments> NewsComments{ get; set; }
        public ICollection<NewsTags> NewsTags { get; set; }
    }
}
