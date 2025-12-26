using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Contacts.GetAllContacts
{
    public class GetAllContactsServiceDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string IP { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetAllContactsServiceDto
    {
        public List<GetAllContactsServiceDto> Result { get; set; }
    }
    public interface IGetAllContactsService
    {
        ResultGetAllContactsServiceDto Execute();
    }
    public class GetAllContactsService : IGetAllContactsService
    {
        private readonly IDataBaseContext _context;
        public GetAllContactsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllContactsServiceDto Execute()
        {
            var contacts = _context.Contacts
                .Select(x => new GetAllContactsServiceDto
                {
                    Email = x.Email,
                    IP = x.IP,
                    Fullname = x.Fullname,
                    InsertDateTime = x.InsertDateTime,
                    Status = x.Status,
                    Message = x.Message
                })
                .OrderByDescending(x => x.Status)
                .ToList();
            return new ResultGetAllContactsServiceDto
            {
                Result = contacts
            };
        }
    }
}
