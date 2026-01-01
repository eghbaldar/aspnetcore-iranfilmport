using Endpoint.Website.Utilities.Claim;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Users.Commands.UpdateHeadshot;
using IranFilmPort.Application.Services.Users.Commands.UpdateInfoUser;
using IranFilmPort.Application.Services.Users.Commands.UpdateMeliCard;
using IranFilmPort.Application.Services.Users.Queries.GetUserById;
using IranFilmPort.Infranstructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Role = IranFilmPort.Common.Enums.KingAttributeEnum.UserRole;
namespace Endpoint.Website.Controllers
{
    [KingAuthorize(Role.King, Role.SuperAdmin, Role.Admin, Role.Client, Role.User)]
    public class CommonController : Controller
    {
        private readonly IUsersFacadePattern _usersFacadePattern;
        public CommonController(IUsersFacadePattern usersFacadePattern)
        {
            _usersFacadePattern = usersFacadePattern;
        }
        public IActionResult Information()
        {
            return View(_usersFacadePattern.GetUserByIdService.Execute(new RequestGetUserByIdServiceDto
            {
                Id = ClaimUtility.GetUserId(User as ClaimsPrincipal)
            }));
        }
        [HttpPut]
        public IActionResult UpdateInformationUser(RequestUpdateInfoUserServiceDto req)
        {
            req.UserId = ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_usersFacadePattern.UpdateInfoUserService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateHeadshotUser(RequestUpdateHeadshotServiceDto req)
        {
            req.UserId = ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_usersFacadePattern.UpdateHeadshotService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateMeliCardUser(RequestUpdateMeliCardServiceDto req)
        {
            req.UserId = ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_usersFacadePattern.UpdateMeliCardService.Execute(req));
        }
    }
}
