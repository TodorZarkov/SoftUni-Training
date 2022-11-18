namespace Logger.Core.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Validation
    {
        public static bool IsDateTimeValidFormat(string dateTime)
        {
            return DateTime.TryParse(dateTime, out DateTime result);
        }

        public static bool FilePathExists(string path)
        {
            return true;
        }
    }
}
