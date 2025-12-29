using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranFilmPort.Infranstructure.Configurations.FestivalSections
{
    public class FestivalSectionsConfigurations :
        IEntityTypeConfiguration<IranFilmPort.Domain.Entities.Festival.FestivalSections>
    {
        public void Configure(EntityTypeBuilder<IranFilmPort.Domain.Entities.Festival.FestivalSections> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDateTime == null);
        }
    }
}