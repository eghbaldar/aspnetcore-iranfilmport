using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Helpers;

namespace IranFilmPort.Application.Services.JobRequests.Queries.GetAllJobRequests
{
    public class RequestGetAllJobRequestsServiceDto
    {
        public int CurrentPage { get; set; } // current page
    }
    public class GetAllJobRequestsServiceDto
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte Category { get; set; } // JobRequestCategoryConstants.cs
        public string Resume { get; set; }
        public string IP { get; set; }
        public byte Status { get; set; } // StatusConstants.cs
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetAllJobRequestsServiceDto
    {
        public List<GetAllJobRequestsServiceDto> Result { get; set; }
        public int RowCount { get; set; }//  <---- pagination
        public int RowsOnEachPage { get; set; }//  <---- pagination
    }
    public interface IGetAllJobRequestsService
    {
        ResultGetAllJobRequestsServiceDto Execute(RequestGetAllJobRequestsServiceDto req);
    }
    public class GetAllJobRequestsService : IGetAllJobRequestsService
    {
        private readonly IDataBaseContext _context;
        public GetAllJobRequestsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllJobRequestsServiceDto Execute(RequestGetAllJobRequestsServiceDto req)
        {
            int RowsCount; //<------ pagination
            int RowsOnEachPage = 20; //<------ pagination
            var result = _context.JobRequests
                .Select(x => new GetAllJobRequestsServiceDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    Fullname = x.Fullname,
                    Phone = x.Phone,                    
                    Status = x.Status,
                    Category = x.Category,
                    IP = x.IP,
                    Resume = x.Resume,
                    InsertDateTime = x.InsertDateTime,
                })
                .OrderByDescending(x => x.Status)
                .ToPaged(req.CurrentPage, RowsOnEachPage, out RowsCount) //  <----  pagination
                .ToList();
            return new ResultGetAllJobRequestsServiceDto
            {
                Result = result,
                RowCount = RowsCount, //  <---- pagination
                RowsOnEachPage = RowsOnEachPage, //  <---- pagination
            };
        }
    }
}
