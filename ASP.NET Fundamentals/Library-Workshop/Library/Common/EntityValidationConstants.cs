namespace Library.Common
{
    public static class EntityValidationConstants
    {
        public static class Book
        {
            public const int TitleMin = 10;
            public const int TitleMax = 50;

            public const int AuthorMin = 5;
            public const int AuthorMax = 50;

            public const int DescriptionMin = 5;
            public const int DescriptionMax = 5000;

            public const double RatingMin = 0.00;
            public const double RatingMax = 10.00;


        }

        public static class Category
        {
            public const int NameMin = 5;
            public const int NameMax = 50;
        }
    }
}
