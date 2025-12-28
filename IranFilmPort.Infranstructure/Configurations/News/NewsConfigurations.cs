using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranFilmPort.Infranstructure.Configurations.News
{
    public class NewsConfigurations : IEntityTypeConfiguration<IranFilmPort.Domain.Entities.News.News>
    {
        public void Configure(EntityTypeBuilder<IranFilmPort.Domain.Entities.News.News> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDateTime == null);
        }
    }
}