

namespace WildFarm.Exceptions
{
    using System;
    public class InvalidFoodException : Exception
    {
        private const string defaultMessage = "Invalid Food Type";

        public InvalidFoodException() : base(defaultMessage)
        { 
        }

        public InvalidFoodException(string message) : base(message)
        {

        }
    }

}
