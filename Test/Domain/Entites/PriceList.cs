namespace Test.Domain.Entites
{
    public class PriceList:Entity
    {
        public PriceList(string name, List<Column> columns)
        {
            date = DateTime.Now;
            Name = name;
            Columns = columns;
        }
        public PriceList() { }
        public string Name { get; set; }
        public DateTime date { get; set; }
        public List<Column> Columns { get; set; }
       


    }


}
