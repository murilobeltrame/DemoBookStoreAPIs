using System;
using System.Collections.Generic;

namespace DemoBookStore.Application.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public ICollection<Author> Authors { get; set; }
        public Publisher Publisher { get; set; }
    }
}
