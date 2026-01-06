using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.Settings.Commands.UpdateSettings;
using IranFilmPort.Application.Services.Settings.Queries.GetAllSettings;
using IranFilmPort.Application.Services.Settings.Queries.GetSettingBySelector;

namespace IranFilmPort.Application.Services.Settings.FacadePattern
{
    public class SettingsFacadePattern: ISettingsFacadePattern
    {
        private readonly IDataBaseContext _context;
        public SettingsFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // UpdateSettingsService
        public UpdateSettingsService _updateSettingsService;
        public UpdateSettingsService UpdateSettingsService
        {
            get { return _updateSettingsService = _updateSettingsService ?? new UpdateSettingsService(_context); }
        }
        // UpdateSettingsService
        public GetAllSettingsService _getAllSettingsService;
        public GetAllSettingsService GetAllSettingsService
        {
            get { return _getAllSettingsService = _getAllSettingsService ?? new GetAllSettingsService(_context); }
        }
        // GetSettingBySelectorService
        public GetSettingBySelectorService _getSettingBySelectorService;
        public GetSettingBySelectorService GetSettingBySelectorService
        {
            get { return _getSettingBySelectorService = _getSettingBySelectorService ?? new GetSettingBySelectorService(_context); }
        }
    }
}
