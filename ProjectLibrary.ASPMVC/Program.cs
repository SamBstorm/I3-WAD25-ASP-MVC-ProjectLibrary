using Microsoft.Data.SqlClient;
using ProjectLibrary.ASPMVC.Handlers;
using ProjectLibrary.Common.Repositories;

namespace ProjectLibrary.ASPMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Récupération de la connectionstring du fichier appsettings.json
            string connectionString = builder.Configuration.GetConnectionString("ProjectLibrary.Database")!;
            string sessionConnectionString = builder.Configuration.GetConnectionString("ProjectLibrary.Session")!;

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Ajouts des services nécessaires aux sessions
                // Donne accès à l'HttpContext dans n'importe quelle class => SessionManager
            builder.Services.AddHttpContextAccessor();
                // Ajout d'injection de dépendance pour une accessibilité simplifié de notre session
            builder.Services.AddScoped<UserSessionManager>();
            builder.Services.AddScoped<RentSessionManager>();

            // Configuration des cookies de sessions
            builder.Services.AddDistributedMemoryCache();

                // Si phase de production, alors activer le SQLServer Cache au lieu du Memory Cache
            /*builder.Services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = sessionConnectionString;
                options.SchemaName = builder.Configuration.GetSection("SessionInfos").GetValue<String>("SchemaName");
                options.TableName = builder.Configuration.GetSection("SessionInfos").GetValue<String>("TableName");
            });*/
            builder.Services.AddSession(options =>
                {
                    options.Cookie.Name = "LibraryProject.Session";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                    options.IdleTimeout = TimeSpan.FromMinutes(2);
                });
            builder.Services.Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                    options.Secure = CookieSecurePolicy.Always;
                });

            // Ajouts de nos services

            // Injection de dépendance d'un SqlConnection avec la connectionString
            builder.Services.AddScoped<SqlConnection>(serviceProdiver =>
            new SqlConnection(connectionString));
            
            // Injection de dépendance de nos services
            builder.Services.AddScoped<IBookRepository<BLL.Entities.Book>, BLL.Services.BookService>();
            builder.Services.AddScoped<IBookRepository<DAL.Entities.Book>, DAL.Services.BookService>();
            builder.Services.AddScoped<IUserProfileRepository<BLL.Entities.UserProfile>, BLL.Services.UserProfileService>();
            builder.Services.AddScoped<IUserProfileRepository<DAL.Entities.UserProfile>, DAL.Services.UserProfileService>();
            builder.Services.AddScoped<IUserRepository<BLL.Entities.User>, BLL.Services.UserService>();
            builder.Services.AddScoped<IUserRepository<DAL.Entities.User>, DAL.Services.UserService>();

            //En cas d'utilisation d'un FakeService permettant de ne pas avoir l'accès en DB
            //builder.Services.AddScoped<IBookRepository<DAL.Entities.Book>, DAL.Services.FakeBookService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseCookiePolicy();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
