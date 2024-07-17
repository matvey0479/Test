﻿using Microsoft.EntityFrameworkCore;
using Test.Domain.Entites;
namespace Test.Domain
{
    public class PriceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<PriceList> priceLists { get; set; }

        public PriceContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Column>().HasData(
                new Column { id=1,Name = "Название товара", DataType = "Текст" },
                new Column { id=2,Name = "Код товара", DataType = "Число" }
                );
            



        }
    }
}