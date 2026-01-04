using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.Settings.Queries.GetSettingBySelector
{
    public class RequestGetSettingBySelectorServiceDto
    {
        public byte Selector { get; set; } // SettingsSelectorConstants.cs
    }
    public interface IGetSettingBySelectorService
    {
        string Execute(RequestGetSettingBySelectorServiceDto req);
    }
    public class GetSettingBySelectorService : IGetSettingBySelectorService
    {
        private readonly IDataBaseContext _context;
        public GetSettingBySelectorService(IDataBaseContext context)
        {
            _context = context;
        }
        public string Execute(RequestGetSettingBySelectorServiceDto req)
        {
            switch (req.Selector)
            {
                case SettingsSelectorConstants.DollarToRial:
                    return _context.Settings.FirstOrDefault().DollarToRial;
                case SettingsSelectorConstants.ComissionForFee:
                    return _context.Settings.FirstOrDefault().ComissionForFee;
                case SettingsSelectorConstants.CommissionForFree:
                    return _context.Settings.FirstOrDefault().CommissionForFree;
                case SettingsSelectorConstants.Version:
                    return _context.Settings.FirstOrDefault().Version;
                case SettingsSelectorConstants.ApkStuff:
                    return _context.Settings.FirstOrDefault().ApkStuff;
                case SettingsSelectorConstants.ApkClient:
                    return _context.Settings.FirstOrDefault().ApkClient;
                case SettingsSelectorConstants.WinApp:
                    return _context.Settings.FirstOrDefault().WinApp;
                case SettingsSelectorConstants.Marquee:
                    return _context.Settings.FirstOrDefault().Marquee;
                case SettingsSelectorConstants.ModalOnAllPage:
                    return _context.Settings.FirstOrDefault().ModalOnAllPage.ToString();
                default:
                    return null;
            }
        }
    }
}
