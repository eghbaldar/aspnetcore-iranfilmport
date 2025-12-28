using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;
using IranFilmPort.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IranFilmPort.Application.Services.News.News.Queries.GetAllNewsForAdmin
{
    public class RequestGetAllNewsForAdminServiceDto
    {
        public int CurrentPage { get; set; } // current page
    }
    public class GetAllNewsForAdminServiceDto
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
    public class ResultGetAllNewsForAdminServiceDto
    {
        public List<GetAllNewsForAdminServiceDto> Result { get; set; }
        public int RowCount { get; set; }//  <---- pagination
        public int RowsOnEachPage { get; set; }//  <---- pagination
        public byte Filter { get; set; } // NewsStatusContants.cs
    }
    public interface IGetAllNewsForAdminService
    {
        ResultGetAllNewsForAdminServiceDto Execute(RequestGetAllNewsForAdminServiceDto req);
    }
    public class GetAllNewsForAdminService : IGetAllNewsForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetAllNewsForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllNewsForAdminServiceDto Execute(RequestGetAllNewsForAdminServiceDto req)
        {
            int RowsCount; //<------ pagination
            int RowsOnEachPage = 50; //<------ pagination

            var result = _context.News
                .Include(x => x.NewsCategory)
                .Select(x => new GetAllNewsForAdminServiceDto
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
            return new ResultGetAllNewsForAdminServiceDto
            {
                Result = result,
                RowCount = RowsCount, //  <---- pagination
                RowsOnEachPage = RowsOnEachPage, //  <---- pagination
                Filter = NewsStatusContants.All
            };
        }
    }
}
