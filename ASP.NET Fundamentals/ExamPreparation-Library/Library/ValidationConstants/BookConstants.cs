namespace Library.ValidationConstants
{
    using Humanizer;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Newtonsoft.Json.Linq;
    using System.Runtime.Intrinsics.X86;
    using System.Security.Policy;

    public static class BookConstants
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
}
