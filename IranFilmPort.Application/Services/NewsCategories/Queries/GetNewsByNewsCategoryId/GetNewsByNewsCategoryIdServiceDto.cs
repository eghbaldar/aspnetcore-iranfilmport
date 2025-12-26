namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsByNewsCategoryId
{
    public class GetNewsByNewsCategoryIdServiceDto
    {
        public byte Type { get; set; } // ArticleTypeConstants.cs
        public Guid NewsCategoryId { get; set; }
        public string NewsCategoryTitle { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Slug { get; set; }
        public string MainImage { get; set; }
        public string Author { get; set; }
        public bool Active { get; set; }
        public int Visit { get; set; }
        public DateTime FutureDateTime { get; set; }
    }
}
