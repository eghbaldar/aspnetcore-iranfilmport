using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Contacts.Commands.PostContact;
using IranFilmPort.Application.Services.Contacts.Commands.UpdateContactStatus;
using IranFilmPort.Application.Services.Contacts.Queries.GetAllContacts;
using IranFilmPort.Application.Services.Contacts.Queries.GetContact;
using IranFilmPort.Application.Services.Countires.Queries.GetAllCountries;

namespace IranFilmPort.Application.Services.Contacts.FacadePattern
{
    public class ContactFacadePattern: IContactFacadePattern
    {
        private readonly IDataBaseContext _context;
        public ContactFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // UpdateContactStatus
        public UpdateContactStatus _updateContactStatus;
        public UpdateContactStatus UpdateContactStatus
        {
            get { return _updateContactStatus = _updateContactStatus ?? new UpdateContactStatus(_context); }
        }
        // PostContactService
        public PostContactService _postContactService;
        public PostContactService PostContactService
        {
            get { return _postContactService = _postContactService ?? new PostContactService(_context); }
        }
        // GetAllContactsService
        public GetAllContactsService _getAllContactsService;
        public GetAllContactsService GetAllContactsService
        {
            get { return _getAllContactsService = _getAllContactsService ?? new GetAllContactsService(_context); }
        }
        // GetContactService
        public GetContactService _getContactService;
        public GetContactService GetContactService
        {
            get { return _getContactService = _getContactService ?? new GetContactService(_context); }
        }
    }
}