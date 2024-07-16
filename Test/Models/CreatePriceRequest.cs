using Test.Domain.Entites;
namespace Test.Models
{
    public class CreatePriceRequest
    {
        public CreatePriceRequest(string name, List<Column> columns)
        {
            Name = name;
            Columns = columns;
        }
        public CreatePriceRequest() { }
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
    }
}
