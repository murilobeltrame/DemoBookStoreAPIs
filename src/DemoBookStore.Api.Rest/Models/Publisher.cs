using System;
using System.Collections.Generic;

namespace DemoBookStore.Api.Rest.Models
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}