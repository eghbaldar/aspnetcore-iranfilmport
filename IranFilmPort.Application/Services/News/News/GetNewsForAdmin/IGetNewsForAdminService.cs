using IranFilmPort.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IranFilmPort.Application.Services.News.News.GetNewsForAdmin
{
    public class RequestGetNewsForAdminServiceDto
    {
        public Guid? Id { get; set; }
    }
    public class GetNewsForAdminServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // سایت خبری کنیگتو افتتاح شد
        public string Slug { get; set; } // سایت-خبری-کنیگتو-افتتاح-شد
        // www.kingeto.ir/news/سایت-خبری-کنیگتو-افتتاح-شد
        public string Summary { get; set; }
        public string BodyText { get; set; }
        public string MainImage { get; set; } // Filename
        public int Visit { get; set; }
        public string Author { get; set; }
        public string Reference { get; set; }
        public bool? Active { get; set; } // NewsActiveConstants.cs
        public string UniqueCode { get; set; }
        public DateTime? FutureDateTime { get; set; } // FutureDateTime < DateTime.Now()
        public Guid ParentCategoryId { get; set; }
        public Guid ChildrenCategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime InsertDate { get; set; }
        public Dictionary<Guid, string> Tags { get; set; }
    }
    public interface IGetNewsForAdminService
    {
        GetNewsForAdminServiceDto? Execute(RequestGetNewsForAdminServiceDto req);
    }
    public class GetNewsForAdminService : IGetNewsForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetNewsForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetNewsForAdminServiceDto? Execute(RequestGetNewsForAdminServiceDto req)
        {
            if (req.Id == null) return null;

            //initial fetch
            var result = _context.News
                .Include(x => x.Category)
                .Include(x => x.NewsTags)
                .Where(x => x.Id == req.Id)
                .ToList();

            // apply your process to memory-data
            return result
                .Select(x => new GetNewsForAdminServiceDto
                {
                    Active = x.Active,
                    CategoryName = x.Category.Title,
                    FutureDateTime = x.FutureDateTime,
                    Id = x.Id,
                    InsertDate = x.InsertDateTime,
                    Slug = x.Slug,
                    Title = x.Title,
                    Visit = x.Visit,
                    Author = x.Author,
                    BodyText = x.BodyText,
                    ParentCategoryId = (Guid)_context.NewsCategories.First(y => y.Id == x.CategoryId).SubId,
                    ChildrenCategoryId = x.CategoryId,
                    MainImage = x.MainImage,
                    Reference = x.Reference,
                    Summary = x.Summary,
                    UniqueCode = x.UniqueCode,
                    Tags = x.NewsTags.ToList().ToDictionary(t => t.Id, t => t.Title),
                })
                .OrderByDescending(x => x.InsertDate)
                .FirstOrDefault();
        }

    }
}
