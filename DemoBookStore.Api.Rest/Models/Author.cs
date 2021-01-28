using System;
using System.Collections.Generic;

namespace DemoBookStore.Api.Rest.Models
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