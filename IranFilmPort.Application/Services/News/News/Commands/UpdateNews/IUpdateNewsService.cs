using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.Sitemap;
using IranFilmPort.Application.Services.Common.UploadFile;
using IranFilmPort.Domain.Entities.News;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text.RegularExpressions;

namespace IranFilmPort.Application.Services.News.News.Commands.UpdateNews
{
    public class RequestUpdateNewsServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // سایت خبری کنیگتو افتتاح شد
        public string TitleEn { get; set; }
        public string Summary { get; set; }
        public string? Slug { get; set; }
        public string BodyText { get; set; }
        public IFormFile? MainImage { get; set; } // Filename
        public string Author { get; set; }
        public string Reference { get; set; }
        public bool Active { get; set; } // NewsActiveConstants.cs
        public DateTime FutureDateTime { get; set; } // FutureDateTime < DateTime.Now()
        public Guid CategoryId { get; set; }
        public bool AllowedOver150 { get; set; }
        public string Tags { get; set; } // "AI,DotNet,Csharp"
    }
    public interface IUpdateNewsService
    {
        Task<ResultDto> Execute(RequestUpdateNewsServiceDto req);
    }
    public class UpdateNewsService : IUpdateNewsService
    {
        private readonly IDataBaseContext _context;
        private readonly IServiceProvider _serviceProvider;
        public UpdateNewsService(IDataBaseContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        public async Task<ResultDto> Execute(RequestUpdateNewsServiceDto req)
        {
            if (req == null ||
                req.Id == Guid.Empty ||
                string.IsNullOrEmpty(req.Title) ||
                string.IsNullOrEmpty(req.TitleEn) ||
                string.IsNullOrEmpty(req.Summary) ||
                string.IsNullOrEmpty(req.BodyText) ||
                string.IsNullOrEmpty(req.Author) ||
                string.IsNullOrEmpty(req.Reference) ||
                req.CategoryId == Guid.Empty
                )
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطایی در هنگام ورود اطلاعات رخ داده است."
                };
            }
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IDataBaseContext>();
                var sitemapFacade = scope.ServiceProvider.GetRequiredService<ISitemapService>();

                using (var transaction = await dbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var fetchedData = _context.News.FirstOrDefault(x => x.Id == req.Id);
                        if (fetchedData == null) return new ResultDto { IsSuccess = false };
                        fetchedData.Active = req.Active;
                        fetchedData.Author = WebUtility.HtmlDecode(req.Author.Trim());
                        fetchedData.Reference = WebUtility.HtmlDecode(req.Reference.Trim());
                        fetchedData.NewsCategoryId = req.CategoryId;
                        fetchedData.BodyText = WebUtility.HtmlDecode(req.BodyText.Trim());
                        fetchedData.Title = WebUtility.HtmlDecode(req.Title.Trim());
                        fetchedData.TitleEn = WebUtility.HtmlDecode(req.TitleEn.Trim());

                        // the main image
                        if (req.MainImage != null)
                        {
                            // upload the main photo
                            var file = CreateFilename(req.MainImage, req.AllowedOver150);
                            switch (file.IsSuccess)
                            {
                                case true:
                                    fetchedData.MainImage = file.Filename;
                                    break;
                                case false:
                                    return new ResultDto
                                    {
                                        IsSuccess = false,
                                        Message = file.Message,
                                    };
                            }
                        }

                        // news tags...
                        if (!string.IsNullOrEmpty(req.Tags.Trim()))
                        {
                            // remove the previous tags
                            var tags = _context.NewsTags
                                .Where(x => x.NewsId == req.Id)
                                .ToList();
                            foreach (var tag in tags) tag.DeleteDateTime = DateTime.Now;

                            // insert new tags
                            var count = req.Tags.Split(',').Length;
                            if (count < 3) return new ResultDto { IsSuccess = false, Message = "حداقل سه برچسب باید به خبر اضافه شود." };
                            foreach (var tag in req.Tags.Split(","))
                            {
                                NewsTags newsTags = new NewsTags()
                                {
                                    Title = tag,
                                    NewsId = req.Id,
                                };
                                dbContext.NewsTags.Add(newsTags);
                                dbContext.SaveChanges();
                            }
                        }
                        else
                            return new ResultDto { IsSuccess = false, Message = " برچسبی وارد نشده است." };

                        fetchedData.FutureDateTime = req.FutureDateTime;
                        fetchedData.Summary = req.Summary.Trim();

                        // Step 3: Save changes and commit the transaction
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
        private ResultUploadDto CreateFilename(IFormFile file,bool AllowedOver150)
        {
            UploadFileService uploadFileService = new UploadFileService();
            var filename = uploadFileService.UploadFile(new RequestUploadFileServiceDto
            {
                Type = false,
                DirectoryROOT = "admin",
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "admin-news-images",
                Extension = new string[] { ".webp" },
                FileSize = (AllowedOver150) ? "1600000" : "160000",
                File = file,
                Scales = new Dictionary<string, string>
                {
                    {"original","1500"},
                    {"thumbnail","500"}
                }
            });
            return filename;
        }
    }
}
