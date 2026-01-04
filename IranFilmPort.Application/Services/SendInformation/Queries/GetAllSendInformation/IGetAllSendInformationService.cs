using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.SendInformation.Queries.GetAllSendInformation
{
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
    }
    public class ResultGetAllSendInformationServiceDto
    {
        public List<GetAllSendInformationServiceDto> Result { get; set; }
    }
    public interface IGetAllSendInformationService
    {
        ResultGetAllSendInformationServiceDto Execute();
    }
    public class GetAllSendInformationService : IGetAllSendInformationService
    {
        private readonly IDataBaseContext _context;
        public GetAllSendInformationService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllSendInformationServiceDto Execute()
        {
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
                })
                .OrderByDescending(x => x.Status)
                .ToList();
            return new ResultGetAllSendInformationServiceDto
            {
                Result = result
            };
        }
    }
}
