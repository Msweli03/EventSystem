using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EventSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace EventSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring the Registration entity
            modelBuilder.Entity<Registration>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Registration>()
                .HasIndex(r => r.ReferenceNumber)
                .IsUnique();

            modelBuilder.Entity<Registration>()
               .Property(r => r.EmailAddress)
               .IsRequired()
               .HasMaxLength(255);

            // Seed Data for Events
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Name = "Tech Festival", Date = DateTime.Now.AddDays(10), TotalSeats = 100, SeatsAvailable = 100, Description = "A festival for technology enthusiasts." },
                new Event { Id = 2, Name = "Webinar Event", Date = DateTime.Now.AddDays(15), TotalSeats = 150, SeatsAvailable = 150, Description = "An informative webinar on latest tech trends."},
                new Event { Id = 3, Name = "Food Eating Contest", Date = DateTime.Now.AddDays(20), TotalSeats = 200, SeatsAvailable = 200, Description = "A fun contest to see who can eat the most!" },
                new Event { Id = 4, Name = "Let's Code Event", Date = DateTime.Now.AddDays(25), TotalSeats = 250, SeatsAvailable = 250, Description = "A coding event to showcase your skills." }
            );
        }
    }
}
