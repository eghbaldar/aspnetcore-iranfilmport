using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Interfaces.FacadePatternDapper;
using IranFilmPort.Application.Services._AdminStuff.FacadePattern;
using IranFilmPort.Application.Services._Turnstile;
using IranFilmPort.Application.Services.Accolades.FacadePattern;
using IranFilmPort.Application.Services.Common.Email;
using IranFilmPort.Application.Services.Common.Sitemap;
using IranFilmPort.Application.Services.Contacts.FacadePattern;
using IranFilmPort.Application.Services.Countires.FacadePattern;
using IranFilmPort.Application.Services.Courses.FacadePattern;
using IranFilmPort.Application.Services.FestivalDeadlines.FacadePattern;
using IranFilmPort.Application.Services.Festivals.FacadePattern;
using IranFilmPort.Application.Services.FestivalSection.FacadePattern;
using IranFilmPort.Application.Services.News.News.FacadePattern;
using IranFilmPort.Application.Services.NewsCategories.FacadePattern;
using IranFilmPort.Application.Services.NewsComments.FacadePattern;
using IranFilmPort.Application.Services.NewsLetters.FacadePattern;
using IranFilmPort.Application.Services.Roles.FacadePattern;
using IranFilmPort.Application.Services.SendInformation.FacadePattern;
using IranFilmPort.Application.Services.Settings.FacadePattern;
using IranFilmPort.Application.Services.Sliders.FacadePattern;
using IranFilmPort.Application.Services.TemporaryForms.FacadePattern;
using IranFilmPort.Application.Services.Testimonals.FacadePattern;
using IranFilmPort.Application.Services.UserProjectPhotos.FacadePattern;
using IranFilmPort.Application.Services.UserProjects.FacadePattern;
using IranFilmPort.Application.Services.UserRefreshToken;
using IranFilmPort.Application.Services.Users.FacadePattern;
using IranFilmPort.Application.Services.UsersLogs.Commands.PostUserLog;
using IranFilmPort.Application.Services.UsersSuspicious;
using IranFilmPort.Application.ServicesDapper.Films.FacadePattern;
using IranFilmPort.Common.Constants;
using IranFilmPort.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Services
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient(); // Add this line to register HttpClient
builder.Services.AddHttpContextAccessor();  // ✅
builder.Services.AddMemoryCache();
// Interface
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IDapperExecutor, DapperExecutor>();

// Interfcaes - Dapper
builder.Services.AddScoped<IFilmFacadePatternDapper, FilmFacadePatternDapper>();
// Interfcaes
builder.Services.AddScoped<ISitemapService, SitemapService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<INewsFacadePattern, NewsFacadePattern>();
builder.Services.AddScoped<IUsersFacadePattern, UsersFacadePattern>();
builder.Services.AddScoped<IRoleFacadePattern, RoleFacadePattern>();
builder.Services.AddScoped<INewsCategoriesFacadePattern, NewsCategoriesFacadePattern>();
builder.Services.AddScoped<INewsCommentsFacadePattern, NewsCommentsFacadePattern>();
builder.Services.AddScoped<IFestivalsFacadePattern, FestivalsFacadePattern>();
builder.Services.AddScoped<IFestivalSectionFacadePattern, FestivalSectionFacadePattern>();
builder.Services.AddScoped<IFestivalDeadlinesFacadePattern, FestivalDeadlinesFacadePattern>();
builder.Services.AddScoped<ICountiresFacadePattern, CountiresFacadePattern>();
builder.Services.AddScoped<IAdminStuffFacadePattern, AdminStuffFacadePattern>();
builder.Services.AddScoped<IUserProjectsFacadePattern, UserProjectsFacadePattern>();
builder.Services.AddScoped<IUserProjectPhotosFacadePattern, UserProjectPhotosFacadePattern>();
builder.Services.AddScoped<ISendInformationFacadePattern, SendInformationFacadePattern>();
builder.Services.AddScoped<ISettingsFacadePattern, SettingsFacadePattern>();
builder.Services.AddScoped<ITemporaryFormsFacadePattern, TemporaryFormsFacadePattern>();
builder.Services.AddScoped<ISlidersFacadePattern, SlidersFacadePattern>();
builder.Services.AddScoped<ITestimonalsFacadePattern, TestimonalsFacadePattern>();
builder.Services.AddScoped<IAccoladesFacadePattern, AccoladesFacadePattern>();
builder.Services.AddScoped<IContactFacadePattern, ContactFacadePattern>();
builder.Services.AddScoped<INewslettersFacadePattern, NewslettersFacadePattern>();
builder.Services.AddScoped<ICoursesFacadePattern, CoursesFacadePattern>();

// token and authentication services
builder.Services.AddScoped<ITurnstileService, TurnstileService>();
builder.Services.AddScoped<UserLogsService>();
builder.Services.AddScoped<UserRefreshTokenService>();
builder.Services.AddScoped<UsersSuspiciousService>();
builder.Services.AddScoped<UsersFacadePattern>();
#endregion Services

#region DataBase

//SqlServer Provider
var ConStr = builder.Configuration.GetConnectionString("LocalServer");

//var environment = builder.Environment.EnvironmentName;
//var ConStr = environment == "Development"
//                       ? builder.Configuration.GetConnectionString("LocalServer")
//                       : builder.Configuration.GetConnectionString("VpsServer");

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(x => x.UseSqlServer(ConStr));

#endregion DataBase

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("https://iranfilmport.com") // specify your frontend URL
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials()); // allow cookies
});
#endregion CORS

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseCookiePolicy();
//app.UseSession();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

#region Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion Routes

app.Run();
