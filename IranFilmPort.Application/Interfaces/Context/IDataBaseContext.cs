using IranFilmPort.Domain.Entities.Accolades;
using IranFilmPort.Domain.Entities.Countries;
using IranFilmPort.Domain.Entities.Courses;
using IranFilmPort.Domain.Entities.Festival;
using IranFilmPort.Domain.Entities.Guest;
using IranFilmPort.Domain.Entities.News;
using IranFilmPort.Domain.Entities.Settings;
using IranFilmPort.Domain.Entities.Sliders;
using IranFilmPort.Domain.Entities.Testimonials;
using IranFilmPort.Domain.Entities.User;
using IranFilmPort.Domain.Entities.UserProjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IranFilmPort.Application.Interfaces.Context
{
    public interface IDataBaseContext : IDisposable
    {
        DatabaseFacade Database { get; }

        // Admin
        DbSet<Settings> Settings { get; set; }
        DbSet<Sliders> Sliders { get; set; }
        DbSet<Testimonials> Testimonials { get; set; }
        DbSet<Accolades> Accolades { get; set; }
        DbSet<Courses> Courses { get; set; }

        // User
        DbSet<Users> Users { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<UsersSuspicious> UsersSuspicious { get; set; }
        DbSet<UsersLogs> UsersLogs { get; set; }
        DbSet<UserRefreshToken> UserRefreshToken { get; set; }
        DbSet<UserProjects> UserProjects { get; set; }
        DbSet<UserProjectPhotos> UserProjectPhotos { get; set; }

        // news
        DbSet<News> News { get; set; }
        DbSet<NewsCategories> NewsCategories { get; set; }
        DbSet<NewsComments> NewsComments { get; set; }
        DbSet<NewsTags> NewsTags { get; set; }

        // guest
        DbSet<Contacts> Contacts { get; set; }
        DbSet<Newsletters> Newsletters { get; set; }
        DbSet<SendInformation> SendInformation { get; set; }
        DbSet<TemporaryForms> TemporaryForms { get; set; }

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
