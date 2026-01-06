using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.NewsLetters.Commands.PostNewsletter;
using IranFilmPort.Application.Services.NewsLetters.Queries.GetAllNewsletters;

namespace IranFilmPort.Application.Services.NewsLetters.FacadePattern
{
    public class NewslettersFacadePattern: INewslettersFacadePattern
    {
        private readonly IDataBaseContext _context;
        public NewslettersFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // PostNewsletter
        public PostNewsletter _postNewsletter;
        public PostNewsletter PostNewsletter
        {
            get { return _postNewsletter = _postNewsletter ?? new PostNewsletter(_context); }
        }
        // GetAllNewslettersService
        public GetAllNewslettersService _getAllNewslettersService;
        public GetAllNewslettersService GetAllNewslettersService
        {
            get { return _getAllNewslettersService = _getAllNewslettersService ?? new GetAllNewslettersService(_context); }
        }
    }
}
