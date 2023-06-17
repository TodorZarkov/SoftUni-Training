namespace Homies.Common
{
    using Homies.Common.Contracts;
    using System.Globalization;
    using static Homies.Common.EntityValidationConstants.Date;

    public class Validator : IValidator
    {
        public bool IsSecondAfterFirst(string firstDate, string secondDate)
        {
            DateTime fDate;
            bool isFirstDate = DateTime.TryParseExact(firstDate, MainDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate);

            DateTime sDate;
            bool isSecondDate = DateTime.TryParseExact(secondDate, MainDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out sDate);

            

            if (!isFirstDate || !isSecondDate)
            {
                return false;
            }

            bool isSecondAfterFirst = DateTime.Compare(sDate, fDate) > 0 ;

            return isSecondAfterFirst;
        }
    }
}
