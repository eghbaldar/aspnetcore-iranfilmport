using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.Sitemap;
using IranFilmPort.Common.Constants;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text.RegularExpressions;

namespace IranFilmPort.Application.Services.UserProjects.Commands.PostUserProject
{
    public class RequestPostUserProjectServiceDto
    {
        public Guid UserId { get; set; }
        public byte Type { get; set; } // UserProjectTypeConstants.cs
        public string TitleFa { get; set; }
        public string? TitleEn { get; set; }
        public string SynopsisFa { get; set; }
        public string? SynopsisEn { get; set; }
        public DateTime ProductionDate { get; set; }
        public string? PageLink { get; set; }
        public string? Director { get; set; }
        public string? DirectorEn { get; set; }
        public string? Writer { get; set; }
        public string? WriterEn { get; set; }
        public string? Producer { get; set; }
        public string? ProducerEn { get; set; }
        public string? Detail { get; set; }
        public string? DetailEn { get; set; }
        public string? ArtworkLink { get; set; }
        public string? ArtworkPassword { get; set; }
    }
    public interface IPostUserProjectService
    {
        Task<ResultDto> Execute(RequestPostUserProjectServiceDto req);
    }
    public class PostUserProjectService : IPostUserProjectService
    {
        private readonly IDataBaseContext _context;
        private readonly IServiceProvider _serviceProvider;
        public PostUserProjectService(IDataBaseContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        public async Task<ResultDto> Execute(RequestPostUserProjectServiceDto req)
        {
            if (req == null ||
                req.UserId == Guid.Empty ||
                string.IsNullOrEmpty(req.TitleFa) ||
                string.IsNullOrEmpty(req.SynopsisFa))
            { return new ResultDto { IsSuccess = false }; }

            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IDataBaseContext>();
                var sitemapFacade = scope.ServiceProvider.GetRequiredService<ISitemapService>();

                using (var transaction = await dbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        string baseSlug = GenerateSlug(req.TitleFa);
                        string uniqueSlug = EnsureUniqueSlug(baseSlug);
                        int uniqueCode = EnsureUniqueCode(GenerateRandomString());

                        IranFilmPort.Domain.Entities.UserProjects.UserProjects userProjects
                            = new IranFilmPort.Domain.Entities.UserProjects.UserProjects()
                            {
                                UserId = req.UserId,
                                Slug = uniqueSlug,
                                UniqueCode = uniqueCode,
                                TitleFa = WebUtility.HtmlDecode(req.TitleFa),
                                TitleEn = WebUtility.HtmlDecode(req.TitleEn),
                                ArtworkLink = WebUtility.HtmlDecode(req.ArtworkLink),
                                ArtworkPassword = WebUtility.HtmlDecode(req.ArtworkPassword),
                                Detail = WebUtility.HtmlDecode(req.Detail),
                                DetailEn = WebUtility.HtmlDecode(req.DetailEn),
                                Director = WebUtility.HtmlDecode(req.Director),
                                DirectorEn = WebUtility.HtmlDecode(req.DirectorEn),
                                Producer = WebUtility.HtmlDecode(req.Producer),
                                ProduerEn = WebUtility.HtmlDecode(req.ProducerEn),
                                Writer = WebUtility.HtmlDecode(req.Writer),
                                WriterEn = WebUtility.HtmlDecode(req.WriterEn),
                                Genuine = false,
                                PageLink = WebUtility.HtmlDecode(req.PageLink),                                
                                ProductionDate = req.ProductionDate,
                                SynopsisEn = WebUtility.HtmlDecode(req.SynopsisEn),
                                SynopsisFa = WebUtility.HtmlDecode(req.SynopsisFa),
                                Status = StatusConstants.UnderConsideration,
                                Type = req.Type,
                            };

                        dbContext.UserProjects.Add(userProjects);

                        var output = await dbContext.SaveChangesAsync();

                        // sitemap ...
                        sitemapFacade.CreateOrUpdateSitemap();

                        if (output >= 0)
                        {
                            await transaction.CommitAsync();
                            return new ResultDto { IsSuccess = true };
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            return new ResultDto { IsSuccess = false };
                        }
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        return new ResultDto { IsSuccess = false };
                    }
                }
            }
        }
        public static string GenerateSlug(string title)
        {
            // Convert to lower case
            string slug = title.ToLower();

            // Remove invalid characters but allow Persian characters
            slug = Regex.Replace(slug, @"[^a-z0-9\u0600-\u06FF\s-]", "");

            // Replace multiple spaces with a single space
            slug = Regex.Replace(slug, @"\s+", " ").Trim();

            // Replace spaces with hyphens
            slug = slug.Replace(" ", "-");

            // Truncate to 60 characters
            if (slug.Length > 60)
            {
                slug = slug.Substring(0, 60).TrimEnd('-');
            }

            return slug;
        }
        public static int GenerateRandomString()
        {
            // Generate a random length between 3 and 10
            Random random = new Random();
            int length = random.Next(3, 11); // Inclusive range: 3 to 10

            // Generate a random string of the specified length
            const string characters = "0123456789";
            string randomString = new string(Enumerable
                .Range(0, length)
                .Select(_ => characters[random.Next(characters.Length)])
                .ToArray());

            return int.Parse(randomString);
        }
        public string EnsureUniqueSlug(string baseSlug)
        {
            string slug = baseSlug;
            int counter = 1;

            while (_context.UserProjects.Any(a => a.Slug == slug))
            {
                slug = $"{baseSlug}-{counter}";
                counter++;
            }

            return slug;
        }
        public int EnsureUniqueCode(int baseUniqueCode)
        {
            int uniqueCode = baseUniqueCode;
            int counter = 1;

            while (_context.UserProjects.Any(a => a.UniqueCode == uniqueCode))
            {
                counter++;
                uniqueCode = baseUniqueCode + counter;
            }

            return uniqueCode;
        }
    }
}
