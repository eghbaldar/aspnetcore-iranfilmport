using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsByNewsCategoryId;
using IranFilmPort.Common.Helpers;

namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsSubCategories
{
    public class GetNewsSubCategoriesService : IGetNewsSubCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetNewsSubCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNewsByNewsCategoryIdServiceDto Execute(RequestGetNewsSubCategoriesServiceDto req)
        {
            int RowsCount; //<------ pagination
            int RowsOnEachPage = 30; //<------ pagination

            var catId = _context.NewsCategories.Where(x => x.AutoIncreamentId == req.AutoIncreamentSubCategory).FirstOrDefault().Id;
            var cats = _context.NewsCategories.Where(x => x.SubId == catId).Select(x => x.Id).ToList();

            var result = _context.News
               .Where(x => x.Active && cats.Contains(x.NewsCategoryId) && x.FutureDateTime.Date <= DateTime.Now.Date)
               .ToPaged(req.CurrentPage, RowsOnEachPage, out RowsCount) //  <----  pagination
               .Select(x => new GetNewsByNewsCategoryIdServiceDto
               {
                   Active = x.Active,
                   NewsCategoryId = x.Id,
                   Author = x.Author,
                   MainImage = x.MainImage,
                   FutureDateTime = x.FutureDateTime,
                   Title = x.Title,
                   Visit = x.Visit,
               })
               .OrderByDescending(x => x.FutureDateTime)
               .ToList();
            return new ResultGetNewsByNewsCategoryIdServiceDto
            {
                Result = result,
                TotalNews = result.Count,
                RowCount = RowsCount, //  <---- pagination
                RowsOnEachPage = RowsOnEachPage, //  <---- pagination
            };
        }
    }
}
