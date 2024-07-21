using Test.Domain.Entites;
using Test.Domain;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Domain.Repositories
{
    public class PriceListsRepository
    {
        private readonly PriceContext context;

        public PriceListsRepository(PriceContext context) 
        { 
            this.context = context;
        }

        public async Task<List<PriceList>> GetPriceListsAsync()
        {
            List<PriceList> priceLists = await context.priceLists.ToListAsync();
            return priceLists;
        }

        public async Task<PriceList> GetPriceListByIdAsync(int id)
        {
            var priceList = await context.priceLists.Include(list => list.Columns)
                .Include(list => list.Products)
                .ThenInclude(prod => prod.descriptions)
                .FirstOrDefaultAsync(list => list.Id == id);
            return priceList;
        }
        public async Task<PriceList> GetPriceListColumnsByIdAsync(int id)
        {
            var priceList = await context.priceLists.Include(list => list.Columns)
                                           .FirstOrDefaultAsync(list => list.Id == id);
            return priceList;
        }
        public async Task<PriceList> GetPriceListProductsByIdAsync(int id)
        {
            var priceList = await context.priceLists.Include(price => price.Products)
                                    .FirstOrDefaultAsync(price => price.Id == id);
            return priceList;
        }

        public async Task AddPriceListAsync(PriceList priceList,List<Column> columns)
        {           
            await context.priceLists.AddAsync(priceList);
            priceList.Columns.AddRange(columns);
            await context.SaveChangesAsync();         
        }
    }
}
