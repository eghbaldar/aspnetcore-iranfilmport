namespace IranFilmPort.Application.Services.NewsComments.Queries.GetNewsComments
{
    public class GetNewsCommentsServiceDto
    {
        public Guid NewsId { get; set; }
        public string NewsTitle { get; set; }
        public long NewsUniqueCode { get; set; }
        public int Total { get; set; }
        public int UnderConsiderationCount { get; set; }
        public int AcceptedCount { get; set; }
        public int RejectedCount { get; set; }
    }
}
