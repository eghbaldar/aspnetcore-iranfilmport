using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranFilmPort.Infranstructure.Configurations.Sliders
{
    public class SlidersConfigurations : IEntityTypeConfiguration<IranFilmPort.Domain.Entities.Sliders.Sliders>
    {
        public void Configure(EntityTypeBuilder<IranFilmPort.Domain.Entities.Sliders.Sliders> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDateTime == null);
        }
    }
}