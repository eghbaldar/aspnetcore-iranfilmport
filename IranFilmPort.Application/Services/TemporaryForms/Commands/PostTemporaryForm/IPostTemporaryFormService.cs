using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.TemporaryForms.Commands.PostTemporaryForm
{
    public class RequestPostTemporaryFormServiceDto
    {
        public string Value { get; set; }
    }
    public interface IPostTemporaryFormService
    {
        ResultDto Execute(RequestPostTemporaryFormServiceDto req);
    }
    public class PostTemporaryFormService : IPostTemporaryFormService
    {
        private readonly IDataBaseContext _context;
        public PostTemporaryFormService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostTemporaryFormServiceDto req)
        {
            if (req == null || string.IsNullOrEmpty(req.Value)) { return new ResultDto { IsSuccess = false }; }
            IranFilmPort.Domain.Entities.Guest.TemporaryForms temporaryForms
                = new Domain.Entities.Guest.TemporaryForms()
                {
                    Value = req.Value,
                };
            _context.TemporaryForms.Add(temporaryForms);
            var output = _context.SaveChanges();
            if (output >= 0)
                return new ResultDto { IsSuccess = true };
            else return new ResultDto { IsSuccess = false };
        }
    }
}
