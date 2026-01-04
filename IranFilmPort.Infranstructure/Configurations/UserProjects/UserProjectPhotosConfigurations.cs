using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranFilmPort.Infranstructure.Configurations.UserProjects
{
    public class UserProjectPhotosConfigurations : 
        IEntityTypeConfiguration<IranFilmPort.Domain.Entities.UserProjects.UserProjects>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.UserProjects.UserProjects> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDateTime == null);
        }
    }
}