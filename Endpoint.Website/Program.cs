using IranFilmPort.Application.Interfaces;
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
