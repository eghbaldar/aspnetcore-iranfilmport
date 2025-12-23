using IranFilmPort.Application.Interfaces;

namespace IranFilmPort.Application.Services.News.NewsCategories.GetParentCategories
{
    public class GetParentCategoriesDto
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
    }
    public class ResultGetParentCategoriesDto
    {
        public List<GetParentCategoriesDto> Result { get; set; }
    }
    public interface IGetParentCategories
    {
        ResultGetParentCategoriesDto Execute();
    }
    public class GetParentCategories : IGetParentCategories
    {
        private readonly IDataBaseContext _context;
        public GetParentCategories(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetParentCategoriesDto Execute()
        {
            var _result = _context.NewsCategories
                .Where(x => x.SubId == Guid.Empty || x.SubId == null)
                .OrderByDescending(x => x.InsertDateTime)
                .Select(x => new GetParentCategoriesDto
                {
                    Title = x.Title,
                    Id = x.Id,
                    ParentId = x.SubId
                })
                .ToList();
            return new ResultGetParentCategoriesDto
            {
                Result = _result
            };
        }
    }
}
