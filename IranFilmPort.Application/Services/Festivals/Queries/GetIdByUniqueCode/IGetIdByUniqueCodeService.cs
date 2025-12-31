using IranFilmPort.Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranFilmPort.Application.Services.Festivals.Queries.GetIdByUniqueCode
{
    public class RequestGetIdByUniqueCodeDto
    {
        public int UniqueCode { get; set; }
    }
    public interface IGetIdByUniqueCodeService
    {
        Guid Execute(RequestGetIdByUniqueCodeDto req);
    }
    public class GetIdByUniqueCodeService: IGetIdByUniqueCodeService
    {
        private readonly IDataBaseContext _context;
        public GetIdByUniqueCodeService(IDataBaseContext context)
        {
            _context = context;
        }
        public Guid Execute(RequestGetIdByUniqueCodeDto req)
        {
            if (req == null) return Guid.Empty;
            var festival = _context.Festivals.FirstOrDefault(x => x.UniqueCode == req.UniqueCode);
            if (festival == null) return Guid.Empty;
            return festival.Id;
        }
    }
}
