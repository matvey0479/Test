using Test.Domain.Entites;
using Test.Domain;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Test.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Test.Domain.Repositories
{
    public class ProductsRepository
    {
        private readonly PriceContext context;
        public ProductsRepository(PriceContext context)
        {
            this.context = context;
        }

        public async Task AddProductAsync(PriceList priceList, Product product, List<Description>? descriptions)
        {

            await context.Products.AddAsync(product);
            if (descriptions != null)
            {
                foreach (var description in descriptions)
                {
                    await context.descriptions.AddAsync(description);
                    product.descriptions.Add(description);
                }
            }
            priceList.Products.Add(product);
            await context.SaveChangesAsync();



        }
        public async Task DeleteProductAsync(PriceList priceList, int id)
        {        
            priceList.Products.Remove(context.Products.FirstOrDefault(product => product.Id == id));
            await context.SaveChangesAsync();
        }
    }
}
