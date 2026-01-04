using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Settings
{
    public class Settings : BaseEntity
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
}
