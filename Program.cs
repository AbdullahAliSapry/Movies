using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using WebsiteMovies.data;
using WebsiteMovies.Models;
using WebsiteMovies.Repository;
using WebsiteMovies.Repository.IRepository;
using WebsiteMovies.WebServises;
namespace WebsiteMovies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppllicationDbContext>(
                options => options.UseSqlServer(builder.Configuration
                .GetConnectionString("DevlopmentConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>
                (option=> option.SignIn.RequireConfirmedEmail=true)
             .AddEntityFrameworkStores<AppllicationDbContext>();
               

            builder.Services
                .AddScoped<IMovieRepository,
                MovieRepository>();    
            builder.Services
                .AddScoped<ICinemaRepository,
                CinemaRepository >();

            builder.Services
                .AddScoped<IActorRepsitory,
                ActorRepository>();

            builder.Services
                .AddScoped<ICategoryRepository,
                CategoryRepository>();
            //builder.Services.AddTransient<IEmailSender, EmailSender>();
            //builder.Services.Configure<AuthMessageSenderOptions>
                //(builder.Configuration);
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days.
                // You may want to change this for production
                // scenarios, see https://aka.ms/aspnetcore-hsts.
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
