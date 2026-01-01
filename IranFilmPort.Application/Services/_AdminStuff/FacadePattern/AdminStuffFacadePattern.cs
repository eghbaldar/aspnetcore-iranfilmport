using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services._AdminStuff.Queries.GetPanelNotification;

namespace IranFilmPort.Application.Services._AdminStuff.FacadePattern
{
    public class AdminStuffFacadePattern : IAdminStuffFacadePattern
    {
        private readonly IDataBaseContext _context;
        public AdminStuffFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // GetPanelNotificationServiceDto
        public GetPanelNotificationService _getPanelNotificationService;
        public GetPanelNotificationService GetPanelNotificationService
        {
            get { return _getPanelNotificationService = _getPanelNotificationService ?? new GetPanelNotificationService(_context); }
        }
    }
}
