namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsSubCategories
{
    public class RequestGetNewsSubCategoriesServiceDto
    {
        public long AutoIncreamentSubCategory { get; set; }
        public int CurrentPage { get; set; }  //<------ pagination = current page
    }
}
