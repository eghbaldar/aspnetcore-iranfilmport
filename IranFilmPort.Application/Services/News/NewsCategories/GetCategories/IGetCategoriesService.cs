using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.News.NewsCategories.GetCategories
{
    public class GetCategoriesServiceDto
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
    }
    public class ResultGetCategoriesServiceDto
    {
        public List<GetCategoriesServiceDto> Result { get; set; }
    }
    public interface IGetCategoriesService
    {
        ResultGetCategoriesServiceDto Execute();
    }
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetCategoriesServiceDto Execute()
        {
            var _result = _context.NewsCategories
                .OrderByDescending(x => x.InsertDateTime)
                .Select(x => new GetCategoriesServiceDto
                {
                    Title = x.Title,
                    Id = x.Id,
                    ParentId = x.SubId,
                })
                .ToList();
            return new ResultGetCategoriesServiceDto
            {
                Result = _result
            };
        }
    }
}
