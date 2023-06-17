namespace Homies.Common
{
    using System.Globalization;

    public static class Validators
    {
        public static bool IsSecondAfterFirst(string firstDate, string secondDate)
        {
            DateTime fDate;
            bool isFirstDate = DateTime.TryParseExact(firstDate, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate);

            DateTime sDate;
            bool isSecondDate = DateTime.TryParseExact(secondDate, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out sDate);

            

            if (!isFirstDate || !isSecondDate)
            {
                return false;
            }

            bool isSecondAfterFirst = DateTime.Compare(sDate, fDate) > 0 ;

            return isSecondAfterFirst;
        }
    }
}
