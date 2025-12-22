using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Website.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
