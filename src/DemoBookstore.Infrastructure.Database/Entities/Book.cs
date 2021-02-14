//using DemoBookStore.Domain.Entities;
//using System;
//using System.Collections.Generic;

//namespace DemoBookstore.Infrastructure.Database.Entities
//{
//    public record Book
//    {
//        public Guid Id { get; set; }
//        public string Title { get; set; }
//        public IEnumerable<Author> Authors { get; set; }
//        public Publisher Publisher { get; set; }
//        public ushort? Pages { get; set; }
//        public IEnumerable<Review> Reviews { get; set; }
//        public IEnumerable<Price> Pricing { get; set; }

//        public static Book FromBook(DemoBookStore.Domain.Entities.Book book) => new Book
//        {
//            Authors = book.Authors,
//            Pages = book.Pages,
//            Pricing = book.Pricing,
//            Publisher = book.Publisher,
//            Reviews = book.Reviews,
//            Title = book.Title
//        };
//    }
//}
