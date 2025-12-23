using IranFilmPort.Application.Interfaces;
namespace IranFilmPort.Application.Services.News.NewsComments.GetNewsComments
{
    public class GetNewsCommentsServiceDto
    {
        public Guid NewsId { get; set; }
        public string Comment { get; set; }
        public bool Admin { get; set; } // false: regular user
                                        // true: admin
        public Guid? ParentId { get; set; }
        public byte Active { get; set; } // NewsCommentActiveConstants.cs
        public string? Email { get; set; }
        public string? Fullname { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetNewsCommentsServiceDto
    {
        public List<GetNewsCommentsServiceDto> Result { get; set; }
    }
    public interface IGetNewsCommentsService
    {
        ResultGetNewsCommentsServiceDto Execute();
    }
    public class GetNewsCommentsService : IGetNewsCommentsService
    {
        private readonly IDataBaseContext _context;
        public GetNewsCommentsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNewsCommentsServiceDto Execute()
        {
            var result = _context.NewsComments
                .OrderByDescending(x => x.InsertDateTime)
                .Select(x => new GetNewsCommentsServiceDto
                {
                    Active = x.Active,
                    NewsId = x.NewsId,
                    Admin = x.Admin,
                    Comment = x.Comment,
                    Email = x.Email,
                    Fullname = x.Fullname,
                    ParentId = x.ParentId,
                    InsertDateTime = x.InsertDateTime
                })
                .ToList();
            return new ResultGetNewsCommentsServiceDto
            {
                Result = result
            };
        }
    }
}
