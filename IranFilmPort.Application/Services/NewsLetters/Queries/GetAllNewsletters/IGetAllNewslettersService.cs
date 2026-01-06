using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.NewsLetters.Queries.GetAllNewsletters
{
    public class GetAllNewslettersServiceDto
    {
        public string Email { get; set; }
        public string IP { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetAllNewslettersServiceDto
    {
        public List<GetAllNewslettersServiceDto> Result { get; set; }
    }
    public interface IGetAllNewslettersService
    {
        ResultGetAllNewslettersServiceDto Execute();
    }
    public class GetAllNewslettersService : IGetAllNewslettersService
    {
        public readonly IDataBaseContext _context;
        public GetAllNewslettersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllNewslettersServiceDto Execute()
        {
            var _result = _context.Newsletters
                .Select(x => new GetAllNewslettersServiceDto
                {
                    Email = x.Email,
                    InsertDateTime = x.InsertDateTime,
                    IP = x.IP,
                })
                .OrderByDescending(x => x.InsertDateTime)
                .ToList();
            return new ResultGetAllNewslettersServiceDto
            {
                Result = _result
            };
        }
    }
}
