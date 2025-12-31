using IranFilmPort.Domain.Entities.Contact;
using IranFilmPort.Domain.Entities.Countries;
using IranFilmPort.Domain.Entities.Festival;
using IranFilmPort.Domain.Entities.News;
using IranFilmPort.Domain.Entities.Newsletter;
using IranFilmPort.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IranFilmPort.Application.Interfaces.Context
{
    public interface IDataBaseContext : IDisposable
    {
        DatabaseFacade Database { get; }

        // User
        DbSet<Users> Users { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<UsersSuspicious> UsersSuspicious { get; set; }
        DbSet<UsersLogs> UsersLogs { get; set; }
        DbSet<UserRefreshToken> UserRefreshToken { get; set; }

        // news
        DbSet<News> News { get; set; }
        DbSet<NewsCategories> NewsCategories { get; set; }
        DbSet<NewsComments> NewsComments { get; set; }
        DbSet<NewsTags> NewsTags { get; set; }

        // guest
        DbSet<Contacts> Contacts { get; set; }
        DbSet<Newsletters> Newsletters { get; set; }

        // festival
        DbSet<Countries> Countries { get; set; }
        DbSet<Festivals> Festivals { get; set; }
        DbSet<FestivalSections> FestivalSections { get; set; }
        DbSet<FestivalDeadlines> FestivalDeadlines { get; set; }

        //SaveChanges
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
