using Microsoft.EntityFrameworkCore;
using BioBank.Models;

namespace BioBank.Data
{
    public class BioBankContext : DbContext
    {
        public BioBankContext(DbContextOptions<BioBankContext> options)
            : base(options)
        {
        }

        public DbSet<Collection> Collections { get; set; }
        public DbSet<Sample> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collection>().ToTable("Collection");
            modelBuilder.Entity<Sample>().ToTable("Sample");
        }
    }
}
