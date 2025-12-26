namespace IranFilmPort.Application.Services.NewsCategories.Commands.PostNewsCategory
{
    public class RequestPostNewsCategoryServiceDto
    {
        public string Title { get; set; }
        public Guid SubId { get; set; } // برای دسته بندی های زیر دسته قبلی
    }
}
