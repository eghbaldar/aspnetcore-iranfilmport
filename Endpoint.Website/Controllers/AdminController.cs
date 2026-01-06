using Endpoint.Website.Models.Accolades;
using Endpoint.Website.Models.AddAccolade;
using Endpoint.Website.Models.AddFestival;
using Endpoint.Website.Models.AddNews;
using Endpoint.Website.Models.AddUsers;
using Endpoint.Website.Models.FestivalSectionDeadline;
using Endpoint.Website.Models.Users;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Interfaces.FacadePatternDapper;
using IranFilmPort.Application.Services.Accolades.Commands.PostAccolade;
using IranFilmPort.Application.Services.Accolades.Commands.UpdateAccolade;
using IranFilmPort.Application.Services.Accolades.Queries.GetAccoladeById;
using IranFilmPort.Application.Services.Accolades.Queries.GetAllAccolades;
using IranFilmPort.Application.Services.Contacts.Commands.UpdateContactStatus;
using IranFilmPort.Application.Services.Courses.Commands.PostCourse;
using IranFilmPort.Application.Services.Courses.Commands.UpdateCourse;
using IranFilmPort.Application.Services.Courses.Queries.GetCourseById;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.DeleteFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.PostFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Commands.UpdateFestivalDeadline;
using IranFilmPort.Application.Services.FestivalDeadlines.Queries.GetDeadlinesByFestivalId;
using IranFilmPort.Application.Services.Festivals.Commands.DeleteFestival;
using IranFilmPort.Application.Services.Festivals.Commands.PostFestival;
using IranFilmPort.Application.Services.Festivals.Commands.UpdateFestival;
using IranFilmPort.Application.Services.Festivals.Queries.GetAllFestivalsForAdminService;
using IranFilmPort.Application.Services.Festivals.Queries.GetIdByUniqueCode;
using IranFilmPort.Application.Services.FestivalSection.Commands.DeleteSectionFestival;
using IranFilmPort.Application.Services.FestivalSection.Commands.PostFestivalSection;
using IranFilmPort.Application.Services.FestivalSection.Commands.UpdateFestivalSection;
using IranFilmPort.Application.Services.FestivalSection.Queries.GetSectionsByFestivalId;
using IranFilmPort.Application.Services.News.News.Commands.DeleteNews;
using IranFilmPort.Application.Services.News.News.Commands.PostNews;
using IranFilmPort.Application.Services.News.News.Commands.UpdateNews;
using IranFilmPort.Application.Services.News.News.Queries.GetAllNewsForAdmin;
using IranFilmPort.Application.Services.News.News.Queries.GetNews;
using IranFilmPort.Application.Services.News.News.Queries.GetNewsByFilterForAdmin;
using IranFilmPort.Application.Services.NewsCategories.Commands.DeleteNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Commands.PostNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Commands.UpdateNewsCategory;
using IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsChildrenCategories;
using IranFilmPort.Application.Services.SendInformation.Commands.UpdateSendInformationStatusByAdmin;
using IranFilmPort.Application.Services.SendInformation.Queries.GetAllSendInformation;
using IranFilmPort.Application.Services.Settings.Commands.UpdateSettings;
using IranFilmPort.Application.Services.Sliders.Commands.DeleteSlider;
using IranFilmPort.Application.Services.Sliders.Commands.PostSlider;
using IranFilmPort.Application.Services.Sliders.Commands.UpdateSlider;
using IranFilmPort.Application.Services.Testimonals.Commands.DeleteTestimonal;
using IranFilmPort.Application.Services.Testimonals.Commands.PostTestimonal;
using IranFilmPort.Application.Services.Testimonals.Queries.GetAllTestimonials;
using IranFilmPort.Application.Services.UserProjectPhotos.Commands.UpdateUserProjectPhotoStatus;
using IranFilmPort.Application.Services.UserProjects.Commands.UpdateUserProjectStatus;
using IranFilmPort.Application.Services.UserProjects.Queries.GetUserProjectByIdForAdmin;
using IranFilmPort.Application.Services.Users.Commands.PostUser;
using IranFilmPort.Application.Services.Users.Commands.UpdateHeadshotByAdmin;
using IranFilmPort.Application.Services.Users.Commands.UpdateMeliCardByAdmin;
using IranFilmPort.Application.Services.Users.Commands.UpdateProfileByAdmin;
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
        // efcore
        private readonly IUsersFacadePattern _usersFacadePattern;
        private readonly IRoleFacadePattern _roleFacadePattern;
        private readonly INewsFacadePattern _newsFacadePattern;
        private readonly INewsCategoriesFacadePattern _newsCategoriesFacadePattern;
        private readonly INewsCommentsFacadePattern _newsCommentsFacadePattern;
        private readonly IFestivalsFacadePattern _festivalsFacadePattern;
        private readonly IFestivalSectionFacadePattern _festivalSectionFacadePattern;
        private readonly IFestivalDeadlinesFacadePattern _festivalDeadlinesFacadePattern;
        private readonly ICountiresFacadePattern _countiresFacadePattern;
        private readonly IUserProjectsFacadePattern _userProjectsFacadePattern;
        private readonly IUserProjectPhotosFacadePattern _userProjectPhotosFacadePattern;
        private readonly ISettingsFacadePattern _settingsFacadePattern;
        private readonly ISendInformationFacadePattern _sendInformationFacadePattern;
        private readonly ISlidersFacadePattern _slidersFacadePattern;
        private readonly ITestimonalsFacadePattern _testimonalsFacadePattern;
        private readonly IAccoladesFacadePattern _accoladesFacadePattern;
        private readonly IContactFacadePattern _contactFacadePattern;
        private readonly INewslettersFacadePattern _newslettersFacadePattern;
        private readonly ICoursesFacadePattern _coursesFacadePattern;
        // dapper
        private readonly IFilmFacadePatternDapper _filmFacadePatternDapper;

        public AdminController(IUsersFacadePattern usersFacadePattern,
            IRoleFacadePattern roleFacadePattern,
            INewsFacadePattern newsFacadePattern,
            INewsCategoriesFacadePattern newsCategoriesFacadePattern,
            INewsCommentsFacadePattern newsCommentsFacadePattern,
            IFestivalsFacadePattern festivalsFacadePattern,
            IFestivalSectionFacadePattern festivalSectionFacadePattern,
            IFestivalDeadlinesFacadePattern festivalDeadlinesFacadePattern,
            ICountiresFacadePattern countiresFacadePattern,
            IUserProjectsFacadePattern userProjectsFacadePattern,
            IUserProjectPhotosFacadePattern userProjectPhotosFacadePattern,
            ISettingsFacadePattern settingsFacadePattern,
            ISendInformationFacadePattern sendInformationFacadePattern,
            ISlidersFacadePattern slidersFacadePattern,
            ITestimonalsFacadePattern testimonalsFacadePattern,
            IFilmFacadePatternDapper filmFacadePatternDapper,
            IAccoladesFacadePattern accoladesFacadePattern,
            IContactFacadePattern contactFacadePattern,
            INewslettersFacadePattern newslettersFacadePattern,
            ICoursesFacadePattern coursesFacadePattern)
        {
            _usersFacadePattern = usersFacadePattern;
            _roleFacadePattern = roleFacadePattern;
            _newsFacadePattern = newsFacadePattern;
            _newsCategoriesFacadePattern = newsCategoriesFacadePattern;
            _newsCommentsFacadePattern = newsCommentsFacadePattern;
            _festivalsFacadePattern = festivalsFacadePattern;
            _festivalSectionFacadePattern = festivalSectionFacadePattern;
            _festivalDeadlinesFacadePattern = festivalDeadlinesFacadePattern;
            _countiresFacadePattern = countiresFacadePattern;
            _userProjectsFacadePattern = userProjectsFacadePattern;
            _userProjectPhotosFacadePattern = userProjectPhotosFacadePattern;
            _settingsFacadePattern = settingsFacadePattern;
            _sendInformationFacadePattern = sendInformationFacadePattern;
            _slidersFacadePattern = slidersFacadePattern;
            _testimonalsFacadePattern = testimonalsFacadePattern;
            _filmFacadePatternDapper = filmFacadePatternDapper;
            _accoladesFacadePattern = accoladesFacadePattern;
            _contactFacadePattern = contactFacadePattern;
            _newslettersFacadePattern = newslettersFacadePattern;
            _coursesFacadePattern = coursesFacadePattern;
        }
        public IActionResult Index()
        {
            return View();
        }

        // User
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

        // News
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

        // Festivals
        [HttpGet]
        public IActionResult Festivals(int page)
        {
            return View(_festivalsFacadePattern.GetAllFestivalsForAdminService.Execute(new RequestGetAllFestivalsForAdminServiceDto
            {
                CurrentPage = page
            }));
        }
        [HttpGet]
        public IActionResult AddFestival(int? id)
        {
            if (id == null)
            {
                ModelAddFestival modelAddFestival = new ModelAddFestival()
                {
                    GetFestivalServiceDto = null,
                    ResultGetAllCountriesServiceDto = _countiresFacadePattern.GetAllCountriesService.Execute(),
                };
                return View(modelAddFestival);
            }
            else
            {
                ModelAddFestival modelAddFestival = new ModelAddFestival()
                {
                    ResultGetAllCountriesServiceDto = _countiresFacadePattern.GetAllCountriesService.Execute(),
                    GetFestivalServiceDto = _festivalsFacadePattern.GetFestivalService.Execute(new IranFilmPort.Application.Services.Festivals.Queries.GetFestival.RequestGetFestivalServiceDto
                    {
                        UniqueCode = (int)id
                    })
                };
                return View(modelAddFestival);
            }
        }
        [HttpPost]
        public IActionResult PostFestival(RequestPostFestivalServiceDto req)
        {
            return Json(_festivalsFacadePattern.PostFestivalService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateFestival(RequestUpdateFestivalServiceDto req)
        {
            return Json(_festivalsFacadePattern.UpdateFestivalService.Execute(req));
        }
        [HttpPut]
        public IActionResult DeleteFestival(RequestDeleteFestivalServiceDto req)
        {
            return Json(_festivalsFacadePattern.DeleteFestivalService.Execute(req));
        }
        [HttpGet]
        public IActionResult FestivalSectionDeadline(int id)
        {
            ModelFestivalSectionDeadline modelFestivalSectionDeadline = new ModelFestivalSectionDeadline()
            {
                UniqueCode = id,
                ResultGetSectionsByFestivalIdServiceDto = _festivalSectionFacadePattern.GetSectionsByFestivalIdService.Execute(new RequestGetSectionsByFestivalIdServiceDto
                {
                    FestivalUniqueCode = id,
                }),
                ResultGetDeadlinesByFestivalIdServiceDto = _festivalDeadlinesFacadePattern.GetDeadlinesByFestivalIdService.Execute(new RequestGetDeadlinesByFestivalIdServiceDto
                {
                    FestivalUniqueCode = id
                }),
                FestivalId = _festivalsFacadePattern.GetIdByUniqueCodeService.Execute(new RequestGetIdByUniqueCodeDto
                {
                    UniqueCode = id
                })
            };
            return View(modelFestivalSectionDeadline);
        }
        [HttpPost]
        public IActionResult PostFestivalSection(RequestPostFestivalSectionServiceDto req)
        {
            return Json(_festivalSectionFacadePattern.PostFestivalSectionService.Execute(req));
        }
        [HttpPost]
        public IActionResult PostFestivalDeadline(RequestPostFestivalDeadlineServiceDto req)
        {
            return Json(_festivalDeadlinesFacadePattern.PostFestivalDeadlineService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateFestivalSection(RequestUpdateFestivalSectionServiceDto req)
        {
            return Json(_festivalSectionFacadePattern.UpdateFestivalSectionService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateFestivalDeadline(RequestUpdateFestivalDeadlineServiceDto req)
        {
            return Json(_festivalDeadlinesFacadePattern.UpdateFestivalDeadlineService.Execute(req));
        }
        [HttpPut]
        public IActionResult DeleteFestivalSection(RequestDeleteSectionFestivalServiceDto req)
        {
            return Json(_festivalSectionFacadePattern.DeleteSectionFestivalService.Execute(req));
        }
        [HttpPut]
        public IActionResult DeleteFestivalDeadline(RequestDeleteFestivalDeadlineServiceDto req)
        {
            return Json(_festivalDeadlinesFacadePattern.DeleteFestivalDeadlineService.Execute(req));
        }
        [HttpGet]
        public IActionResult UserHeadshotVerifications()
        {
            return View(_usersFacadePattern.GetUserHeadshotsService.Execute());
        }
        [HttpGet]
        public IActionResult UserMeliCardVerifications()
        {
            return View(_usersFacadePattern.GetUserMelicardsService.Execute());
        }
        [HttpGet]
        public IActionResult UserProfileVerifications()
        {
            return View(_usersFacadePattern.GetUserProfilesService.Execute());
        }
        [HttpPut]
        public IActionResult UpdateUserHeadshot(RequestUpdateHeadshotByAdminServiceDto req)
        {
            return Json(_usersFacadePattern.UpdateHeadshotByAdminService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateUserProfile(RequestUpdateProfileByAdminServiceDto req)
        {
            return Json(_usersFacadePattern.UpdateProfileByAdminService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateUserMeliCard(RequestUpdateMeliCardByAdminServiceDto req)
        {
            return Json(_usersFacadePattern.UpdateMeliCardByAdminService.Execute(req));
        }
        [HttpGet]
        public IActionResult UserProjectVerfications()
        {
            return View(_userProjectsFacadePattern.GetGetAllUserProjectsForAdminService.Execute());
        }

        // Projects
        [HttpGet]
        public IActionResult UserProjectPhotoVerfications()
        {
            return View(_userProjectPhotosFacadePattern.GetAllUserProjectPhotosForAdminService.Execute());
        }
        [HttpGet]
        public IActionResult UserProject(Guid id)
        {
            return View(_userProjectsFacadePattern.GetUserProjectByIdForAdmin.Execute(new RequestGetUserProjectByIdForAdminDto
            {
                Id = id
            }));
        }
        [HttpPut]
        public IActionResult UpdateUserProject(RequestUpdateUserProjectStatusServiceDto req)
        {
            return Json(_userProjectsFacadePattern.UpdateUserProjectStatusService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateUserProjectPhoto(RequestUpdateUserProjectPhotoStatusDto req)
        {
            return Json(_userProjectPhotosFacadePattern.UpdateUserProjectPhotoStatusService.Execute(req));
        }

        // Settings
        [HttpGet]
        public IActionResult Settings()
        {
            var result = _settingsFacadePattern.GetAllSettingsService.Execute();
            return View(result);
        }
        [HttpPut]
        public IActionResult UpdateSettings(RequestUpdateSettingsServiceDto req)
        {
            return Json(_settingsFacadePattern.UpdateSettingsService.Execute(req));
        }
        [HttpGet]
        public IActionResult SendInformation(int page)
        {
            var result = _sendInformationFacadePattern.GetAllSendInformationService.Execute(new RequestGetAllSendInformationServiceDto
            {
                CurrentPage = page
            });
            return View(result);
        }
        [HttpPut]
        public IActionResult UpdateSendInformation(RequestUpdateSendInformationStatusByAdminServiceDto req)
        {
            return Json(_sendInformationFacadePattern.UpdateSendInformationStatusByAdminService.Execute(req));
        }

        // Sliders
        [HttpGet]
        public IActionResult Sliders(int page)
        {
            return View(_slidersFacadePattern.GetSlidersForAdminService.Execute(new IranFilmPort.Application.Services.Sliders.Queries.GetSlidersForAdmin.RequestGetSlidersForAdminServiceDto
            {
                CurrentPage = page
            }));
        }
        [HttpPost]
        public IActionResult PostSlider(RequestPostSliderServiceDto req)
        {
            return Json(_slidersFacadePattern.PostSliderService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateSlider(RequestUpdateSliderServiceDto req)
        {
            return Json(_slidersFacadePattern.UpdateSliderService.Execute(req));
        }
        [HttpPut]
        public IActionResult DeleteSlider(RequestDeleteSliderServiceDto req)
        {
            return Json(_slidersFacadePattern.DeleteSliderService.Execute(req));
        }
        [HttpGet]
        public IActionResult Testimonials(int page)
        {
            return View(_testimonalsFacadePattern.GetAllTestimonialsService.Execute(new RequestGetAllTestimonialsServiceDto
            {
                CurrentPage = page
            }));
        }
        [HttpPost]
        public IActionResult PostTestimonial(RequestPostTestimonalServiceDto req)
        {
            return Json(_testimonalsFacadePattern.PostTestimonalService.Execute(req));
        }
        [HttpPut]
        public IActionResult DeleteTestimonial(RequestDeleteTestimonalServiceDto req)
        {
            return Json(_testimonalsFacadePattern.DeleteTestimonalService.Execute(req));
        }

        // accolades
        [HttpGet]
        public async Task<IActionResult> Accolades(int page)
        {
            ModelAccolades modelAccolades = new ModelAccolades()
            {
                ResutlGetAllAccoladesServiceDto = _accoladesFacadePattern.GetAllAccoladesService.Execute(new RequestGetAllAccoladesServiceDto
                {
                    CurrentPage = page
                }),
                ResultGetFilmsServiceDapperDto = await _filmFacadePatternDapper.GetFilmsDapperService.Execute()
            };
            return View(modelAccolades);
        }
        [HttpGet]
        public async Task<IActionResult> AddAccolade(long? id)
        {
            if (id == null || id == 0)
            {
                ModelAddAccolade modelAddAccolade = new ModelAddAccolade()
                {
                    ResultGetFilmsServiceDapperDto = await _filmFacadePatternDapper.GetFilmsDapperService.Execute()
                };
                return View(modelAddAccolade);
            }
            else
            {
                ModelAddAccolade modelAddAccolade = new ModelAddAccolade()
                {
                    ResultGetFilmsServiceDapperDto = await _filmFacadePatternDapper.GetFilmsDapperService.Execute(),
                    GetAccoladeByIdServiceDto = _accoladesFacadePattern.GetAccoladeByIdService.Execute(new RequestGetAccoladeByIdServiceDto
                    {
                        FilmId = (long)id,
                    }),
                    FilmId = id,
                };
                return View(modelAddAccolade);
            }
        }
        [HttpPut]
        public IActionResult UpdateAccolade(RequestUpdateAccoladeServiceDto req)
        {
            return Json(_accoladesFacadePattern.UpdateAccoladeService.Execute(req));
        }
        [HttpPost]
        public IActionResult PostAccolade(RequestPostAccoladeServiceDto req)
        {
            return Json(_accoladesFacadePattern.PostAccoladeService.Execute(req));
        }

        // Contanct
        [HttpGet]
        public IActionResult Contacts()
        {
            return View(_contactFacadePattern.GetAllContactsService.Execute());
        }
        [HttpPut]
        public IActionResult UpdateContactStatus(RequestUpdateContactStatusDto req)
        {
            return Json(_contactFacadePattern.UpdateContactStatus.Execute(req));
        }

        // Newsletter
        [HttpGet]
        public IActionResult Newsletters()
        {
            return View(_newslettersFacadePattern.GetAllNewslettersService.Execute());
        }

        // Courses
        [HttpGet]
        public IActionResult Courses(Guid? id)
        {
            return View(_coursesFacadePattern.GetAllCoursesService.Execute());
        }
        [HttpGet]
        public IActionResult AddCourse(Guid? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                return View(_coursesFacadePattern.GetCourseByIdService.Execute(new RequestGetCourseByIdServiceDto
                {
                    Id = (Guid)id
                }));
            }
        }
        [HttpPost]
        public IActionResult PostCourse(RequestPostCourseServiceDto req)
        {
            return Json(_coursesFacadePattern.PostCourseService.Execute(req));
        }
        [HttpPut]
        public IActionResult UpdateCourse(RequestUpdateCourseServiceDto req)
        {
            return Json(_coursesFacadePattern.UpdateCourseService.Execute(req));
        }
    }
}
