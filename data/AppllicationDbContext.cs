using Azure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebsiteMovies.Models;
using WebsiteMovies.ViewModel;

namespace WebsiteMovies.data
{
    public class AppllicationDbContext : 
        IdentityDbContext<ApplicationUser>
    {
       public DbSet<Movie> Movies { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Cinema> Cinemas { get; set; }
       public DbSet<Actor> Actors { get; set; }

        public AppllicationDbContext(DbContextOptions<AppllicationDbContext>
            options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasMany(e => e.Actors)
              .WithMany(e => e.Movies).UsingEntity("MovieActor",
                 l => l.HasOne(typeof(Actor)).WithMany()
                 .HasForeignKey("ActorId"),
                 r => r.HasOne(typeof(Movie)).WithMany()
                 .HasForeignKey("MovieId"),
                 j => j.HasKey("ActorId", "MovieId"));

            modelBuilder.Entity<Cinema>()
                .HasMany(e => e.Movies)
                .WithOne(e => e.Cinema)
                .HasForeignKey(e=>e.CinemaId);

            modelBuilder.Entity<Category>()
            .HasMany(e => e.Movies)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId);
        }
        public DbSet<WebsiteMovies.ViewModel.MovieVm> MovieVm { get; set; } = default!;
        public DbSet<WebsiteMovies.ViewModel.CategoryVm> CategoryVm { get; set; } = default!;
        public DbSet<WebsiteMovies.ViewModel.ApplicationUserVm> ApplicationUserVm { get; set; } = default!;
        public DbSet<WebsiteMovies.ViewModel.LoginUserVm> LoginUserVm { get; set; } = default!;

    }
}
