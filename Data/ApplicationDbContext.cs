using CinemaApp.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ShopApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ProductInOrder> ProductsInOrder { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductInShoppingCart> ProductsInShoppingCarts { get; set; }
        public virtual DbSet<ShopApplicationUser> ShopApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductInShoppingCart>().HasKey(c => new { c.CartId, c.ProductId });
            builder.Entity<ProductInOrder>().HasKey(c => new { c.OrderId, c.ProductId });
        }


    }
}
