using Endpoint.Website.Models.AddNews;
using Endpoint.Website.Models.AddUsers;
using Endpoint.Website.Models.Users;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.News.News.Commands.DeleteNews;
using IranFilmPort.Application.Services.News.News.Commands.PostNews;
using IranFilmPort.Application.Services.News.News.Commands.UpdateNews;
using IranFilmPort.Application.Services.News.News.Queries.GetAllNewsForAdmin;
using IranFilmPort.Application.Services.News.News.Queries.GetNews;
using IranFilmPort.Application.Services.News.News.Queries.GetNewsByFilterForAdmin;
using IranFilmPort.Application.Services.NewsCategories.Commands.DeleteNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Commands.PostNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Commands.UpdateNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategoriesBySubId;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsChildrenCategories;
using IranFilmPort.Application.Services.Users.Commands.PostUser;
using IranFilmPort.Application.Services.Users.Commands.UpdateUser;
using IranFilmPort.Application.Services.Users.Queries.GetAllUsers;
using IranFilmPort.Application.Services.Users.Queries.GetUserById;
using IranFilmPort.Common.Constants;
using IranFilmPort.Infranstructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public IActionResult AddUser(Guid? id, string? role)
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
        public IActionResult News(int page)
        {
            return View(_newsFacadePattern.GetAllNewsForAdminService.Execute(new RequestGetAllNewsForAdminServiceDto
            {
                CurrentPage = page
            }));
        }
        [HttpGet]
        public IActionResult NewsByFilterOnlyPublished(int page)
        {
            return View(_newsFacadePattern.GetNewsByFilterForAdminService.Execute(new RequestGetNewsByFilterForAdminServiceDto
            {
                CurrentPage = page,
                Filter = NewsStatusContants.Published,
            }));
        }
        [HttpGet]
        public IActionResult NewsByFilterOnlyFuture(int page)
        {
            return View(_newsFacadePattern.GetNewsByFilterForAdminService.Execute(new RequestGetNewsByFilterForAdminServiceDto
            {
                CurrentPage = page,
                Filter = NewsStatusContants.Future,
            }));
        }
        [HttpGet]
        public IActionResult AddNews(long? id)
        {
            if (id == null)
            {
                ModelAddNews modelAddNews = new ModelAddNews()
                {
                    GetNewsServiceDto = null,
                    ResultGetNewsParentCategoriesDto = _newsCategoriesFacadePattern.GetNewsParentCategories.Execute(),
                    ResultGetNewsChildrenCategoriesDto = null,
                };
                return View(modelAddNews);
            }
            else
            {
                var news = _newsFacadePattern.GetNewsService.Execute(new RequestGetNewsServiceDto
                {
                    IsAdmin = true,
                    UniqueCode = id
                });
                ModelAddNews modelAddNews = new ModelAddNews()
                {
                    GetNewsServiceDto = news,
                    ResultGetNewsParentCategoriesDto = _newsCategoriesFacadePattern.GetNewsParentCategories.Execute(),
                    ResultGetNewsChildrenCategoriesDto = _newsCategoriesFacadePattern.GetNewsChildrenCategories.Execute(new RequestGetNewsChildrenCategoriesDto
                    {
                        ParentId = (Guid)news.ParentCategoryId
                    })
                };
                return View(modelAddNews);
            }
        }
        [HttpPut]
        public IActionResult UpdateNews(RequestUpdateNewsServiceDto req)
        {
            if (Request.Form.Files.Count > 0) req.MainImage = Request.Form.Files[0];
            return Json(_newsFacadePattern.UpdateNewsService.Execute(req));
        }
        [HttpPut]
        public IActionResult DeleteNews(RequestDeleteNewsServiceDto req)
        {
            return Json(_newsFacadePattern.DeleteNewsService.Execute(req));
        }
        [HttpPost]
        public IActionResult PostNews(RequestPostNewsServiceDto req)
        {
            return Json(_newsFacadePattern.PostNewsService.Execute(req));
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
        [HttpGet]
        public IActionResult GetNewsCategoriesBySubId(RequestGetNewsChildrenCategoriesDto req)
        {
            var result = _newsCategoriesFacadePattern.GetNewsChildrenCategories.Execute(req);
            return Json(result);
        }

        // CKeditor
        [HttpPost]
        public async Task<IActionResult> UploadNewsMiddlePost(IFormFile upload)
        {
            if (upload != null && upload.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetFileName(upload.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedStuff/ckeditor-uploads-news", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Ensure directory exists

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await upload.CopyToAsync(stream);
                }

                var url = $"/UploadedStuff/ckeditor-uploads-news/{fileName}";
                return Json(new { uploaded = 1, url });
            }

            return Json(new { uploaded = 0, error = new { message = "مشکل در آپلود." } });
        }
        [HttpGet]
        public IActionResult AdminNewsImageBrower()
        {
            // Serve a view that lists images in your uploads folder
            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedStuff/ckeditor-uploads-news    ");
            var images = Directory.GetFiles(imageFolder)
                                  .Select(file => new FileInfo(file).Name)
                                  .ToList();

            return View(images);
        }
    }
}
