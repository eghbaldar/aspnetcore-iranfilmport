using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using IranFilmPort.Domain.Entities.News;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.RegularExpressions;

namespace IranFilmPort.Application.Services.News.News.Commands.PostNews
{
    public class RequestPostNewsServiceDto
    {
        public string Title { get; set; } // سایت خبری کنیگتو افتتاح شد
        public string Summary { get; set; }
        public string BodyText { get; set; }
        public IFormFile MainImage { get; set; } // Filename
        public string Author { get; set; }
        public string Reference { get; set; }
        public bool Active { get; set; } // NewsActiveConstants.cs
        public DateTime FutureDateTime { get; set; } // FutureDateTime < DateTime.Now()
        public Guid CategoryId { get; set; }
        public string Tags { get; set; } // "AI,DotNet,Csharp"
    }
    public interface IPostNewsService
    {
        ResultDto Execute(RequestPostNewsServiceDto req);
    }
    public class PostNewsService : IPostNewsService
    {
        private readonly IDataBaseContext _context;
        public PostNewsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostNewsServiceDto req)
        {
            if (req == null ||
                string.IsNullOrEmpty(req.Title) ||
                string.IsNullOrEmpty(req.Summary) ||
                string.IsNullOrEmpty(req.BodyText) ||
                req.MainImage == null ||
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
            // generate slug & unique code
            long UNIQUECODE = EnsureUniqueCode(GenerateRandomLongValue());

            // populating the entity
            Domain.Entities.News.News news = new Domain.Entities.News.News()
            {
                Active = req.Active,
                Author = WebUtility.HtmlDecode(req.Author.Trim()),
                Reference = WebUtility.HtmlDecode(req.Reference.Trim()),
                NewsCategoryId = req.CategoryId,
                BodyText = WebUtility.HtmlDecode(req.BodyText.Trim()),
                Title = WebUtility.HtmlDecode(req.Title.Trim()),
                UniqueCode = UNIQUECODE,
                FutureDateTime = req.FutureDateTime,
                Summary = req.Summary.Trim()
            };
            // upload the main photo
            var file = CreateFilename(req.MainImage);
            switch (file.IsSuccess)
            {
                case true:
                    news.MainImage = file.Filename;
                    break;
                case false:
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = file.Message,
                    };
            }
            // set into database
            _context.News.Add(news);

            // news tags...
            if (!string.IsNullOrEmpty(req.Tags.Trim()))
            {
                var count = req.Tags.Split(',').Length;
                if (count < 3) return new ResultDto { IsSuccess = false, Message = "حداقل سه برچسب باید به خبر اضافه شود." };
                foreach (var tag in req.Tags.Split(","))
                {
                    NewsTags newsTags = new NewsTags()
                    {
                        Title = tag,
                        NewsId = news.Id
                    };
                    _context.NewsTags.Add(newsTags);
                    _context.SaveChanges();
                }
            }
            else
                return new ResultDto { IsSuccess = false, Message = " برچسبی وارد نشده است." };

            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
        private static long GenerateRandomLongValue()
        {
            Random random = new Random();
            int len = random.Next(3, 11);
            const string characters = "0123456789";
            string randomString = new string(Enumerable.Range(0, len)
                .Select(_ => characters[random.Next(characters.Length)])
                .ToArray());
            return Convert.ToInt64(randomString);
        }
        private long EnsureUniqueCode(long baseUniqueCode)
        {
            int counter = 1;
            while (_context.News.Any(x => x.UniqueCode == baseUniqueCode))
            {
                baseUniqueCode = GenerateRandomLongValue();
            }
            return baseUniqueCode;
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