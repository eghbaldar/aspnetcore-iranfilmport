using IranFilmPort.Application.Interfaces.FacadePattern;
using Microsoft.Extensions.DependencyInjection;
using System.Xml;
using System.Xml.Linq;

namespace IranFilmPort.Application.Services.Common.Sitemap
{
    // what are services under the sitemap services?
    // post news
    // update news
    // post festival
    // update festival
    // post userproject
    // update userproject
    public class SitemapService : ISitemapService
    {
        private readonly IServiceProvider _serviceProvider;
        public SitemapService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void CreateOrUpdateSitemap()
        {
            string webRootPath = @"wwwroot/sitemaps/";
            string sitemapPath = Path.Combine(webRootPath, "sitemap2026.xml");

            if (!Directory.Exists(webRootPath))
                Directory.CreateDirectory(webRootPath);

            XDocument sitemapDoc;
            XElement urlSet;

            if (!File.Exists(sitemapPath) || new FileInfo(sitemapPath).Length == 0)
            {
                sitemapDoc = CreateNewSitemapDocument();
            }
            else
            {
                try
                {
                    sitemapDoc = XDocument.Load(sitemapPath);
                    if (sitemapDoc.Root == null)
                        throw new XmlException();
                }
                catch
                {
                    sitemapDoc = CreateNewSitemapDocument();
                }
            }

            XNamespace ns = ResolveNamespace(sitemapDoc);
            urlSet = sitemapDoc.Root!;

            // clear safely
            urlSet.Elements(ns + "url").Remove();

            using (var scope = _serviceProvider.CreateScope())
            {
                var dbNewsFacade = scope.ServiceProvider.GetRequiredService<INewsFacadePattern>();
                var dbFestivalFacade = scope.ServiceProvider.GetRequiredService<IFestivalsFacadePattern>();
                var dbUserProjectFacade = scope.ServiceProvider.GetRequiredService<IUserProjectsFacadePattern>();

                var news = dbNewsFacade.GetAllNewsForSitemapService.Execute();
                var festivals = dbFestivalFacade.GetAllFestivalsForSitemapService.Execute();
                var userprojects = dbUserProjectFacade.GetAllUserProjectsForSitemapService.Execute();

                foreach (var news_item in news.Result)
                {
                    urlSet.Add(CreateUrlElement(ns,
                        $"https://iranfilmport.com/{news_item.UniqueCode}",
                        news_item.FutureDateTime.ToString("yyyy-MM-dd"),
                        "weekly",
                        "0.9"
                    ));
                }

                foreach (var festival_item in festivals.Result)
                {
                    urlSet.Add(CreateUrlElement(ns,
                        $"https://iranfilmport.com/festival/{festival_item.UniqueCode}",
                        festival_item.InsertDate.ToString("yyyy-MM-dd"),
                        "weekly",
                        "0.9"
                    ));
                }

                foreach (var userproject_item in userprojects.Result)
                {
                    urlSet.Add(CreateUrlElement(ns,
                        $"https://iranfilmport.com/filmmaker/{userproject_item.Username}/{userproject_item.UniqueCode}",
                        userproject_item.InsertDateTime.ToString("yyyy-MM-dd"),
                        "weekly",
                        "0.9"
                    ));
                }
            }

            sitemapDoc.Save(sitemapPath);
        }
        private static XNamespace ResolveNamespace(XDocument doc)
        {
            return doc.Root?.Name.Namespace
                   ?? "http://www.sitemaps.org/schemas/sitemap/0.9";
        }
        private static XDocument CreateNewSitemapDocument()
        {
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";

            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(ns + "urlset")
            );
        }
        private XElement CreateUrlElement(
            XNamespace ns,
            string url,
            string datetime,
            string changefrequently,
            string priority)
        {
            return new XElement(ns + "url",
                new XElement(ns + "loc", url),
                new XElement(ns + "lastmod", datetime),
                new XElement(ns + "changefreq", changefrequently),
                new XElement(ns + "priority", priority)
            );
        }


    }
}
