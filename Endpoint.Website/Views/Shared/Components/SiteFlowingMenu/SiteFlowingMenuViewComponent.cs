using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Website.Views.Shared.Components.SiteFlowingMenu
{
    public class SiteFlowingMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("index");
        }
    }
}
