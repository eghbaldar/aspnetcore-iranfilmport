namespace IranFilmPort.Application.Services.NewsComments.Commands.UpdateNewsCommentActive
{
    public class RequestUpdateNewsCommentActiveServiceDto
    {
        public Guid CommentId { get; set; }
        public byte Active { get; set; }
    }
}
