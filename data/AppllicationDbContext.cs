using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebsiteMovies.Models;

namespace WebsiteMovies.data
{
    public class AppllicationDbContext : DbContext
    {
       public DbSet<Movie> Movies { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Cinema> Cinemas { get; set; }
       public DbSet<Actor> Actors { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var bulider = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            var connectionString = bulider.GetConnectionString("DevlopmentConnection");
            optionsBuilder.UseSqlServer(connectionString);

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

    }
}
