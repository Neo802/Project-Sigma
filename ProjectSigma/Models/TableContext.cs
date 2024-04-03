using Microsoft.EntityFrameworkCore;
namespace ProjectRunAway.Models
{
    public class TableContext : DbContext

    {

        public TableContext(DbContextOptions<TableContext> options)

        : base(options)

        { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Liability> Liability { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Availability> Availability { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }

    }
}
