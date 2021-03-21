using System;

namespace DemoBookStore.Domain.Entities
{
    public record Author : BaseEntity
    {
        public Author(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            init => _firstName = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException("firstName");
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            init => _lastName = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException("lastName");
        }
    }
}