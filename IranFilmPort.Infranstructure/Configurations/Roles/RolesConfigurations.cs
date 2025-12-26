using IranFilmPort.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace IranFilmPort.Infranstructure.Configurations.Roles
{
    public class RolesConfigurations : IEntityTypeConfiguration<IranFilmPort.Domain.Entities.User.Roles>
    {
        public void Configure(EntityTypeBuilder<IranFilmPort.Domain.Entities.User.Roles> builder)
        {
            builder.HasData(new IranFilmPort.Domain.Entities.User.Roles() { Id = Guid.NewGuid(), Title = RoleConstants.King });
            builder.HasData(new IranFilmPort.Domain.Entities.User.Roles() { Id = Guid.NewGuid(), Title = RoleConstants.SuperAdmin });
            builder.HasData(new IranFilmPort.Domain.Entities.User.Roles() { Id = Guid.NewGuid(), Title = RoleConstants.Admin });
            builder.HasData(new IranFilmPort.Domain.Entities.User.Roles() { Id = Guid.NewGuid(), Title = RoleConstants.Client});
            builder.HasData(new IranFilmPort.Domain.Entities.User.Roles() { Id = Guid.NewGuid(), Title = RoleConstants.User });
        }
    }
}
