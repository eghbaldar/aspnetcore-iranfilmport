using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Sliders.Queries.GetSliders
{
    public class RequestGetSlidersServiceDto
    {
        public byte take { get; set; }
    }
    public class GetSlidersServiceDto
    {
        public Guid Id { get; set; }
        public string File { get; set; }
        public string Text { get; set; }
        public string TextEn { get; set; }
        public string SubText { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
    public class ResutlGetSlidersServiceDto
    {
        public List<GetSlidersServiceDto> Result { get; set; }
    }
    public interface IGetSlidersService
    {
        ResutlGetSlidersServiceDto Execute(RequestGetSlidersServiceDto req);
    }
    public class GetSlidersService : IGetSlidersService
    {
        private readonly IDataBaseContext _context;
        public GetSlidersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResutlGetSlidersServiceDto Execute(RequestGetSlidersServiceDto req)
        {
            var result = _context.Sliders
                .Where(x => x.Active)
                .Select(x => new GetSlidersServiceDto
                {
                    Active = x.Active,
                    File = x.File,
                    Id = x.Id,
                    InsertDateTime = x.InsertDateTime,
                    Link = x.Link,
                    SubText = x.SubText,
                    Text = x.Text,
                    TextEn = x.TextEn,
                })
                .OrderByDescending(x => x.InsertDateTime)
                .Take(req.take)
                .ToList();
            return new ResutlGetSlidersServiceDto
            {
                Result = result,
            };
        }
    }
}
