using IranFilmPort.Application.Services.Accolades.Commands.PostAccolade;
using IranFilmPort.Application.Services.Accolades.Commands.UpdateAccolade;
using IranFilmPort.Application.Services.Accolades.Queries.GetAccoladeById;
using IranFilmPort.Application.Services.Accolades.Queries.GetAllAccolades;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IAccoladesFacadePattern
    {
        public GetAllAccoladesService GetAllAccoladesService { get; }
        public GetAccoladeByIdService GetAccoladeByIdService { get; }
        public PostAccoladeService PostAccoladeService { get; }
        public UpdateAccoladeService UpdateAccoladeService { get; }
    }
}
