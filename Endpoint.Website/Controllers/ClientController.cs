using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Website.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
