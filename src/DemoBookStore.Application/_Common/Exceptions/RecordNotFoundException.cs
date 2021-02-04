using System;

namespace DemoBookStore.Application.Common.Exceptions
{
    public class RecordNotFoundException: Exception
    {
        public RecordNotFoundException(string message = null) : base(message) { }
    }
}
