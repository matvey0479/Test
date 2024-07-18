using System.ComponentModel.DataAnnotations;

namespace Test.Domain.Entites
{
    public class Product
    {
        public Product(int article, string name)
        {
            articleNumber = article;
            Name = name;
        }

        public Product() { }
        public int Id { get; set; }
        public int articleNumber { get; set; }
        public string Name { get; set; }
        public List<PriceList> priceLists { get; set; } = new List<PriceList>();
        public List<Description> descriptions { get; set; } = new List<Description>();



    }
}
 