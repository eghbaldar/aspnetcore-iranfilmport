using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.SendInformation.Commands.PostSendInformation;
using IranFilmPort.Application.Services.SendInformation.Commands.UpdateSendInformationStatusByAdmin;
using IranFilmPort.Application.Services.SendInformation.Queries.GetAllSendInformation;

namespace IranFilmPort.Application.Services.SendInformation.FacadePattern
{
    public class SendInformationFacadePattern: ISendInformationFacadePattern
    {
        private readonly IDataBaseContext _context;

        public SendInformationFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // PostSendInformationService
        public PostSendInformationService _postSendInformationService;
        public PostSendInformationService PostSendInformationService
        {
            get { return _postSendInformationService = _postSendInformationService ?? new PostSendInformationService(_context); }
        }
        // UpdateSendInformationStatusByAdminService
        public UpdateSendInformationStatusByAdminService _updateSendInformationStatusByAdminService;
        public UpdateSendInformationStatusByAdminService UpdateSendInformationStatusByAdminService
        {
            get { return _updateSendInformationStatusByAdminService = _updateSendInformationStatusByAdminService ?? new UpdateSendInformationStatusByAdminService(_context); }
        }
        // GetAllSendInformationService
        public GetAllSendInformationService _getAllSendInformationService;
        public GetAllSendInformationService GetAllSendInformationService
        {
            get { return _getAllSendInformationService = _getAllSendInformationService ?? new GetAllSendInformationService(_context); }
        }
    }
}
