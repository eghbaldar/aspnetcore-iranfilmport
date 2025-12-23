using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces;
using IranFilmPort.Application.Services.Common.UploadFile;
using IranFilmPort.Domain.Entities.News;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.RegularExpressions;

namespace IranFilmPort.Application.Services.News.News.UpdateNews
{
    public class RequestUpdateNewsServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // سایت خبری کنیگتو افتتاح شد
        public string Summary { get; set; }
        public string? Slug { get; set; }
        public string BodyText { get; set; }
        public bool AllowToChangeSlug { get; set; }
        public IFormFile? MainImage { get; set; } // Filename
        public string Author { get; set; }
        public string Reference { get; set; }
        public bool? Active { get; set; } // NewsActiveConstants.cs
        public DateTime? FutureDateTime { get; set; } // FutureDateTime < DateTime.Now()
        public Guid CategoryId { get; set; }
        public string Tags { get; set; } // "AI,DotNet,Csharp"
    }
    public interface IUpdateNewsService
    {
        ResultDto Execute(RequestUpdateNewsServiceDto req);
    }
    public class UpdateNewsService : IUpdateNewsService
    {
        private readonly IDataBaseContext _context;
        public UpdateNewsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateNewsServiceDto req)
        {
            if (req == null ||
                req.Id == Guid.Empty ||
                string.IsNullOrEmpty(req.Title) ||
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

            var fetchedData = _context.News.FirstOrDefault(x => x.Id == req.Id);
            if (fetchedData == null) return new ResultDto { IsSuccess = false };
            fetchedData.Active = req.Active;
            fetchedData.Author = WebUtility.HtmlDecode(req.Author.Trim());
            fetchedData.Reference = WebUtility.HtmlDecode(req.Reference.Trim());
            fetchedData.CategoryId = req.CategoryId;
            fetchedData.BodyText = WebUtility.HtmlDecode(req.BodyText.Trim());
            fetchedData.Title = WebUtility.HtmlDecode(req.Title.Trim());

            // the main image
            if (req.MainImage != null)
            {
                // upload the main photo
                var file = CreateFilename(req.MainImage);
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
            // slug
            if (req.AllowToChangeSlug)
                fetchedData.Slug = req.Slug;
            else
                fetchedData.Slug = EnsureUniqueSlug(GenerateSlug(req.Title));

            // tags
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
                    _context.NewsTags.Add(newsTags);
                    _context.SaveChanges();
                }
            }
            else
                return new ResultDto { IsSuccess = false, Message = " برچسبی وارد نشده است." };


            fetchedData.FutureDateTime = req.FutureDateTime;
            fetchedData.Summary = req.Summary.Trim();

            // update & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
        private static string GenerateSlug(string title)
        {
            string slug = title.ToLower();
            // remove all characters but persian charactes
            slug = Regex.Replace(slug, @"[^a-z0-9\u0600-\u06FF\s-]", "");
            // remove multiple spaces => Ali  Hani => Ali Hani
            slug = Regex.Replace(slug, @"\s+", " ").Trim();
            // replace space with hypen Ali Hani => Ali-Hani
            slug = slug.Replace(" ", "-");
            // truncate to 60 characters
            if (slug.Length > 60)
            {
                slug = slug.Substring(0, 60).TrimEnd('-');
            }
            return slug;
        }
        private string EnsureUniqueSlug(string baseSlug)
        {
            string slug = baseSlug.ToLower();
            int counter = 1;
            while (_context.News.Any(x => x.Slug == slug))
            {
                slug = $"{baseSlug}-{counter}";
                counter++;
            }
            return slug;
        }
        private static string GenerateRandomString()
        {
            Random random = new Random();
            int len = random.Next(3, 11);
            const string characters = "0123456789zxcvbnmasdfghjkqwertyuiopZXCVBNASDFGHJKLQWERTYUIOP";
            string randomString = new string(Enumerable.Range(0, len)
                .Select(_ => characters[random.Next(characters.Length)])
                .ToArray());
            return randomString;
        }
        private string EnsureUniqueCode(string baseUniqueCode)
        {
            string rndCode = baseUniqueCode.ToLower();
            int counter = 1;
            while (_context.News.Any(x => x.UniqueCode == rndCode))
            {
                rndCode = $"{baseUniqueCode}-{counter}";
                counter++;
            }
            return rndCode;
        }
        private ResultUploadDto CreateFilename(IFormFile file)
        {
            UploadFileService uploadFileService = new UploadFileService();
            var filename = uploadFileService.UploadFile(new RequestUploadFileServiceDto
            {
                Type = false,
                DirectoryROOT = "admin",
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "admin-news-images",
                Extension = new string[] { ".jpg", ".png", ".bmp", ".jpeg" },
                FileSize = "160000",
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
