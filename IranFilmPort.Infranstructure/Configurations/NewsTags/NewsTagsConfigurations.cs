using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranFilmPort.Infranstructure.Configurations.NewsTags
{
    public class NewsTagsConfigurations : IEntityTypeConfiguration<IranFilmPort.Domain.Entities.News.NewsTags>
    {
        public void Configure(EntityTypeBuilder<IranFilmPort.Domain.Entities.News.NewsTags> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDateTime == null);
        }
    }
}