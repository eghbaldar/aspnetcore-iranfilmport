using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Settings.Queries.GetAllSettings
{
    public class GetAllSettingsServiceDto
    {
        public string? DollarToRial { get; set; }
        public string? ComissionForFee { get; set; }
        public string? CommissionForFree { get; set; }
        public string? Version { get; set; }
        public string? ApkStuff { get; set; }
        public string? ApkClient { get; set; }
        public string? WinApp { get; set; }
        public string? Marquee { get; set; }
        public bool ModalOnAllPage { get; set; }
    }
    public interface IGetAllSettingsService
    {
        GetAllSettingsServiceDto? Execute();
    }
    public class GetAllSettingsService : IGetAllSettingsService
    {
        private readonly IDataBaseContext _context;
        public GetAllSettingsService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetAllSettingsServiceDto? Execute()
        {
            return _context.Settings
                .Select(x => new GetAllSettingsServiceDto
                {
                    ApkStuff = x.ApkStuff,
                    ApkClient = x.ApkClient,
                    ComissionForFee = x.ComissionForFee,
                    CommissionForFree = x.CommissionForFree,
                    DollarToRial = x.DollarToRial,
                    Marquee = x.Marquee,
                    ModalOnAllPage = x.ModalOnAllPage,
                    Version = x.Version,
                    WinApp = x.WinApp,
                }).FirstOrDefault();
        }
    }
}
