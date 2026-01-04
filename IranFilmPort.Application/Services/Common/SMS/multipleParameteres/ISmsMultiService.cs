using IranFilmPort.Application.Common;

namespace IranFilmPort.Application.Services.Common.SMS.multipleParameteres
{
    public interface ISmsMultiService
    {
        Task<ResultDto> Execute(RequestSmsMultiServiceDto req);
    }
}
