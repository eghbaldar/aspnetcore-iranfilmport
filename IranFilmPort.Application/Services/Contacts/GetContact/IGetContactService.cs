using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Contacts.GetContact
{
    public class RequestGetContactServiceDto
    {
        public Guid Id { get; set; }
    }
    public class GetContactServiceDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string IP { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public interface IGetContactService
    {
        GetContactServiceDto Execute(RequestGetContactServiceDto req);
    }
    public class GetContactService : IGetContactService
    {
        private readonly IDataBaseContext _context;
        public GetContactService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetContactServiceDto Execute(RequestGetContactServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty) return null;
            var contact = _context.Contacts
                .Where(x => x.Id == req.Id)
                .Select(x => new GetContactServiceDto
                {
                    Email = x.Email,
                    IP = x.IP,
                    Fullname = x.Fullname,
                    InsertDateTime = x.InsertDateTime,
                    Status = x.Status,
                    Message = x.Message
                })
                .FirstOrDefault();
            if (contact == null) return null;
            // update [read] property
            contact.Status = true;
            if (_context.SaveChanges() >= 0) return contact;
            else return null;
        }
    }
}
