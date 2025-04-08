using ETickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActors>()
                .HasKey(a => new { a.MovieId, a.ActorId });
            modelBuilder.Entity<MovieActors>()
                .HasOne(a => a.Movie)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(a => a.MovieId);
            modelBuilder.Entity<MovieActors>()
                .HasOne(a => a.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(a => a.ActorId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<MovieActors> MovieActors { get; set; }
    }
}
