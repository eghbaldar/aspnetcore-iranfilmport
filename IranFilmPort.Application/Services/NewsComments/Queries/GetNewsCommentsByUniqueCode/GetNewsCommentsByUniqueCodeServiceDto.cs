namespace IranFilmPort.Application.Services.NewsComments.Queries.GetNewsCommentsByUniqueCode
{
    public class GetNewsCommentsByUniqueCodeServiceDto
    {
        public Guid Id { get; set; }
        public Guid NewsId { get; set; }
        public virtual IranFilmPort.Domain.Entities.News.News News { get; set; }
        public bool Admin { get; set; } = false; // False=> Regular User True=> Admin
        public Guid? ParentId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public byte Active { get; set; } = 0;
        public DateTime InsertDate { get; set; }        
    }
}
