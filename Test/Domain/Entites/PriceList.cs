namespace Test.Domain.Entites
{
    public class PriceList:Entity
    {
        public PriceList(string name)
        {
            date = DateTime.Now;
            Name = name;

        }
        public PriceList() { }
        public string Name { get; set; }
        public DateTime date { get; set; }
        public List<Column> Columns { get; set; }
        public List<Product> Products { get; set; }
       


    }


}
