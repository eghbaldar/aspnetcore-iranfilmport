using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategoriesBySubId
{
    public class GetNewsCategoriesBySubIdServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? SubId { get; set; } // برای دسته بندی های زیر دسته قبلی
    }
}
