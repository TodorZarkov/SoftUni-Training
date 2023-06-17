namespace Homies.Common
{
    using Homies.Common.Contracts;
    using System.Globalization;

    public class Validator : IValidator
    {
        public bool IsSecondAfterFirst(string firstDate, string secondDate)
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
