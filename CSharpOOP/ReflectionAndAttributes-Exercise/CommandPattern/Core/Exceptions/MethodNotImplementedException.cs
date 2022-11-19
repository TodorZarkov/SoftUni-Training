namespace CommandPattern.Core.Exceptions
{
    using System;

    internal class MethodNotImplementedException:Exception
    {
        private const string defaultMessage = "The invoked command doesn't implement the method Execute.";

        public MethodNotImplementedException() : base(defaultMessage)
        {
        }

        public MethodNotImplementedException(string message) : base(message)
        {
        }
    }
}
