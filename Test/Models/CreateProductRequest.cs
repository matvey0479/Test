using Test.Domain.Entites;
namespace Test.Models
{
    public class CreateProductRequest
    {
        public PriceList priceList { get; set; }
        public Product product { get; set; }
        public Description description { get; set; }
        public CreateProductRequest() { }
    }
}
