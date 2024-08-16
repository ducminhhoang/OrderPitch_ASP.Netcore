using Microsoft.EntityFrameworkCore;
using TestApiPitchOrder.Data;
using TestApiPitchOrder.Models;

namespace TestApiPitchOrder.Data
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

            modelBuilder.Entity<Discount>(e =>
            {
                e.Property(fp => fp.Id).ValueGeneratedOnAdd();
                //e.Property(fp => fp.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(fp => fp.CreatedAt).HasDefaultValueSql("getdate()");  // for sqlserver
            });

            modelBuilder.Entity<FootballPitch>(e =>
            {
                e.Property(fp => fp.Id).ValueGeneratedOnAdd();
                e.Property(a => a.TimeStart).HasColumnType("time");
                e.Property(a => a.TimeEnd).HasColumnType("time");
                //e.Property(fp => fp.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(fp => fp.CreatedAt).HasDefaultValueSql("getdate()");  // for sqlserver
                e.HasMany(fp => fp.PitchImages).WithOne(pi => pi.FootballPitch).HasForeignKey(pi => pi.FootballPitchId);
                e.HasMany(fp => fp.Orders).WithOne(o => o.FootballPitch).HasForeignKey(o => o.FootballPitchId);
            });

            modelBuilder.Entity<Bank>(e =>
            {
                e.Property(fp => fp.Id).ValueGeneratedOnAdd();
                //e.Property(b => b.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(fp => fp.CreatedAt).HasDefaultValueSql("getdate()");  // for sqlserver
                e.HasMany(pt => pt.Orders).WithOne(fp => fp.Bank).HasForeignKey(fp => fp.BankId);
            });

            modelBuilder.Entity<Discount>(e =>
            {
                e.Property(fp => fp.Id).ValueGeneratedOnAdd();
                //e.Property(d => d.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(fp => fp.CreatedAt).HasDefaultValueSql("getdate()");  // for sqlserver
                e.HasMany(pt => pt.Orders).WithOne(fp => fp.Discount).HasForeignKey(fp => fp.DiscountId);
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.Property(fp => fp.Id).ValueGeneratedOnAdd();
                //e.Property(o => o.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(fp => fp.CreatedAt).HasDefaultValueSql("getdate()");  // for sqlserver
            });

            modelBuilder.Entity<PitchType>(e =>
            {
                e.Property(fp => fp.Id).ValueGeneratedOnAdd();
                //e.Property(pt => pt.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(fp => fp.CreatedAt).HasDefaultValueSql("getdate()");  // for sqlserver
                e.HasMany(pt => pt.FootballPitches).WithOne(fp => fp.PitchType).HasForeignKey(fp => fp.PitchTypeId);
            });

            modelBuilder.Entity<Account>(e =>
            {
                e.Property(fp => fp.Id).ValueGeneratedOnAdd();
                //e.Property(a => a.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(fp => fp.CreatedAt).HasDefaultValueSql("getdate()");  // for sqlserver
                e.HasMany(a => a.Orders).WithOne(o => o.Account).HasForeignKey(o => o.AccountId);
            });

            modelBuilder.Entity<AccountType>(e =>
            {
                e.Property(fp => fp.Id).ValueGeneratedOnAdd();
                //e.Property(at => at.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(fp => fp.CreatedAt).HasDefaultValueSql("getdate()");  // for sqlserver
                e.HasMany(a => a.Accounts).WithOne(o => o.AccountType).HasForeignKey(o => o.AccountTypeId);
            });

            SeedData.Initialize(modelBuilder);
        }
    }
}
