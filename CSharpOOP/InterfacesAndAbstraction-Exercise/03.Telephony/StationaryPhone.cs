
namespace _03.Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class StationaryPhone : ExceptionMessages, ICallable
    {
        private const int numberLength = 7;


        public string Call(string number)
        {

            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(string.Format(CannotBeEmptyMessage, nameof(number)));
            }


            if (!number.All(c => c >= '0' && c <= '9'))
            {
                throw new ArgumentException(InvalidNumberMessage);
            }


            if (number.Length != numberLength)
            {
                throw new ArgumentOutOfRangeException(string.Format(WrongLenghtMessage, numberLength));
            }


            return $"Dialing... {number}";
        }
    }
}
