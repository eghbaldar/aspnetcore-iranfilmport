using IranFilmPort.Application.Services.SendInformation.Commands.PostSendInformation;
using IranFilmPort.Application.Services.SendInformation.Commands.UpdateSendInformationStatusByAdmin;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface ISendInformationFacadePattern
    {
        public PostSendInformationService PostSendInformationService { get;  }
        public UpdateSendInformationStatusByAdminService UpdateSendInformationStatusByAdminService { get;  }
    }
}
