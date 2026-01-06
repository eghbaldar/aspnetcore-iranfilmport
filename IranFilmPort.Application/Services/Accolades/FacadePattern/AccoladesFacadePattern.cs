using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Interfaces.FacadePatternDapper;
using IranFilmPort.Application.Services.Accolades.Commands.PostAccolade;
using IranFilmPort.Application.Services.Accolades.Commands.UpdateAccolade;
using IranFilmPort.Application.Services.Accolades.Queries.GetAccoladeById;
using IranFilmPort.Application.Services.Accolades.Queries.GetAllAccolades;

namespace IranFilmPort.Application.Services.Accolades.FacadePattern
{
    public class AccoladesFacadePattern: IAccoladesFacadePattern
    {
        private readonly IDataBaseContext _context;
        private readonly IFilmFacadePatternDapper _filmFacadePatternDapper;
        public AccoladesFacadePattern(IDataBaseContext context, IFilmFacadePatternDapper filmFacadePatternDapper)
        {
            _context = context;
            _filmFacadePatternDapper = filmFacadePatternDapper;
        }
        // GetAllAccoladesService
        public GetAllAccoladesService _getAllAccoladesService;
        public GetAllAccoladesService GetAllAccoladesService
        {
            get { return _getAllAccoladesService = _getAllAccoladesService ?? new GetAllAccoladesService(_context, _filmFacadePatternDapper); }
        }
        // GetAccoladeByIdService
        public GetAccoladeByIdService _getAccoladeByIdService;
        public GetAccoladeByIdService GetAccoladeByIdService
        {
            get { return _getAccoladeByIdService = _getAccoladeByIdService ?? new GetAccoladeByIdService(_context); }
        }
        // PostAccoladeService
        public PostAccoladeService _postAccoladeService;
        public PostAccoladeService PostAccoladeService
        {
            get { return _postAccoladeService = _postAccoladeService ?? new PostAccoladeService(_context); }
        }
        // UpdateAccoladeService
        public UpdateAccoladeService _updateAccoladeService;
        public UpdateAccoladeService UpdateAccoladeService
        {
            get { return _updateAccoladeService = _updateAccoladeService ?? new UpdateAccoladeService(_context); }
        }        
    }
}
