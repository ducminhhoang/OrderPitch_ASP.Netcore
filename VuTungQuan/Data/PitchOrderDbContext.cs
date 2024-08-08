using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using VuTungQuan.Models;

namespace VuTungQuan.Data
{
    

    public class PitchOrderDbContext : DbContext
    {
        public PitchOrderDbContext(DbContextOptions<PitchOrderDbContext> options) : base(options) { }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<FootballPitch> FootballPitches { get; set; }
        public DbSet<PitchImage> PitchImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PitchType> PitchTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Discount>()
            .Property(d => d.Amount)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Discount>()
                .Property(d => d.UsageLimit)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<FootballPitch>()
                .Property(fp => fp.PricePerHour)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Bank>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Discount>()
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<FootballPitch>()
                .Property(fp => fp.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Order>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<PitchType>()
                .Property(pt => pt.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Account>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AccountType>()
                .Property(at => at.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<FootballPitch>()
                .HasMany(fp => fp.PitchImages)
                .WithOne(pi => pi.FootballPitch)
                .HasForeignKey(pi => pi.FootballPitchId);

            modelBuilder.Entity<FootballPitch>()
                .HasMany(fp => fp.Orders)
                .WithOne(o => o.FootballPitch)
                .HasForeignKey(o => o.FootballPitchId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Orders)
                .WithOne(o => o.account)
                .HasForeignKey(o => o.Id);

            modelBuilder.Entity<PitchType>()
                .HasMany(pt => pt.FootballPitches)
                .WithOne(fp => fp.PitchType)
                .HasForeignKey(fp => fp.PitchTypeId);
        }
    }

}
