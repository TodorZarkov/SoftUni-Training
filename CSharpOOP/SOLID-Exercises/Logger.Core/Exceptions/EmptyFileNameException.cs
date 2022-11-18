namespace Logger.Core.Exceptions
{
    using System;

    internal class EmptyFileNameException : Exception
    {
        private const string defaultMessage = "Invalid file name.";

        public EmptyFileNameException() : base(defaultMessage)
        {   
        }

        public EmptyFileNameException(string message) : base(message)
        {
        }
    }
}
