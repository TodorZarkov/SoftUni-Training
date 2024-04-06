namespace Library.Data
{
    using System.ComponentModel.DataAnnotations;
    using static ValidationConstants.CategoryConstants;

    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }


        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(NameMax)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = null!;



        //• Has Id – a unique integer, Primary Key
        //• Has Name – a string with min length 5 and max length 50 (required)
        //• Has Books – a collection of type Books
    }
}
