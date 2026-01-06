using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Helpers;

namespace IranFilmPort.Application.Services.SendInformation.Queries.GetAllSendInformation
{
    public class RequestGetAllSendInformationServiceDto
    {
        public int CurrentPage { get; set; } // current page
    }
    public class GetAllSendInformationServiceDto
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string WhichWay { get; set; } // SendInformationWhichWayContants.cs
        public string? Link { get; set; }
        public string? Password { get; set; }
        public byte Status { get; set; } // StatusContants.cs
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetAllSendInformationServiceDto
    {
        public List<GetAllSendInformationServiceDto> Result { get; set; }
        public int RowCount { get; set; }//  <---- pagination
        public int RowsOnEachPage { get; set; }//  <---- pagination
    }
    public interface IGetAllSendInformationService
    {
        ResultGetAllSendInformationServiceDto Execute(RequestGetAllSendInformationServiceDto req);
    }
    public class GetAllSendInformationService : IGetAllSendInformationService
    {
        private readonly IDataBaseContext _context;
        public GetAllSendInformationService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllSendInformationServiceDto Execute(RequestGetAllSendInformationServiceDto req)
        {
            int RowsCount; //<------ pagination
            int RowsOnEachPage = 20; //<------ pagination
            var result = _context.SendInformation
                .Select(x => new GetAllSendInformationServiceDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    Fullname = x.Fullname,
                    Phone = x.Phone,
                    Link = x.Link,
                    Password = x.Password,
                    Status = x.Status,
                    WhichWay = x.WhichWay,
                    InsertDateTime = x.InsertDateTime,
                })
                .OrderByDescending(x => x.Status)
                .ToPaged(req.CurrentPage, RowsOnEachPage, out RowsCount) //  <----  pagination
                .ToList();
            return new ResultGetAllSendInformationServiceDto
            {
                Result = result,
                RowCount = RowsCount, //  <---- pagination
                RowsOnEachPage = RowsOnEachPage, //  <---- pagination
            };
        }
    }
}
