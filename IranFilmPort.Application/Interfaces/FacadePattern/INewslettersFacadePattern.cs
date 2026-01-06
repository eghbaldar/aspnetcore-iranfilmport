using IranFilmPort.Application.Services.NewsLetters.Commands.PostNewsletter;
using IranFilmPort.Application.Services.NewsLetters.Queries.GetAllNewsletters;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface INewslettersFacadePattern
    {
        public PostNewsletter PostNewsletter { get; }
        public GetAllNewslettersService GetAllNewslettersService { get; }
    }
}
