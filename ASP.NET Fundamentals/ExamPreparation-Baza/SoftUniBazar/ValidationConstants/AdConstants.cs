namespace SoftUniBazar.ValidationConstants
{

    public static class AdConstants
    {
        public const int NameMin = 5;
        public const int NameMax = 25;

        public const int DescriptionMin = 15;
        public const int DescriptionMax = 250;

    }
}
    //• Has Id – a unique integer, Primary Key
    //• Has Name – a string with min length 5 and max length 25 (required)
    //• Has Description – a string with min length 15 and max length 250 (required)
    //• Has Price – a decimal (required)
    //• Has OwnerId – a string (required)
    //• Has Owner – an IdentityUser (required)
    //• Has ImageUrl – a string (required)
    //• Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
    //• Has CategoryId – an integer, foreign key (required)
    //• Has Category – a Category (required)