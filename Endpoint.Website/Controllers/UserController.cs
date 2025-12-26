using IranFilmPort.Infranstructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using Role = IranFilmPort.Common.Enums.KingAttributeEnum.UserRole;

namespace Endpoint.Website.Controllers
{
    [KingAuthorize(Role.King, Role.SuperAdmin, Role.User)]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
