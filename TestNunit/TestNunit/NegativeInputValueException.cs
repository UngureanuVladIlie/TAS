using System;
using System.Runtime.Serialization;

namespace TestNunit
{
    [Serializable]
    internal class NegativeInputValueException : Exception
    {
        public NegativeInputValueException()
        {
        }

        public NegativeInputValueException(string message) : base(message)
        {
        }

        public NegativeInputValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativeInputValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}