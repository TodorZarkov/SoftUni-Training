
namespace WildFarm.Exceptions
{
    using System;
    public class InvalidAnimalException : Exception
    {
        private const string defaultMessage = "Animal Doesn't exist";
        public InvalidAnimalException():base(defaultMessage)
        {

        }

        public InvalidAnimalException(string message):base(message)
        {

        }
    }
}
