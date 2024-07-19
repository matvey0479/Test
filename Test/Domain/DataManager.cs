using Test.Domain.Repositories;

namespace Test.Domain
{
    public class DataManager
    {
        public ColumnsRepository columns {  get; set; }
        public PriceListsRepository priceLists { get; set; }
        public ProductsRepository products { get; set; }
        public DataManager(ColumnsRepository columns, PriceListsRepository priceLists, ProductsRepository products)
        {
            this.columns = columns;
            this.priceLists = priceLists;
            this.products = products;
        }
    }
}
