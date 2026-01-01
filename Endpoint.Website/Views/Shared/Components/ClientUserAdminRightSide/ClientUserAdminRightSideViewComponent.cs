using IranFilmPort.Application.Interfaces.FacadePattern;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Website.Views.Shared.Components.ClientUserAdminRightSide
{
    public class ClientUserAdminRightSideViewComponent : ViewComponent
    {
        private readonly IAdminStuffFacadePattern _adminStuffFacadePattern;
        public ClientUserAdminRightSideViewComponent(IAdminStuffFacadePattern adminStuffFacadePattern)
        {
            _adminStuffFacadePattern = adminStuffFacadePattern;
        }
        public IViewComponentResult Invoke()
        {
            return View("index", _adminStuffFacadePattern.GetPanelNotificationService.Execute());
        }
    }
}
