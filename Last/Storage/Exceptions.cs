namespace Last.Storage
{
    public class Exceptions
    {
        [System.Serializable]
        public class IncorrectAvtoException : System.Exception
        {
            public IncorrectAvtoException() { }
            public IncorrectAvtoException(string message) : base(message) { }
            public IncorrectAvtoException(string message, System.Exception inner) : base(message, inner) { }
            protected IncorrectAvtoException(
                System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
