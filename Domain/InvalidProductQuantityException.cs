using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace tema1.Domain
{
    [Serializable]
    internal class InvalidProductQuantityException : Exception
    {
        public InvalidProductQuantityException()
        {
        }

        public InvalidProductQuantityException(string? message) : base(message)
        {
        }

        public InvalidProductQuantityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidProductQuantityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
