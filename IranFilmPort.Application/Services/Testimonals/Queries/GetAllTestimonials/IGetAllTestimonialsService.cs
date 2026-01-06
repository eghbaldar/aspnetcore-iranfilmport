using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Helpers;

namespace IranFilmPort.Application.Services.Testimonals.Queries.GetAllTestimonials
{
    public class RequestGetAllTestimonialsServiceDto
    {
        public int CurrentPage { get; set; } // current page
    }
    public class GetAllTestimonialsServiceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string File { get; set; }
        public bool Type { get; set; } // false: image true:audio
        public DateTime InsertDateTime { get; set; }
    }
    public class ResutlGetAllTestimonialsServiceDto
    {
        public List<GetAllTestimonialsServiceDto> Result { get; set; }
        public int RowCount { get; set; }//  <---- pagination
        public int RowsOnEachPage { get; set; }//  <---- pagination
    }
    public interface IGetAllTestimonialsService
    {
        ResutlGetAllTestimonialsServiceDto Execute(RequestGetAllTestimonialsServiceDto req);
    }
    public class GetAllTestimonialsService : IGetAllTestimonialsService
    {
        private readonly IDataBaseContext _context;
        public GetAllTestimonialsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResutlGetAllTestimonialsServiceDto Execute(RequestGetAllTestimonialsServiceDto req)
        {
            int RowsCount; //<------ pagination
            int RowsOnEachPage = 50; //<------ pagination
            var result = _context.Testimonials
                .Select(x => new GetAllTestimonialsServiceDto
                {
                    Type = x.Type,
                    Name = x.Name,
                    File = x.File,
                    Id = x.Id,
                    InsertDateTime = x.InsertDateTime,
                })
                .OrderByDescending(x => x.InsertDateTime)
                .ToPaged(req.CurrentPage, RowsOnEachPage, out RowsCount) //  <----  pagination
                .ToList();
            return new ResutlGetAllTestimonialsServiceDto
            {
                Result = result,
                RowCount = RowsCount, //  <---- pagination
                RowsOnEachPage = RowsOnEachPage, //  <---- pagination
            };
        }
    }
}
