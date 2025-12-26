using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.News.NewsCategories.GetChildrenCategories
{
    public class RequestGetChildrenCategoriesDto
    {
        public Guid ParentId { get; set; }
    }
    public class GetChildrenCategoriesDto
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
    }
    public class ResultGetChildrenCategoriesDto
    {
        public List<GetChildrenCategoriesDto> Result { get; set; }
    }
    public interface IGetChildrenCategories
    {
        ResultGetChildrenCategoriesDto Execute(RequestGetChildrenCategoriesDto req);
    }
    public class GetChildrenCategories : IGetChildrenCategories
    {
        private readonly IDataBaseContext _context;
        public GetChildrenCategories(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetChildrenCategoriesDto Execute(RequestGetChildrenCategoriesDto req)
        {
            var _result = _context.NewsCategories
                .Where(x => x.SubId == req.ParentId)
                .OrderByDescending(x => x.InsertDateTime)
                .Select(x => new GetChildrenCategoriesDto
                {
                    Title = x.Title,
                    Id = x.Id
                })
                .ToList();
            return new ResultGetChildrenCategoriesDto
            {
                Result = _result
            };
        }
    }
}
