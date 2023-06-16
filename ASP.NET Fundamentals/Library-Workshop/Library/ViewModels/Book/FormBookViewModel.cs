

namespace Library.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;

    using Library.ViewModels.Category;
    using static Library.Common.EntityValidationConstants.Book;

    public class FormBookViewModel
    {
        [Required]
        [StringLength(TitleMax, MinimumLength = TitleMin, ErrorMessage = "The Title must be between {2} and {1} symbols")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMax, MinimumLength = AuthorMin, ErrorMessage = "The Author must be between {2} and {1} symbols")]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMax, MinimumLength = DescriptionMin, ErrorMessage = "The Description must be between {2} and {1} symbols")]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        [Range(RatingMin, RatingMax)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual ICollection<SelectCategoryViewModel> Categories { get; set; } = null!;
    }
}
