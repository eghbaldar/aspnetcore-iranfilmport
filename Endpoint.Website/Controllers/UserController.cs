using Endpoint.Website.Utilities.Claim;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.UserProjectPhotos.Commands.PostUserProjectPhoto;
using IranFilmPort.Application.Services.UserProjects.Commands.PostUserProject;
using IranFilmPort.Application.Services.UserProjects.Commands.UpdateUserProject;
using IranFilmPort.Application.Services.UserProjects.Queries.GetAllProjectsByUserId;
using IranFilmPort.Infranstructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Role = IranFilmPort.Common.Enums.KingAttributeEnum.UserRole;

namespace Endpoint.Website.Controllers
{
    [KingAuthorize(Role.King, Role.SuperAdmin, Role.User, Role.Client)]
    public class UserController : Controller
    {
        private readonly IUserProjectsFacadePattern _userProjectsFacadePattern;
        private readonly IUserProjectPhotosFacadePattern _userProjectPhotosFacadePattern;
        public UserController(IUserProjectsFacadePattern userProjectsFacadePattern, IUserProjectPhotosFacadePattern userProjectPhotosFacadePattern)
        {
            _userProjectsFacadePattern = userProjectsFacadePattern;
            _userProjectPhotosFacadePattern = userProjectPhotosFacadePattern;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View(_userProjectsFacadePattern.GetAllProjectsByUserIdService.Execute(new RequestGetAllProjectsByUserIdServiceDto
            {
                UserId = ClaimUtility.GetUserId(User as ClaimsPrincipal)
            }));
        }
        public IActionResult AddProject(Guid? id)
        {
            return View(_userProjectsFacadePattern.GetUserProjectForUserService.Execute(new IranFilmPort.Application.Services.UserProjects.Queries.GetUserProjectForUser.RequestGetUserProjectForUserServiceDto
            {
                Id = id,
                UserId = ClaimUtility.GetUserId(User as ClaimsPrincipal)
            }));
        }
        [HttpPost]
        public async Task<IActionResult> PostProject(RequestPostUserProjectServiceDto req)
        {
            req.UserId = ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(await _userProjectsFacadePattern.PostUserProjectService.Execute(req));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProject(RequestUpdateUserProjectServiceDto req)
        {
            req.UserId = ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(await _userProjectsFacadePattern.UpdateUserProjectService.Execute(req));
        }
        public IActionResult ProjectPhotos(Guid id)
        {
            return View(_userProjectPhotosFacadePattern.GetAllUserProjectPhotosByUserIdService.Execute(new IranFilmPort.Application.Services.UserProjectPhotos.Queries.GetAllUserProjectPhotosByUserId.RequestGetAllUserProjectPhotosByUserIdServiceDto
            {
                ProjectId = id,
                UserId = ClaimUtility.GetUserId(User as ClaimsPrincipal)
            }));
        }
        [HttpPost]
        public IActionResult PostProjectPhoto(RequestPostUserProjectPhotoServiceDto req)
        {
            req.UserId = ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProjectPhotosFacadePattern.PostUserProjectPhotoService.Execute(req));
        }
    }
}
