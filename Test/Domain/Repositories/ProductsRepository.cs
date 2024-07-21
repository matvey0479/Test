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
        public async Task<Product> GetProductByArticle(int article)
        {
            return await context.Products.FirstOrDefaultAsync(x => x.articleNumber == article);
        }

        public async Task AddProductAsync(PriceList priceList, Product product, List<Description>? descriptions)
        {
            priceList = await context.priceLists.Include(x=>x.Products)
                            .FirstOrDefaultAsync(x=>x.Id==priceList.Id);
            if(context.Products.FirstOrDefault(x => x.articleNumber == product.articleNumber)==null)
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
            }
            else
            {
                //priceList.Products.Remove(await context.Products.FirstOrDefaultAsync(x => x.articleNumber == product.articleNumber));
                product = await context.Products.Include(x=>x.descriptions)
                    .FirstOrDefaultAsync(x => x.articleNumber == product.articleNumber);
                foreach(var description in product.descriptions)
                {
                    context.descriptions.Remove(description);
                }
                priceList.Products.Remove(product);
                if (descriptions != null)
                {
                    foreach (var description in descriptions)
                    {
                        await context.descriptions.AddAsync(description);
                        product.descriptions.Add(description);
                    }
                }
                product.Name = product.Name;
                product.descriptions = product.descriptions;
                context.Products.Update(product);
                priceList.Products.Add(product);
            }
            
            await context.SaveChangesAsync();


        }
        public async Task DeleteProductAsync(PriceList priceList, int id)
        {        
            priceList.Products.Remove(context.Products.FirstOrDefault(product => product.Id == id));
            await context.SaveChangesAsync();
        }
    }
}
