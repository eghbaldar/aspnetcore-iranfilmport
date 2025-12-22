using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Website.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
