using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Website.Views.Shared.Components.SiteFooter
{
    public class SiteFooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("index");
        }
    }
}
