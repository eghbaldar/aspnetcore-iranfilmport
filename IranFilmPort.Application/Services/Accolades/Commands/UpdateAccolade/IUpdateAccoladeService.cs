using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services.Common.UploadFile;
using IranFilmPort.Domain.Entities.Accolades;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace IranFilmPort.Application.Services.Accolades.Commands.UpdateAccolade
{
    public class RequestUpdateAccoladeServiceDto
    {
        public long FilmId { get; set; }
        public string AccoladeFa { get; set; }
        public string? AccoladeEn { get; set; }
        public int Priority { get; set; }
        // قسمت زیر ترکیبی شده 
        // چون در وب سایت قبلی جدولی با عنوان
        // tbl_posterOFCustomer
        // داشتیم که نمیخواستم براش جدول جدا بذارم
        public byte ArtworkType { get; set; } // ArtworkTypeConstants.cs
        public string? Director { get; set; }
        public IFormFile? PosterFile { get; set; }
        public string? TrailerLink { get; set; }
    }
    public interface IUpdateAccoladeService
    {
        ResultDto Execute(RequestUpdateAccoladeServiceDto req);
    }
    public class UpdateAccoladeService : IUpdateAccoladeService
    {
        private readonly IDataBaseContext _context;
        public UpdateAccoladeService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateAccoladeServiceDto req)
        {
            if (req == null ||
                           string.IsNullOrEmpty(req.AccoladeFa) ||
                           string.IsNullOrEmpty(req.AccoladeEn) ||
                           req.FilmId == 0)
                return new ResultDto { IsSuccess = false };

            var accolade = _context.Accolades.FirstOrDefault(x => x.FilmId == req.FilmId);
            if (accolade == null) return new ResultDto { IsSuccess = false };

            accolade.AccoladeEn = req.AccoladeEn;
            accolade.AccoladeFa = req.AccoladeFa;
            accolade.Priority = req.Priority;
            accolade.Director = req.Director;
            accolade.TrailerLink = req.TrailerLink;
            accolade.ArtworkType = req.ArtworkType;
            
            if (req.PosterFile != null)
            {
                // upload the main photo
                var file = CreateFilename(req.PosterFile, false);
                switch (file.IsSuccess)
                {
                    case true:
                        accolade.PosterFile = file.Filename;
                        break;
                    case false:
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = file.Message,
                        };
                }
            }

            // post & save
            if (_context.SaveChanges() >= 0) return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
        private ResultUploadDto CreateFilename(IFormFile file, bool AllowedOver150)
        {
            UploadFileService uploadFileService = new UploadFileService();
            var filename = uploadFileService.UploadFile(new RequestUploadFileServiceDto
            {
                Type = false,
                DirectoryROOT = "admin",
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "admin-poster-images",
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
