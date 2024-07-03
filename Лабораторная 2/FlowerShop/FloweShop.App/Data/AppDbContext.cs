using FloweShop.App.Models;
using Microsoft.EntityFrameworkCore;

namespace FloweShop.App.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<CompositionFlower> CompositionFlowers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=flowers;Username=postgres;Password=12345");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flower>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Sort).IsRequired();
                entity.Property(e => e.PricePerFlower).HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Composition>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<CompositionFlower>(entity =>
            {
                entity.HasKey(e => new { e.CompositionId, e.FlowerId });

                entity.HasOne(cf => cf.Composition)
                      .WithMany(c => c.CompositionFlowers)
                      .HasForeignKey(cf => cf.CompositionId);

                entity.HasOne(cf => cf.Flower)
                      .WithMany(f => f.CompositionFlowers)
                      .HasForeignKey(cf => cf.FlowerId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Login).IsRequired();
                entity.Property(e => e.Password).IsRequired();

                entity.HasMany(u => u.Orders)
                      .WithOne(o => o.User)
                      .HasForeignKey(o => o.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.DateOfCompletion).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.TotalPrice).IsRequired().HasColumnType("decimal(10,2)");

                entity.HasOne(o => o.Composition)
                      .WithMany()
                      .HasForeignKey(o => o.CompositionId);

                entity.HasOne(o => o.User)
                      .WithMany(u => u.Orders)
                      .HasForeignKey(o => o.UserId);
            });
        }
    }
}