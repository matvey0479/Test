using Test.Domain.Entites;

namespace Test.Models
{
    public class PriceListColumns
    {
        public PriceList priceList { get; set; }
        public List<Column> columns { get; set; }
    }
}
