using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Website.Views.Shared.Components.SiteTopHeader
{
    public class SiteTopHeaderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("index");
        }
    }
}
