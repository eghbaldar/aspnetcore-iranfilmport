using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranFilmPort.Infranstructure.Configurations.UserProjects
{
    public class UserProjectsConfigurations :
        IEntityTypeConfiguration<IranFilmPort.Domain.Entities.UserProjects.UserProjectPhotos>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.UserProjects.UserProjectPhotos> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDateTime == null);
        }
    }
}