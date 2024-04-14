using System.Security.Policy;

namespace SoftUniBazar.ValidationConstants
{

    public static class CategoryConstants
    {
        public const int NameMin = 3;
        public const int NameMax = 15;

    }
}
    //• Has Id – a unique integer, Primary Key
    //• Has Name – a string with min length 3 and max length 15 (required)
    //• Has Ads – a collection of type Ad