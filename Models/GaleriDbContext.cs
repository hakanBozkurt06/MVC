using Microsoft.EntityFrameworkCore;

namespace VehicleGallery.Models
{
    public class GaleriDbContext : DbContext
    {
        public DbSet<Arac> Araclar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GaleriDb;Integrated Security=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Arac>().Property(a => a.Marka).HasColumnType("varchar").HasMaxLength(30).IsRequired();

            modelBuilder.Entity<Arac>().Property(a => a.Model).HasColumnType("varchar").HasMaxLength(40).IsRequired();
        }
    }
}
