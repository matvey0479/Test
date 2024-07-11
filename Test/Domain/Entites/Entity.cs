namespace Test.Domain.Entites
{
    public abstract class Entity<TPimaryKey>
    {
        public TPimaryKey id { get; set; }
    }
    public abstract class Entity : Entity<int>
    { }
}
