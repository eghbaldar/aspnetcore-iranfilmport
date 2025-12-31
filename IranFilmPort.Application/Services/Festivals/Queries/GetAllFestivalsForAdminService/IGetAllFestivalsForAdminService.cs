using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Helpers;

namespace IranFilmPort.Application.Services.Festivals.Queries.GetAllFestivalsForAdminService
{
    public class RequestGetAllFestivalsForAdminServiceDto
    {
        public int CurrentPage { get; set; } // current page
    }
    public class GetAllFestivalsForAdminServiceDto
    {
        public int UniqueCode { get; set; }
        public Guid Id { get; set; }      
        public string TitleEn { get; set; }
        public string TitleFa { get; set; }
        public bool Active { get; set; }
        public int Visit { get; set; }
        public DateTime InsertDate { get; set; }
    }
    public class ResultGetAllFestivalsForAdminServiceDto
    {
        public List<GetAllFestivalsForAdminServiceDto> Result { get; set; }
        public int RowCount { get; set; }//  <---- pagination
        public int RowsOnEachPage { get; set; }//  <---- pagination
    }
    public interface IGetAllFestivalsForAdminService
    {
        ResultGetAllFestivalsForAdminServiceDto Execute(RequestGetAllFestivalsForAdminServiceDto req);
    }
    public class GetAllFestivalsForAdminService : IGetAllFestivalsForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetAllFestivalsForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllFestivalsForAdminServiceDto Execute(RequestGetAllFestivalsForAdminServiceDto req)
        {
            int RowsCount; //<------ pagination
            int RowsOnEachPage = 50; //<------ pagination

            var festivals = _context.Festivals
                .Select(x => new GetAllFestivalsForAdminServiceDto
                {
                    Active = x.Active,
                    Id = x.Id,
                    InsertDate = x.InsertDateTime,
                    TitleEn = x.TitleEn,
                    TitleFa = x.TitleFa,
                    Visit = x.Visit,
                    UniqueCode = x.UniqueCode
                })
                .OrderByDescending(x => x.InsertDate)
                .ToPaged(req.CurrentPage, RowsOnEachPage, out RowsCount) //  <----  pagination
                .ToList();
            return new ResultGetAllFestivalsForAdminServiceDto
            {
                Result = festivals,
                RowCount = RowsCount, //  <---- pagination
                RowsOnEachPage = RowsOnEachPage, //  <---- pagination
            };
        }
    }
}
