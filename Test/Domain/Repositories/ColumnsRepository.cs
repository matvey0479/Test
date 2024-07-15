namespace Test.Domain.Repositories
{
    public class ColumnsRepository
    {
        private readonly PriceContext context;

        public ColumnsRepository(PriceContext context) 
        {
            this.context = context;
        }

    }
}
