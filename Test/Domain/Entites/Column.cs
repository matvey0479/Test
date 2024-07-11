namespace Test.Domain.Entites
{
    public class Column:Entity
    {
        public Column(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }
        public Column ()
        { 
        }
        public string Name { get; set; }
        public string DataType { get; set; }

    }
}
