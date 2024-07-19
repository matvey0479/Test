using Test.Domain.Entites;
using Test.Domain;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.EntityFrameworkCore;
namespace Test.Domain.Repositories
{
    public class ColumnsRepository
    {
        private readonly PriceContext context;

        public ColumnsRepository(PriceContext context) 
        {
            this.context = context;
        }

        public async Task<List<Column>> GetColumnsAsync()
        {
            return await context.Columns.ToListAsync();
        }
        public async Task<Column> GetColumnsByIdAsync(int id)
        {
            return await context.Columns.FirstOrDefaultAsync(x=>x.Id == id);
        }
        public async Task AddColumnAsync(Column column)
        {
            if(!context.Columns.Where(x=>x.DataType==column.DataType && x.Name == column.Name).Any())
            {
                await context.Columns.AddAsync(column);
            }
        }

    }
}
