using IranFilmPort.Application.Services.Settings.Commands.UpdateSettings;
using IranFilmPort.Application.Services.Settings.Queries.GetAllSettings;
using IranFilmPort.Application.Services.Settings.Queries.GetSettingBySelector;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface ISettingsFacadePattern
    {
        public UpdateSettingsService UpdateSettingsService { get;}
        public GetAllSettingsService GetAllSettingsService { get;}
        public GetSettingBySelectorService GetSettingBySelectorService { get;}
    }
}
