using IranFilmPort.Application.Services.News.News.Commands.DeleteNews;
using IranFilmPort.Application.Services.News.News.Commands.PostNews;
using IranFilmPort.Application.Services.News.News.Commands.UpdateNews;
using IranFilmPort.Application.Services.News.News.Commands.UpdateNewsVisit;
using IranFilmPort.Application.Services.News.News.Queries.GetAllNewsForAdmin;
using IranFilmPort.Application.Services.News.News.Queries.GetAllNewsForSitemap;
using IranFilmPort.Application.Services.News.News.Queries.GetNews;
using IranFilmPort.Application.Services.News.News.Queries.GetNewsByFilterForAdmin;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface INewsFacadePattern
    {
        public DeleteNewsService DeleteNewsService { get; }
        public PostNewsService PostNewsService { get; }
        public UpdateNewsService UpdateNewsService { get; }
        public GetAllNewsForAdminService GetAllNewsForAdminService { get; }
        public GetNewsService GetNewsService { get; }
        public UpdateNewsVisitService UpdateNewsVisitService { get; }
        public GetNewsByFilterForAdminService GetNewsByFilterForAdminService { get; }
        public GetAllNewsForSitemapService GetAllNewsForSitemapService { get; }
    }
}
