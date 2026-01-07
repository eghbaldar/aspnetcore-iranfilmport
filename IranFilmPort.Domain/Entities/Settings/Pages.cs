using IranFilmPort.Domain.Common;

namespace IranFilmPort.Domain.Entities.Settings
{
    // ستون های زیر براساس
    // PageSelectorConstants
    // تغییر میکند
    // اگر ستون اضافه شد
    // PageSelectorConstants
    // را تغییر بده
    public class Pages : BaseEntity
    {
        public string? ResumeFa { get; set; }
        public string? ResumeEn { get; set; }
        public string? Advertisements { get; set; }
        public string? ParticipatePlan { get; set; }
        public string? AboutFa { get; set; }
        public string? AboutEn { get; set; }
        public string? AgentsFa { get; set; }
        public string? AgentsEn { get; set; }
        public string? ScriptFa { get; set; }
        public string? Features { get; set; }
    }
}
