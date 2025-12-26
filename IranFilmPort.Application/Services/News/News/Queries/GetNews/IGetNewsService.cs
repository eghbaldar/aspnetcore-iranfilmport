using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.News.News.Commands.UpdateNewsVisit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IranFilmPort.Application.Services.News.News.Queries.GetNews
{
    public class RequestGetNewsServiceDto
    {
        public bool IsAdmin { get; set; }
        public long? UniqueCode { get; set; }
    }
    public class GetNewsServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // سایت خبری کنیگتو افتتاح شد
        public string Summary { get; set; }
        public string BodyText { get; set; }
        public string MainImage { get; set; } // Filename
        public int Visit { get; set; }
        public string Author { get; set; }
        public string Reference { get; set; }
        public bool? Active { get; set; } // NewsActiveConstants.cs
        public long UniqueCode { get; set; }
        public DateTime? FutureDateTime { get; set; } // FutureDateTime < DateTime.Now()
        public Guid ParentCategoryId { get; set; }
        public Guid ChildrenCategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime InsertDate { get; set; }
        public Dictionary<Guid, string> Tags { get; set; }
    }
    public interface IGetNewsService
    {
        GetNewsServiceDto? Execute(RequestGetNewsServiceDto req);
    }
    public class GetNewsService : IGetNewsService
    {
        private readonly IDataBaseContext _context;
        private readonly IServiceProvider _serviceProvider;
        public GetNewsService(IDataBaseContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        public GetNewsServiceDto? Execute(RequestGetNewsServiceDto req)
        {
            if (req.UniqueCode == 0 || req.UniqueCode == null) return null;

            //initial fetch
            var result = _context.News
                .Include(x => x.NewsCategory)
                .Include(x => x.NewsTags)
                .Where(x => x.UniqueCode == req.UniqueCode);

            var final = result
                .Select(x => new GetNewsServiceDto
                {
                    Active = x.Active,
                    CategoryName = x.NewsCategory.Title,
                    FutureDateTime = x.FutureDateTime,
                    Id = x.Id,
                    InsertDate = x.InsertDateTime,
                    Title = x.Title,
                    Visit = x.Visit,
                    Author = x.Author,
                    BodyText = x.BodyText,
                    ParentCategoryId = (Guid)_context.NewsCategories.First(y => y.Id == x.NewsCategoryId).SubId,
                    ChildrenCategoryId = x.NewsCategoryId,
                    MainImage = x.MainImage,
                    Reference = x.Reference,
                    Summary = x.Summary,
                    UniqueCode = x.UniqueCode,
                    Tags = x.NewsTags.ToList().ToDictionary(t => t.Id, t => t.Title),
                })
                .FirstOrDefault();

            if (result == null) return null;

            // update news visit
            if (!req.IsAdmin)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<IUpdateNewsVisitService>();
                    service.Execute(new RequestUpdateNewsVisitServiceDto
                    {
                        NewsId = final.Id,
                    });
                }
            }

            // apply your process to memory-data
            return final;
        }

    }
}
