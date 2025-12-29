using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranFilmPort.Infranstructure.Configurations.FestivalDeadlines
{
    public class FestivalDeadlinesConfigurations :
        IEntityTypeConfiguration<IranFilmPort.Domain.Entities.Festival.FestivalDeadlines>
    {
        public void Configure(EntityTypeBuilder<IranFilmPort.Domain.Entities.Festival.FestivalDeadlines> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDateTime == null);
        }
    }
}