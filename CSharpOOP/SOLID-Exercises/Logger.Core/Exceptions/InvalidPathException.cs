namespace Logger.Core.Exceptions
{
    internal class InvalidPathException:Exception
    {
        private const string defaultMessage = "Can not find file.";

        public InvalidPathException() :base(defaultMessage)
        {
        }

        public InvalidPathException(string message) : base(message)
        {
        }
    }
}
