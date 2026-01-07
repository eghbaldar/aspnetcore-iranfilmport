using IranFilmPort.Application.Interfaces.Context;
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
using IranFilmPort.Infranstructure.Configurations.FestivalDeadlines;
using IranFilmPort.Infranstructure.Configurations.Festivals;
using IranFilmPort.Infranstructure.Configurations.FestivalSections;
using IranFilmPort.Infranstructure.Configurations.News;
using IranFilmPort.Infranstructure.Configurations.NewsTags;
using IranFilmPort.Infranstructure.Configurations.Roles;
using IranFilmPort.Infranstructure.Configurations.Sliders;
using IranFilmPort.Infranstructure.Configurations.Testimonials;
using IranFilmPort.Infranstructure.Configurations.UserProjects;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IranFilmPort.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        // Admin
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Sliders> Sliders { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Accolades> Accolades { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<AdvertisementModals> AdvertisementModals { get; set; }
        public DbSet<Pages> Pages { get; set; }

        // users
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UsersSuspicious> UsersSuspicious { get; set; }
        public DbSet<UsersLogs> UsersLogs { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }
        public DbSet<UserProjects> UserProjects { get; set; }
        public DbSet<UserProjectPhotos> UserProjectPhotos { get; set; }

        // news
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategories> NewsCategories { get; set; }
        public DbSet<NewsComments> NewsComments { get; set; }
        public DbSet<NewsTags> NewsTags { get; set; }

        // guest
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Newsletters> Newsletters { get; set; }
        public DbSet<SendInformation> SendInformation { get; set; }
        public DbSet<TemporaryForms> TemporaryForms { get; set; }
        public DbSet<JobRequests> JobRequests { get; set; }

        // Festival
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Festivals> Festivals { get; set; }
        public DbSet<FestivalSections> FestivalSections { get; set; }
        public DbSet<FestivalDeadlines> FestivalDeadlines { get; set; }

        // Entities Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Microsoft.EntityFrameworkCore.Relational
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfiguration(new RolesConfigurations());
            modelBuilder.ApplyConfiguration(new NewsConfigurations());
            modelBuilder.ApplyConfiguration(new NewsTagsConfigurations());
            modelBuilder.ApplyConfiguration(new NewsTagsConfigurations());
            modelBuilder.ApplyConfiguration(new FestivalDeadlinesConfigurations());
            modelBuilder.ApplyConfiguration(new FestivalsConfigurations());
            modelBuilder.ApplyConfiguration(new FestivalSectionsConfigurations());
            modelBuilder.ApplyConfiguration(new UserProjectsConfigurations());
            modelBuilder.ApplyConfiguration(new UserProjectPhotosConfigurations());
            modelBuilder.ApplyConfiguration(new SlidersConfigurations());
            modelBuilder.ApplyConfiguration(new TestimonialsConfigurations());
        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
           .Where(e =>
               e.State == EntityState.Modified ||
               e.State == EntityState.Added ||
               e.State == EntityState.Deleted
               ).ToList();
            foreach (var entry in modifiedEntries)
            {
                var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());
                var inserted = entityType.FindProperty("InsertDate");
                var updated = entityType.FindProperty("UpdateDate");
                var deleted = entityType.FindProperty("DeleteDate");
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (inserted != null) entry.Property("InsertDate").CurrentValue = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        if (updated != null) entry.Property("UpdateDate").CurrentValue = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        if (deleted != null)
                        {
                            entry.Property("DeleteDate").CurrentValue = DateTime.Now;
                            entry.State = EntityState.Modified;
                        }
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
