using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsChildrenCategories
{
    public class RequestGetNewsChildrenCategoriesDto
    {
        public Guid ParentId { get; set; }
    }
    public class GetNewsChildrenCategoriesDto
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
    }
    public class ResultGetNewsChildrenCategoriesDto
    {
        public List<GetNewsChildrenCategoriesDto> Result { get; set; }
    }
    public interface IGetNewsChildrenCategories
    {
        ResultGetNewsChildrenCategoriesDto Execute(RequestGetNewsChildrenCategoriesDto req);
    }
    public class GetNewsChildrenCategories : IGetNewsChildrenCategories
    {
        private readonly IDataBaseContext _context;
        public GetNewsChildrenCategories(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNewsChildrenCategoriesDto Execute(RequestGetNewsChildrenCategoriesDto req)
        {
            var _result = _context.NewsCategories
                .Where(x => x.SubId == req.ParentId)
                .OrderByDescending(x => x.InsertDateTime)
                .Select(x => new GetNewsChildrenCategoriesDto
                {
                    Title = x.Title,
                    Id = x.Id
                })
                .ToList();
            return new ResultGetNewsChildrenCategoriesDto
            {
                Result = _result
            };
        }
    }
}
