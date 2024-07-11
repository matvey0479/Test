using Microsoft.EntityFrameworkCore;
using Test.Domain.Entites;
namespace Test.Domain
{
    public class PriceContext: DbContext
    {
        public DbSet<Product> Products { get; set;}
        public DbSet<Column> Columns { get; set;}
        public DbSet<PriceList> priceLists { get; set;}

        public PriceContext(DbContextOptions options) : base(options) { }
    }
}
