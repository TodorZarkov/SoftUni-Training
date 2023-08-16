namespace SoftUniBazar.Common
{
    public static class EntityValidationConstants
    {
        public static class Ad
        {
            public const int NameMin = 5;
            public const int NameMax = 25;
            
            public const int DescriptionMin = 15;
            public const int DescriptionMax = 250;


            public const int ImageUrlMin = 1;
            public const int ImageUrlMax = 2048;

            public const int ValuePrecision = 18;
            public const int ValueScale = 6;

            public const double ValueMinValue = 0.01;
            public const double ValueMaxValue = 9999999999999999.99;

        }

        public static class Category
        {
            public const int NameMin = 3;
            public const int NameMax = 15;
        }

        public static class AdBuyer
        {
           
        }
    }
}
