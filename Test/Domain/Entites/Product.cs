using System.ComponentModel.DataAnnotations;

namespace Test.Domain.Entites
{
    public class Product:Entity
    {
        public Product (string name, PriceList priceList)
        {
            Name = name;
            this.priceList = priceList;
        }
        public Product() { }

        public string Name { get; set; }

        public PriceList priceList { get; set; }



    }
}
