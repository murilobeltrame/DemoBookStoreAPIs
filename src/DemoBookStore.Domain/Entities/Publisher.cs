namespace DemoBookStore.Domain.Entities
{
    public record Publisher
    {
        public Publisher(string name) => Name = name;

        public string Name { get; }
    }
}