
namespace _03.Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    public class Smartphone : ExceptionMessages, ICallable, IBrowsable
    {
        private const int numberLength = 10;


        public string Browse(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(string.Format(CannotBeEmptyMessage, nameof(url)));
            }

            if (url.Any(c => c >= '0' && c <= '9'))
            {
                throw new ArgumentException(InvalidUrlMessage);
            }


            return $"Browsing: {url}!";
        }


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


            if(number.Length != numberLength)
            {
                throw new ArgumentOutOfRangeException(string.Format(WrongLenghtMessage,numberLength));
            }


            return $"Calling... {number}";
        }
    }
}
