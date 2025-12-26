using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Website.Views.Shared.Components.ClientUserAdminLeftSide
{
    public class ClientUserAdminLeftSideViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("index");
        }
    }
}
