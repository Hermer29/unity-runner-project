using System;

namespace Exceptions
{

    [Serializable]
    public class BorderCollisionException : Exception
    {
        public BorderCollisionException() { }

        public BorderCollisionException(string message) : base(message) { }

        public BorderCollisionException(string message, Exception inner) : base(message, inner) { }

        protected BorderCollisionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}