using Aruba.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// https://database.guide/how-to-install-sql-server-on-a-mac/
// https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash

namespace Aruba.Data
{
    public class IslandDbContext : IdentityDbContext<StoreUser>
    {
        public IslandDbContext(DbContextOptions<IslandDbContext> options) : base(options)
        {

        }

        public DbSet<Island> Islands { get; set; }
        public DbSet<HolidayCategory> HolidayCategories { get; set; }
        public DbSet<HolidayPackage> HolidayPackages { get; set; }

        public DbSet<Element> Elements { get; set; }
       // public DbSet<StoreUser> StoreUser { get; set; }
        public DbSet<ElementOccurrence> ElementOccurrences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasIndex(p => new { p.Name });
               // entity.HasKey(p => p.AtomicNumber);

                entity.Property(p => p.Symbol).HasMaxLength(2);
                //entity.Property(p => p.Description).HasColumnType("varchar 1024");

                //entity.Property(p => p.Price).IsRequired();
                //entity.Property(p => p.AtomicNumber).IsRequired();
                //entity.Property(p => p.Symbol).IsRequired();
                //entity.Property(p => p.Name).IsRequired();
                //entity.Property(p => p.Description).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

    }

}

