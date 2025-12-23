using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.News
{
    public class News: BaseEntity
    {
        public string Title { get; set; } // سایت خبری کنیگتو افتتاح شد
        public string Slug { get; set; } // سایت-خبری-کنیگتو-افتتاح-شد
        // www.kingeto.ir/news/سایت-خبری-کنیگتو-افتتاح-شد
        public string Summary { get; set; }
        public string BodyText { get; set; }
        public string MainImage { get; set; } // Filename
        public int Visit { get; set; }
        public string Author { get; set; }
        public string Reference { get; set; }
        public bool? Active { get; set; }
        public string UniqueCode { get; set; }
        public DateTime? FutureDateTime { get; set; } // FutureDateTime < DateTime.Now()
        public Guid CategoryId { get; set; }
        public virtual NewsCategories Category { get; set; }
        public ICollection<NewsComments> NewsComments{ get; set; }
        public ICollection<NewsTags> NewsTags { get; set; }
    }
}
