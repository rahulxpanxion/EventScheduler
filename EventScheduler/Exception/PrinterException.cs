using System;
using System.Runtime.Serialization;

namespace EventScheduler
{
    [Serializable]
    internal class PrinterException : Exception
    {
        public PrinterException()
        {
        }

        public PrinterException(string message) : base(message)
        {
        }

        public PrinterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PrinterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}