namespace Test.Domain.Entites
{
    public class Description
    {
        public Description(string? text, int? number) 
        {
            descriptionText = text;
            descriptionNumber = number;
        }
        public Description() { }
        public int Id { get; set; }
        public string? descriptionText { get; set; }
        public int? descriptionNumber { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
