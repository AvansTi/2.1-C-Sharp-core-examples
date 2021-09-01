using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveWPF_Week6.Models
{
    public class ShoppingCardContext : DbContext
    {

        public DbSet<ShoppingItem> ShoppingItem { get; set; }

        public DbSet<ItemCatogory> ItemCatogories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("server=localhost;database=shoppingcard;user=ShoppingCard;password=ShoppingCard");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
