

using Galaxy.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace Galaxy.Storage.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Feedback> Feedbacks { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Router> Routers { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
