using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Date_Modifier
{
    public class DateModifier
    {
        private int difference;
        public int getDifference(string begin, string end)
        {
            DateTime startDate = DateTime.ParseExact(begin, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(end, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            this.difference = endDate.Subtract(startDate).Days;
            return Math.Abs(difference);
        }
    }
}
