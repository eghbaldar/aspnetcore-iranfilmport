using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Settings.Commands.UpdateSettings
{
    public class RequestUpdateSettingsServiceDto
    {
        // المان های زیر براساس کلاس استاتیک
        // SettingsSelectorConstants.cs
        // خوانده میشوند
        // بنابراین اگر موردی به موارد زیر اضافه شد استاتیک آن نیز اضافه شود
        public string DollarToRial { get; set; }
        public string ComissionForFee { get; set; }
        public string CommissionForFree { get; set; }
        public string Version { get; set; }
        public string ApkStuff { get; set; }
        public string ApkClient { get; set; }
        public string WinApp { get; set; }
        public string Marquee { get; set; }
        public bool ModalOnAllPage { get; set; }
    }
    public interface IUpdateSettingsService
    {
        ResultDto Execute(RequestUpdateSettingsServiceDto req);
    }
    public class UpdateSettingsService : IUpdateSettingsService
    {
        private readonly IDataBaseContext _context;
        public UpdateSettingsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateSettingsServiceDto req)
        {
            var settings = _context.Settings.FirstOrDefault();
            if(settings == null)
            {
                IranFilmPort.Domain.Entities.Settings.Settings setting
                    = new Domain.Entities.Settings.Settings()
                    {
                        ApkClient = req.ApkClient,
                        ApkStuff = req.ApkStuff,
                        ComissionForFee = req.ComissionForFee,
                        CommissionForFree = req.CommissionForFree,
                        DollarToRial = req.DollarToRial,
                        Marquee = req.Marquee,
                        ModalOnAllPage = req.ModalOnAllPage,
                        Version = req.Version,
                        WinApp = req.WinApp,
                    };
                _context.Settings.Add(setting);
            }
            else
            {
                settings.ApkClient = req.ApkClient;
                settings.ApkStuff = req.ApkStuff;
                settings.ComissionForFee = req.ComissionForFee;
                settings.CommissionForFree = req.CommissionForFree;
                settings.DollarToRial = req.DollarToRial;
                settings.Marquee = req.Marquee;
                settings.ModalOnAllPage = req.ModalOnAllPage;
                settings.Version = req.Version;
                settings.WinApp = req.WinApp;
                
            }
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };

        }
    }
}
