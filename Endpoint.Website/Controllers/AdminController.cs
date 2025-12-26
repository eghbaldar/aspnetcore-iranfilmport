using Endpoint.Website.Models.AddUsers;
using Endpoint.Website.Models.NewsCategories;
using Endpoint.Website.Models.Users;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.News.News.Queries.GetNews;
using IranFilmPort.Application.Services.NewsCategories.Commands.DeleteNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Commands.PostNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Commands.UpdateNewsCategory;
using IranFilmPort.Application.Services.Users.Commands.PostUser;
using IranFilmPort.Application.Services.Users.Commands.UpdateUser;
using IranFilmPort.Application.Services.Users.Queries.GetAllUsers;
using IranFilmPort.Application.Services.Users.Queries.GetUserById;
using IranFilmPort.Infranstructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using Role = IranFilmPort.Common.Enums.KingAttributeEnum.UserRole;

namespace Endpoint.Website.Controllers
{
    [KingAuthorize(Role.King, Role.SuperAdmin, Role.Admin)]
    public class AdminController : Controller
    {
        private readonly IUsersFacadePattern _usersFacadePattern;
        private readonly IRoleFacadePattern _roleFacadePattern;
        private readonly INewsFacadePattern _newsFacadePattern;
        private readonly INewsCategoriesFacadePattern _newsCategoriesFacadePattern;
        private readonly INewsCommentsFacadePattern _newsCommentsFacadePattern;
        public AdminController(IUsersFacadePattern usersFacadePattern,
            IRoleFacadePattern roleFacadePattern,
            INewsFacadePattern newsFacadePattern,
            INewsCategoriesFacadePattern newsCategoriesFacadePattern,
            INewsCommentsFacadePattern newsCommentsFacadePattern)
        {
            _usersFacadePattern = usersFacadePattern;
            _roleFacadePattern = roleFacadePattern;
            _newsFacadePattern = newsFacadePattern;
            _newsCategoriesFacadePattern = newsCategoriesFacadePattern;
            _newsCommentsFacadePattern = newsCommentsFacadePattern;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddUser(Guid? id,string? role)
        {
            ModelAddUsers modelAddUsers = new ModelAddUsers()
            {
                GetUserByIdServiceDto = _usersFacadePattern.GetUserByIdService.Execute(new RequestGetUserByIdServiceDto
                {
                    Id = id
                }),
                ResultGetAllRolesServiceDto = _roleFacadePattern.GetAllRolesService.Execute(),
                RoleTitle = role
            };
            return View(modelAddUsers);
        }
        public IActionResult Users(string id)
        {
            // {id} contains: admins,clients,users
            ModelUsers modelUsers = new ModelUsers()
            {
                ResultGetAllUsersServiceDto = _usersFacadePattern.GetAllUsersService.Execute(new RequestGetAllUsersServiceDto
                {
                    RoleTitle = id
                }),
                RoleTitle = id,
            };
            return View(modelUsers);
        }
        [HttpPost]
        public IActionResult PostAddUser(RequestPostUserServiceDto req)
        {
            if (req == null) BadRequest();
            return Json(_usersFacadePattern.PostUserService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateUser(RequestUpdateUserServiceDto req)
        {
            if (req == null) BadRequest();
            return Json(_usersFacadePattern.UpdateUserService.Execute(req));
        }
        [HttpGet]
        public IActionResult News()
        {
            return View(_newsFacadePattern.GetAllNewsForAdminService.Execute());
        }
        [HttpGet]
        public IActionResult AddNews(long? id)
        {
            return View(_newsFacadePattern.GetNewsService.Execute(new RequestGetNewsServiceDto
            {
                IsAdmin = true,
                UniqueCode = id
            }));
        }
        [HttpGet]
        public IActionResult NewsComments()
        {
            return View(_newsCommentsFacadePattern.GetNewsCommentsService.Execute());
        }
        [HttpGet]
        public IActionResult NewsCategories()
        {
            return View(_newsCategoriesFacadePattern.GetNewsCategoriesService.Execute());
        }
        [HttpPost]
        public IActionResult PostNewsCategory(RequestPostNewsCategoryServiceDto req)
        {
            return Json(_newsCategoriesFacadePattern.PostNewsCategoryService.Execute(req));
        }
        [HttpPut]
        public IActionResult DeleteNewsCategory(RequestDeleteNewsCategoryServiceDto req)
        {
            return Json(_newsCategoriesFacadePattern.DeleteNewsCategoryService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateNewsCategory(RequestUpdateNewsCategoryServiceDto req)
        {
            return Json(_newsCategoriesFacadePattern.UpdateNewsCategoryService.Execute(req));
        }
    }
}
