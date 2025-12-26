namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategories
{
    public class GetNewsCategoriesServiceDto
    {
        public byte Type { get; set; } // articletypeconstants.cs
        public Guid Id { get; set; }
        public long AutoIncrementId { get; set; } // because I can't use GUID to show in public
        public string Title { get; set; }
        public Guid? SubId { get; set; } // برای دسته بندی های زیر دسته قبلی
        public DateTime PublishDate { get; set; }
    }
}
