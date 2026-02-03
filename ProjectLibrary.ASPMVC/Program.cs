using Microsoft.Data.SqlClient;
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

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Ajouts de nos services

            // Injection de dépendance d'un SqlConnection avec la connectionString
            builder.Services.AddScoped<SqlConnection>(serviceProdiver =>
            new SqlConnection(connectionString));
            
            // Injection de dépendance de nos services
            builder.Services.AddScoped<IBookRepository<BLL.Entities.Book>, BLL.Services.BookService>();
            builder.Services.AddScoped<IBookRepository<DAL.Entities.Book>, DAL.Services.BookService>();
            builder.Services.AddScoped<IUserProfileRepository<BLL.Entities.UserProfile>, BLL.Services.UserProfileService>();
            builder.Services.AddScoped<IUserProfileRepository<DAL.Entities.UserProfile>, DAL.Services.UserProfileService>();

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
