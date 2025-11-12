using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SafeBoda.Core;

namespace SafeBoda.Infrastructure
{
    public class SafeBodaDbContext : IdentityDbContext<IdentityUser>
    {
        public SafeBodaDbContext(DbContextOptions<SafeBodaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rider> Riders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Important: Call base first
            
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ComplexProperty(e => e.Start);
                entity.ComplexProperty(e => e.End);
            });
        }
    }
}