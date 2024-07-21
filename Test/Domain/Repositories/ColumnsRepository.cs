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
        public async Task<Column> GetColumnsByNameAndDataTypeAsync(string name,string dataType)
        {
            return await context.Columns.FirstOrDefaultAsync(x => x.Name == name && x.DataType==dataType);
        }
        public async Task AddColumnAsync(Column column)
        {
            bool col = context.Columns.Any(x => x.Name == column.Name && x.DataType == column.DataType);
            if (!col)
            {
                await context.Columns.AddAsync(column);
                await context.SaveChangesAsync();
            }
        }

    }
}
