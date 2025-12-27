using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsParentCategories
{
    public class GetNewsParentCategoriesDto
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
    }
    public class ResultGetNewsParentCategoriesDto
    {
        public List<GetNewsParentCategoriesDto> Result { get; set; }
    }
    public interface IGetNewsParentCategories
    {
        ResultGetNewsParentCategoriesDto Execute();
    }
    public class GetNewsParentCategories : IGetNewsParentCategories
    {
        private readonly IDataBaseContext _context;
        public GetNewsParentCategories(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNewsParentCategoriesDto Execute()
        {
            var _result = _context.NewsCategories
                .Where(x => x.SubId == Guid.Empty || x.SubId == null)
                .OrderByDescending(x => x.InsertDateTime)
                .Select(x => new GetNewsParentCategoriesDto
                {
                    Title = x.Title,
                    Id = x.Id,
                    ParentId = x.SubId
                })
                .ToList();
            return new ResultGetNewsParentCategoriesDto
            {
                Result = _result
            };
        }
    }
}
