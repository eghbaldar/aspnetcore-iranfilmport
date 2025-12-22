using Microsoft.AspNetCore.Mvc;


namespace Endpoint.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
