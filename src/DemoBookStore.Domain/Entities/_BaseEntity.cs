using System;

namespace DemoBookStore.Domain.Entities
{
    public abstract record BaseEntity
    {
        public Guid Id { get; set; }
    }
}
