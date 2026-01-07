using IranFilmPort.Application.Interfaces.Context;
using Microsoft.AspNetCore.Http;

namespace IranFilmPort.Application.Services.AdvertisementModals.Queries.GetAllModals
{
    public class GetAllModalsServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BlinkText { get; set; }
        public string SubText1 { get; set; }
        public string LinkSubText1 { get; set; }
        public string SubText2 { get; set; }
        public string LinkSubText2 { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }
        public long Visit { get; set; }
        public bool Active { get; set; } // only one record can be activated
        public DateTime InsertDateTime { get; set; }
    }
    public class ResutlGetAllModalsServiceDto
    {
        public List<GetAllModalsServiceDto> Result { get; set; }
    }
    public interface IGetAllModalsService
    {
        ResutlGetAllModalsServiceDto Execute();
    }
    public class GetAllModalsService : IGetAllModalsService
    {
        private readonly IDataBaseContext _context;
        public GetAllModalsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResutlGetAllModalsServiceDto Execute()
        {
            var result = _context.AdvertisementModals
                .Select(x => new GetAllModalsServiceDto
                {
                    Id = x.Id,
                    InsertDateTime = x.InsertDateTime,
                    Title = x.Title,
                    BlinkText = x.BlinkText,
                    Active = x.Active,
                    Color = x.Color,
                    LinkSubText1 = x.LinkSubText1,
                    LinkSubText2 = x.LinkSubText2,
                    Photo = x.Photo,
                    SubText1 = x.SubText1,
                    SubText2 = x.SubText2,
                    Visit = x.Visit,                    
                })
                .OrderByDescending(x => x.InsertDateTime)
                .ToList();
            return new ResutlGetAllModalsServiceDto
            {
                Result = result,
            };
        }
    }
}
