namespace IranFilmPort.Application.Services.Common.SMS.multipleParameteres
{
    public class RequestSmsMultiServiceDto
    {
        public Guid UserId { get; set; }
        public string Pattern { get; set; }
        public List<Dictionary<string, string>> Arguments_Parameters { get; set; }
    }
}
