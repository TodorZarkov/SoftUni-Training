namespace Logger.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class InvalidDateTimeFormatException : Exception
    {
        private const string defaultMessage = "Invalid  dateTime format providet.";

        public InvalidDateTimeFormatException() : base(defaultMessage)
        {
        }

        public InvalidDateTimeFormatException(string message) : base(message)
        {
        }
    }
}
