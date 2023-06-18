using System.Runtime.Serialization;

namespace AcquireX.Wrap.AcquireXClientConfiguration
{
    [Serializable]
    internal class OauthTokenException : Exception
    {
        public OauthTokenException()
        {
        }

        public OauthTokenException(string? message) : base(message)
        {
        }

        public OauthTokenException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OauthTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}