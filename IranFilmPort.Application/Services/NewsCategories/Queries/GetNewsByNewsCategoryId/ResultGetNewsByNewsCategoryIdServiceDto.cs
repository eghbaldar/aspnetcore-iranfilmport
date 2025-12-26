namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsByNewsCategoryId
{
    public class ResultGetNewsByNewsCategoryIdServiceDto
    {
        public List<GetNewsByNewsCategoryIdServiceDto> Result { get; set; }
        public long TotalNews { get; set; }
        public int RowCount { get; set; }//  <---- pagination
        public int RowsOnEachPage { get; set; }//  <---- pagination
    }
}
