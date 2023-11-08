using Catalogue.Controllers;
using Catalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogue.DataBase
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext(DbContextOptions<CatalogueContext> options) : base(options)
        {
        }

        public DbSet<Hockey> Hockeys { get; set; }
        public DbSet<Baseball> Baseballs { get; set; }
        public DbSet<Velo> Velos { get; set; }
        public DbSet<Soccer> Soccers { get; set; }
        public DbSet<Panier> Paniers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Hockey>().ToTable("Hockey");
            //modelBuilder.Entity<Baseball>().ToTable("Baseball");
            //modelBuilder.Entity<Velo>().ToTable("Velo");
            //modelBuilder.Entity<Soccer>().ToTable("Soccer");
            //modelBuilder.Entity<Panier>().ToTable("Panier");
        }
    }
}
