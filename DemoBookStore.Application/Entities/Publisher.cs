using System;
using System.Collections.Generic;

namespace DemoBookStore.Application.Entities
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}