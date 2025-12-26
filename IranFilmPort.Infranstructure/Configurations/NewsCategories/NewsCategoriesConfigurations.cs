using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranFilmPort.Infranstructure.Configurations.NewsCategories
{
    public class NewsCategoriesConfigurations : IEntityTypeConfiguration<IranFilmPort.Domain.Entities.News.NewsCategories>
    {
        public void Configure(EntityTypeBuilder<IranFilmPort.Domain.Entities.News.NewsCategories> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDateTime == null);
        }
    }
}