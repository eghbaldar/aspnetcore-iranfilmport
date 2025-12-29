using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranFilmPort.Infranstructure.Configurations.Festivals
{
    public class FestivalsConfigurations : IEntityTypeConfiguration<IranFilmPort.Domain.Entities.Festival.Festivals>
    {
        public void Configure(EntityTypeBuilder<IranFilmPort.Domain.Entities.Festival.Festivals> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDateTime == null);
        }
    }
}