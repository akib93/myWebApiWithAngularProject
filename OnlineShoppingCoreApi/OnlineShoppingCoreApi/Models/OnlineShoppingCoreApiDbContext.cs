using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCoreApi.Models;
using OnlineShoppingMvcApi.Models;

namespace OnlineShoppingCoreApi.Models
{
    public class OnlineShoppingCoreApiDbContext : IdentityDbContext<IdentityUser>
    {
        public OnlineShoppingCoreApiDbContext(DbContextOptions<OnlineShoppingCoreApiDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
                );
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<CancelOrder> CancelOrders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Shippment> Shippments { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<CustomShippingAddress> CustomShippingAddress { get; set; }
        public DbSet<CompletedOrder> CompletedOrders { get; set; }

    }
}
