namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Library.Common.EntityValidationConstants.Category;
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMax)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
    }
}
