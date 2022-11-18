namespace Logger.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidDateTimeException:Exception
    {
        private const string defaultMessage = "DateTime must be not null ot whitespace.";
        public InvalidDateTimeException():base(defaultMessage)
        {
        }

        public InvalidDateTimeException(string message):base(message)
        {
        }
    }
}
