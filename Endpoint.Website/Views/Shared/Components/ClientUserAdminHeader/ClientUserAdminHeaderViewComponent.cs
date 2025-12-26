using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Website.Views.Shared.Components.ClientUserAdminHeadaer
{
    public class ClientUserAdminHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("index");
        }
    }
}
