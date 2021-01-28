using System;
using System.Collections.Generic;

namespace DemoBookStore.Application.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public ICollection<Book> Books { get; set; }
    }
}