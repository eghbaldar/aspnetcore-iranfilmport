using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;
using IranFilmPort.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IranFilmPort.Application.Services.News.News.Queries.GetNewsByFilterForAdmin
{
    public class RequestGetNewsByFilterForAdminServiceDto
    {
        public int CurrentPage { get; set; } // current page
        public byte Filter { get; set; } // 0:all 1:published 2:future
    }
    public class GetNewsByFilterForAdminServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // سایت خبری کنیگتو افتتاح شد
        public int Visit { get; set; }
        public bool? Active { get; set; } // NewsActiveConstants.cs
        public DateTime? FutureDateTime { get; set; } // FutureDateTime < DateTime.Now()
        public string CategoryName { get; set; }
        public long UniqueCode { get; set; }
        public DateTime InsertDate { get; set; }
    }
    public class ResultGetNewsByFilterForAdminServiceDto
    {
        public List<GetNewsByFilterForAdminServiceDto> Result { get; set; }
        public int RowCount { get; set; }//  <---- pagination
        public int RowsOnEachPage { get; set; }//  <---- pagination
        public byte Filter { get; set; } // NewsStatusContants.cs
    }
    public interface IGetNewsByFilterForAdminService
    {
        ResultGetNewsByFilterForAdminServiceDto Execute(RequestGetNewsByFilterForAdminServiceDto req);
    }
    public class GetNewsByFilterForAdminService : IGetNewsByFilterForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetNewsByFilterForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetNewsByFilterForAdminServiceDto Execute(RequestGetNewsByFilterForAdminServiceDto req)
        {
            int RowsCount; //<------ pagination
            int RowsOnEachPage = 50; //<------ pagination

            var result = _context.News
                .Include(x => x.NewsCategory)
                .Select(x => new GetNewsByFilterForAdminServiceDto
                {
                    Active = x.Active,
                    CategoryName = x.NewsCategory.Title,
                    FutureDateTime = x.FutureDateTime,
                    Id = x.Id,
                    InsertDate = x.InsertDateTime,
                    Title = x.Title,
                    Visit = x.Visit,
                    UniqueCode = x.UniqueCode
                })
                .OrderByDescending(x => x.InsertDate)
                .ToPaged(req.CurrentPage, RowsOnEachPage, out RowsCount) //  <----  pagination
                .ToList();
            
            switch (req.Filter)
            {
                case 0: // all
                    return new ResultGetNewsByFilterForAdminServiceDto
                    {
                        Result = result,
                        RowCount = RowsCount, //  <---- pagination
                        RowsOnEachPage = RowsOnEachPage, //  <---- pagination
                        Filter = NewsStatusContants.All
                    };
                case 1: // published
                    return new ResultGetNewsByFilterForAdminServiceDto
                    {
                        Result = result.Where(x => x.FutureDateTime <= DateTime.Now).ToList(),
                        RowCount = RowsCount, //  <---- pagination
                        RowsOnEachPage = RowsOnEachPage, //  <---- pagination
                        Filter = NewsStatusContants.Published
                    };
                case 2: // future
                    return new ResultGetNewsByFilterForAdminServiceDto
                    {
                        Result = result.Where(x => x.FutureDateTime > DateTime.Now).ToList(),
                        RowCount = RowsCount, //  <---- pagination
                        RowsOnEachPage = RowsOnEachPage, //  <---- pagination
                        Filter = NewsStatusContants.Future 
                    };
            }
            return new ResultGetNewsByFilterForAdminServiceDto
            {
                Result = result,
                RowCount = RowsCount, //  <---- pagination
                RowsOnEachPage = RowsOnEachPage, //  <---- pagination
                Filter = NewsStatusContants.All
            };
        }
    }
}
