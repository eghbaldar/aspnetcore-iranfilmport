using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Helpers;

namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsByNewsCategoryId
{
    public class GetNewsByNewsCategoryIdService : IGetNewsByNewsCategoryIdService
    {
        private readonly IDataBaseContext _context;
        public GetNewsByNewsCategoryIdService(IDataBaseContext cotnext)
        {
            _context = cotnext;
        }
        public ResultGetNewsByNewsCategoryIdServiceDto Execute(RequestGetNewsByNewsCategoryIdServiceDto req)
        {
            if (req == null) return null;
            var catId = _context.NewsCategories.Where(x => x.AutoIncreamentId == req.CategoryId).FirstOrDefault().Id;

            int RowsCount; //<------ pagination
            int RowsOnEachPage = 32; //<------ pagination

            if (catId != null)
            {
                var NewsList = _context.News
                 .Where(x => x.NewsCategoryId == catId && x.Active && x.FutureDateTime.Date <= DateTime.Now.Date)
                 .ToPaged(req.CurrentPage, RowsOnEachPage, out RowsCount)
                 .ToList(); // materialize first

                var Newss = NewsList.Select(x => new GetNewsByNewsCategoryIdServiceDto
                {
                    Active = x.Active,
                    NewsCategoryId = x.Id,
                    NewsCategoryTitle = _context.NewsCategories
                        .First(y => y.Id == x.NewsCategoryId).Title,
                    Author = x.Author,
                    MainImage = x.MainImage,
                    FutureDateTime = x.FutureDateTime,
                    Title = x.Title,
                    Visit = x.Visit,
                    Summary = x.Summary,
                }).ToList();

                return new ResultGetNewsByNewsCategoryIdServiceDto
                {
                    Result = Newss,
                    TotalNews = Newss.Count(),
                    RowCount = RowsCount, //  <---- pagination
                    RowsOnEachPage = RowsOnEachPage, //  <---- pagination
                };
            }
            else return null;
        }
    }
}
