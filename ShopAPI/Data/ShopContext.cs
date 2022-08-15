using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;

namespace ShopAPI.Data
{
    public class ShopContext: DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Buy> Buys { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<BuyForShop> BuyForShops { get; set; } = null!;
        public DbSet<FinalBuy> FinalBuys { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set;} = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.IdCategory);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Role)
                .WithMany()
                .HasForeignKey(s => s.IdRole);

            modelBuilder.Entity<Buy>()
                .HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(b => b.IdProduct);

            modelBuilder.Entity<Buy>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(b => b.IdUser);

            modelBuilder.Entity<BuyForShop>()
                .HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(b => b.IdProduct);

            modelBuilder.Entity<FinalBuy>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(b => b.IdUser);

            modelBuilder.Entity<Purchase>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(b => b.IdUser);


            modelBuilder.Entity<Buy>()
                .HasOne<FinalBuy>()
                .WithMany(p => p.UserBasket);

            modelBuilder.Entity<BuyForShop>()
                .HasOne<Purchase>()
                .WithMany(p => p.BuyForShops);
        }
    }
    
}
