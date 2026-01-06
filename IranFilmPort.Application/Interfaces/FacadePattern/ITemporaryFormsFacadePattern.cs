using IranFilmPort.Application.Services.TemporaryForms.Commands.PostTemporaryForm;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface ITemporaryFormsFacadePattern
    {
        public PostTemporaryFormService PostTemporaryFormService { get; }
    }
}
