namespace CompaniesOperations.API.Infrastructure.Exceptions
{
    [System.Serializable]
    public class EmptyStatException : System.Exception
    {
        public EmptyStatException() { }
        public EmptyStatException(string message) : base(message) { }
        public EmptyStatException(string message, System.Exception inner) : base(message, inner) { }
        protected EmptyStatException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}