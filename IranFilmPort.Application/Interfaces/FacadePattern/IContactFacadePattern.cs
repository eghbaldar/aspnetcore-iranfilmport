using IranFilmPort.Application.Services.Contacts.Commands.PostContact;
using IranFilmPort.Application.Services.Contacts.Commands.UpdateContactStatus;
using IranFilmPort.Application.Services.Contacts.Queries.GetAllContacts;
using IranFilmPort.Application.Services.Contacts.Queries.GetContact;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IContactFacadePattern
    {
        public UpdateContactStatus UpdateContactStatus { get;}
        public PostContactService PostContactService { get;}
        public GetAllContactsService GetAllContactsService { get;}
        public GetContactService GetContactService { get;}
    }
}
