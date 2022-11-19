namespace CommandPattern.Core.Exceptions
{
    using System;
    using System.Reflection.Metadata;

    public class NoSuchCommandException : Exception
    {
        private const string defaultMessage = "The provided command doesn't exist.";

        public NoSuchCommandException():base(defaultMessage)
        {
        }

        public NoSuchCommandException(string message):base(message)
        {
        }
    }
}
