using IranFilmPort.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace IranFilmPort.Domain.Entities.News
{
    public class NewsCategories : BaseEntity
    {
        [Required]
        [MaxLength(1000)]
        public string Title { get; set; }
        public Guid? SubId { get; set; } // is null: parent / is not null: child
        // سینما => subId= null
        // فیلم کوتاه => subId = Idسینما
        public long AutoIncreamentId { get; set; }
        // www.kingetoNEws.ir/cat/سینما/545
    }
}
