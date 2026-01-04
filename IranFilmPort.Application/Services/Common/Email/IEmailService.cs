using IranFilmPort.Application.Common;

namespace IranFilmPort.Application.Services.Common.Email
{
    public interface IEmailService
    {
        Task<ResultDto> Execute(RequestEmailServiceDto req);
    }
}
