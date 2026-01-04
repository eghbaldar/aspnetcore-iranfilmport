using IranFilmPort.Application.Common;

namespace IranFilmPort.Application.Services.Common.SMS.singleParameter
{
    public interface ISmsService
    {
        Task<ResultDto> Execute(RequestSmsServiceDto req);
    }
}
