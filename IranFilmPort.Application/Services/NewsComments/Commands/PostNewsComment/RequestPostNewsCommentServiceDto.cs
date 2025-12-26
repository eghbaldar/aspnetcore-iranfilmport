namespace IranFilmPort.Application.Services.NewsComments.Commands.PostNewsComment
{
    public class RequestPostNewsCommentServiceDto
    {
        public Guid NewsId { get; set; }
        public Guid? ParentId { get; set; }
        public bool Admin { get; set; } = false; // False=> Regular User True=> Admin
        public byte Active { get; set; } // 0=> under considration 1=> accepted 2=> rejected
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string CaptchaCode { get; set; }
    }
}
