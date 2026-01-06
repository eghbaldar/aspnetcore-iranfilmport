using IranFilmPort.Application.Services.SendInformation.Commands.PostSendInformation;
using IranFilmPort.Application.Services.SendInformation.Commands.UpdateSendInformationStatusByAdmin;
using IranFilmPort.Application.Services.SendInformation.Queries.GetAllSendInformation;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface ISendInformationFacadePattern
    {
        public PostSendInformationService PostSendInformationService { get;  }
        public UpdateSendInformationStatusByAdminService UpdateSendInformationStatusByAdminService { get;  }
        public GetAllSendInformationService GetAllSendInformationService { get;  }
    }
}
