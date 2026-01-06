using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Helpers;

namespace IranFilmPort.Application.Services.Sliders.Queries.GetSlidersForAdmin
{
    public class RequestGetSlidersForAdminServiceDto
    {
        public int CurrentPage { get; set; } // current page
    }
    public class GetSlidersForAdminServiceDto
    {
        public Guid Id { get; set; }
        public string File { get; set; }
        public string Text { get; set; }
        public string TextEn { get; set; }
        public string SubText { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResutlGetSlidersForAdminServiceDto
    {
        public List<GetSlidersForAdminServiceDto> Result { get; set; }
        public int RowCount { get; set; }//  <---- pagination
        public int RowsOnEachPage { get; set; }//  <---- pagination
    }
    public interface IGetSlidersForAdminService
    {
        ResutlGetSlidersForAdminServiceDto Execute(RequestGetSlidersForAdminServiceDto req);
    }
    public class GetSlidersForAdminService : IGetSlidersForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetSlidersForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResutlGetSlidersForAdminServiceDto Execute(RequestGetSlidersForAdminServiceDto req)
        {
            int RowsCount; //<------ pagination
            int RowsOnEachPage = 20; //<------ pagination

            var result = _context.Sliders
                .Select(x => new GetSlidersForAdminServiceDto
                {
                    Active = x.Active,
                    File = x.File,
                    Id = x.Id,
                    InsertDateTime = x.InsertDateTime,
                    Link = x.Link,
                    SubText = x.SubText,
                    Text = x.Text,
                    TextEn = x.TextEn,
                })
                .ToPaged(req.CurrentPage, RowsOnEachPage, out RowsCount) //  <----  pagination
                .OrderByDescending(x => x.InsertDateTime)
                .ToList();
            return new ResutlGetSlidersForAdminServiceDto
            {
                Result = result,
                RowCount = RowsCount, //  <---- pagination
                RowsOnEachPage = RowsOnEachPage, //  <---- pagination
            };
        }
    }
}
