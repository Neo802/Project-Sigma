using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;
namespace ProjectRunAway.Models
{
    public class TableContext : IdentityDbContext<IdentityUser>

    {

        public TableContext(DbContextOptions<TableContext> options)

        : base(options)

        { }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Orders> Orders{ get; set; }
        public DbSet<Liability> Liability { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Extra> Extra { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Availability>()
                .HasKey(sc => new { sc.CarsId, sc.LocationsId });

            modelBuilder.Entity<Availability>()
                .HasOne(sc => sc.Cars)
                .WithMany(s => s.Availability)
                .HasForeignKey(sc => sc.CarsId);

            modelBuilder.Entity<Availability>()
                .HasOne(sc => sc.Locations)
                .WithMany(c => c.Availability)
                .HasForeignKey(sc => sc.LocationsId);

            modelBuilder.Entity<Orders>()
            .HasKey(o => o.OrderId);

            modelBuilder.Entity<Orders>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Orders>()
                .HasOne(o => o.Cars)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CarsId);
        }

    }
}
