using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Website.Views.Shared.Components.ClientUserAdminRightSide
{
    public class ClientUserAdminRightSideViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("index");
        }
    }
}
