using System;
using System.Runtime.Serialization;

namespace EventScheduler
{
    [Serializable]
    internal class RuleException : Exception
    {
        public RuleException()
        {
        }

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RuleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}