using IranFilmPort.Domain.Entities.Contact;
using IranFilmPort.Domain.Entities.News;
using IranFilmPort.Domain.Entities.Newsletter;
using IranFilmPort.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IranFilmPort.Application.Interfaces
{
    public interface IDataBaseContext : IDisposable
    {
        DatabaseFacade Database { get; }

        // User
        DbSet<Users> Users { get; set; }
        DbSet<Roles> Roles { get; set; }

        // news
        DbSet<News> News { get; set; }
        DbSet<NewsCategories> NewsCategories { get; set; }
        DbSet<NewsComments> NewsComments { get; set; }
        DbSet<NewsTags> NewsTags { get; set; }

        // guest
        DbSet<Contacts> Contacts { get; set; }
        DbSet<Newsletters> Newsletters { get; set; }

        //SaveChanges
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
