namespace Library.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static ValidationConstants.BookConstants;

    public class Book
    {
        public Book()
        {
            UsersBooks = new HashSet<IdentityUserBook>();
        }


        [Key]
        public int Id { get; set; }


        [Required(AllowEmptyStrings = false)]
        [MaxLength(TitleMax)]
        public string Title { get; set; } = null!;


        [Required(AllowEmptyStrings = false)]
        [MaxLength(AuthorMax)]
        public string Author { get; set; } = null!;


        [Required(AllowEmptyStrings = false)]
        [MaxLength(DescriptionMax)]
        public string Description { get; set; } = null!;


        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;


        [Required]
        public decimal Rating { get; set; }


        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;


        public ICollection<IdentityUserBook> UsersBooks { get; set; } = null!;

        //• Has Id – a unique integer, Primary Key
        //• Has Title – a string with min length 10 and max length 50 (required)
        //• Has Author – a string with min length 5 and max length 50 (required)
        //• Has Description – a string with min length 5 and max length 5000 (required)
        //• Has ImageUrl – a string (required)
        //• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
        //• Has CategoryId – an integer, foreign key (required)
        //• Has Category – a Category (required)
        //• Has UsersBooks – a collection of type IdentityUserBook
    }
}
