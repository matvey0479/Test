namespace Test.Domain.Entites
{
    public class PriceList
    {
        public PriceList(string name)
        {
            date = DateTime.Now;
            Name = name;

        }
        public PriceList() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime date { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
        public List<Product> Products { get; set; } = new List<Product>();
       


    }


}
