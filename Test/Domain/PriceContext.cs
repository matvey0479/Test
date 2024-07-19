using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System;
using Test.Domain.Entites;
namespace Test.Domain
{
    public class PriceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<PriceList> priceLists { get; set; }
        public DbSet<Description> descriptions { get; set; }

        public PriceContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<PriceList>()
                .HasIndex(p => new { p.Name })
                .IsUnique();

            modelbuilder.Entity<Product>()
               .HasIndex(p => new { p.articleNumber })
               .IsUnique();
            

            modelbuilder.Entity<Column>().HasData(
                new Column { Id=1,Name = "Название товара", DataType = "Текст" },
                new Column { Id=2,Name = "Код товара", DataType = "Число" }
                );
            



        }
    }
}