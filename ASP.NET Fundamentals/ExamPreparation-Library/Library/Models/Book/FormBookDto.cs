namespace Library.Models.Book
{
    using Library.Data;
    using static ValidationConstants.BookConstants;

    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Library.Models.Category;

    public class FormBookDto
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: TitleMax, MinimumLength = TitleMin)]
        public string Title { get; set; } = null!;


        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: AuthorMax, MinimumLength = AuthorMin)]
        public string Author { get; set; } = null!;


        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: DescriptionMax, MinimumLength = DescriptionMin)]
        public string Description { get; set; } = null!;


        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;


        [Required]
        [Range(RatingMin, RatingMax)]
        public decimal Rating { get; set; }


        [Required]
        //dynamic validation with db!
        public int CategoryId { get; set; }

        public SelectCategoryDto[]? Categories { get; set; }

    }
}
