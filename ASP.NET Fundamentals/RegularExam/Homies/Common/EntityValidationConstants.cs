namespace Homies.Common
{
    public static class EntityValidationConstants
    {
        public static class Event
        {
            public const int EventNameMin = 5;
            public const int EventNameMax = 20;

            public const int EventDescriptionMin = 15;
            public const int EventDescriptionMax = 150;
        }

        public static class Type
        {
            public const int TypeNameMin = 5;
            public const int TypeNameMax = 15;
        }

        public static class Date
        {
            public const string MainDateFormat = "dd-MMM-yyyy H:mm";
        }
    }
}
