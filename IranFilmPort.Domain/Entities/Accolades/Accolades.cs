using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Accolades
{
    public class Accolades : BaseEntity
    {
        public long FilmId { get; set; }
        public string AccoladeFa { get; set; }
        public string? AccoladeEn { get; set; }
        public int Priority { get; set; }

        // قسمت زیر ترکیبی شده 
        // چون در وب سایت قبلی جدولی با عنوان
        // tbl_posterOFCustomer
        // داشتیم که نمیخواستم براش جدول جدا بذارم
        public byte ArtworkType { get; set; } // ArtworkTypeConstants.cs
        public string? Director { get; set; }
        public string? PosterFile { get; set; }
        public string? TrailerLink { get; set; }
    }
}
