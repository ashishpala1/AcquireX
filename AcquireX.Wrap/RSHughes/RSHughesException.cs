using System.Runtime.Serialization;

namespace AcquireX.Wrap.RSHughes
{
    [Serializable]
    internal class RSHughesException : Exception
    {
        public RSHughesException()
        {
        }

        public RSHughesException(string? message) : base(message)
        {
        }

        public RSHughesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RSHughesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}