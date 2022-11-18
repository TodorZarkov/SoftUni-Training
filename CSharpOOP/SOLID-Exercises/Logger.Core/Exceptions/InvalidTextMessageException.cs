namespace Logger.Core.Exceptions
{
    using System;

    public class InvalidTextMessageException:Exception
    {
        private const string defaultMessage = "Message text must not be null or white space.";

        public InvalidTextMessageException() : base(default)
        {

        }

        public InvalidTextMessageException(string message) : base(message)
        {

        }
    }
}
