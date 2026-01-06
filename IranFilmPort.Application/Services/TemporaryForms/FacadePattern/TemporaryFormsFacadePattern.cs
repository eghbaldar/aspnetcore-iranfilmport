using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.TemporaryForms.Commands.PostTemporaryForm;

namespace IranFilmPort.Application.Services.TemporaryForms.FacadePattern
{
    public class TemporaryFormsFacadePattern: ITemporaryFormsFacadePattern
    {
        private readonly IDataBaseContext _context;
        public TemporaryFormsFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // PostTemporaryFormService
        public PostTemporaryFormService _postTemporaryFormService;
        public PostTemporaryFormService PostTemporaryFormService
        {
            get { return _postTemporaryFormService = _postTemporaryFormService ?? new PostTemporaryFormService(_context); }
        }
    }
}
