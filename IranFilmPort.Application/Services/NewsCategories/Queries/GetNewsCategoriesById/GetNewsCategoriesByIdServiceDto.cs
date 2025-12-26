namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategoriesById
{
    public class GetNewsCategoriesByIdServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool MainSub { get; set; } // false: Main true: Sub
        public Guid? SubId { get; set; } // برای دسته بندی های زیر دسته قبلی
    }
}
