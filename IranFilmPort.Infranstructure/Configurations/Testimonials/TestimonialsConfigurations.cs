using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranFilmPort.Infranstructure.Configurations.Testimonials
{
    public class TestimonialsConfigurations :
        IEntityTypeConfiguration<IranFilmPort.Domain.Entities.Testimonials.Testimonials>
    {
        public void Configure(EntityTypeBuilder<IranFilmPort.Domain.Entities.Testimonials.Testimonials> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDateTime == null);
        }
    }
}