using IranFilmPort.Application.Interfaces.FacadePattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using IranFilmPort.Application.Services.News.News.Queries.GetNews;
using IranFilmPort.Common.Helpers;

namespace Endpoint.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsFacadePattern _newsFacadePattern;
        public HomeController(INewsFacadePattern newsFacadePattern)
        {
            _newsFacadePattern = newsFacadePattern;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Post(long id, string? slug, string? preview)
        {
            var article = _newsFacadePattern.GetNewsService.Execute(new RequestGetNewsServiceDto
            {
                UniqueCode = id,
                IsAdmin = false // TODO: change it
            });
            if (article == null) return NotFound();

            // === Preview logic (admin / user) ===
            //if (!string.IsNullOrEmpty(preview))
            //{
            //    switch (preview.ToLower())
            //    {
            //        case "admin":
            //            if (!UserCanEdit())
            //                return Redirect("/عدم-دسترسی");
            //            break;

            //        case "user":
            //            if (!article.IsEnabled)
            //                return Redirect("/عدم-دسترسی");

            //            ViewBag.BlurPreview = true;
            //            break;

            //        default:
            //            return Redirect("/عدم-دسترسی");
            //    }
            //}
            //else
            //{
            //    if (!article.IsEnabled)
            //        return Redirect("/عدم-دسترسی");
            //}

            // === Canonical slug enforcement ===
            var correctSlug = SlugHelper.Generate(article.Title);

            if (string.IsNullOrWhiteSpace(slug) || slug != correctSlug)
            {
                return RedirectToActionPermanent(
                    "Details",
                    new { id = id, slug = correctSlug }
                );
            }

            //_articleService.IncreaseViewCount(id);

            return View(article);
        }
    }
}
