using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranFilmPort.Application.Services.NewsCategories.Queries.GetNewsCategoriesById
{
    public interface IGetNewsCategoriesByIdService
    {
        ResultGetNewsCategoriesByIdServiceDto Execute(RequestGetNewsCategoriesByIdServiceDto req);
    }
}
