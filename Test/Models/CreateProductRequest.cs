using Test.Domain.Entites;
namespace Test.Models
{
    public class CreateProductRequest
    {
        public PriceList priceList { get; set; }
        public Product product { get; set; }
        public List<Description> descriptions { get; set; }
        public CreateProductRequest() { }
    }
}
