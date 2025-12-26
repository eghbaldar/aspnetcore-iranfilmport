namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsByNewsCategoryId
{
    public class RequestGetNewsByNewsCategoryIdServiceDto
    {
        public long CategoryId { get; set; }
        public int CurrentPage { get; set; }  //<------ pagination = current page

    }
}
