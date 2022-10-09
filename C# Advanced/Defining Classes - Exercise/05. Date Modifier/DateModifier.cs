using System;

namespace DateModifier
{
    public class DateModifier
    {
        public static int getDifference(string begin, string end)
        {
            DateTime startDate = DateTime.ParseExact(begin, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(end, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            int difference = endDate.Subtract(startDate).Days;

            return Math.Abs(difference);
        }
    }
}
