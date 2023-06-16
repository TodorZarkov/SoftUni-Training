 namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Library.Common.EntityValidationConstants.Book;

    public class Book
    {
        public Book()
        {
            UsersBooks = new HashSet<IdentityUserBook>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMax)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AuthorMax)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMax)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        public virtual ICollection<IdentityUserBook> UsersBooks { get; set; }
    }
}
