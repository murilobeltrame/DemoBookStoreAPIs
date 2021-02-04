namespace DemoBookStore.Domain.Entities
{
    public record Author
    {
        public Author(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);

        public string FirstName { get; }
        public string LastName { get; }
    }
}