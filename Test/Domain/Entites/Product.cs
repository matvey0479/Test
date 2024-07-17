using System.ComponentModel.DataAnnotations;

namespace Test.Domain.Entites
{
    public class Product:Entity
    {
        public Product (string name)
        {
            Name = name;
        }
        public Product() { }

        public string Name { get; set; }

        public List<PriceList> priceLists { get; set; }



    }
}
