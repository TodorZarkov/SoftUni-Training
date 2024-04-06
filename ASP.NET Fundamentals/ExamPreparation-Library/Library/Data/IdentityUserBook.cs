namespace Library.Data
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class IdentityUserBook
    {
        [Required(AllowEmptyStrings = false)]
        [ForeignKey(nameof(Collector))]
        public string CollectorId { get; set; } = null!;

        [Required]
        public IdentityUser Collector { get; set; } = null!;



        [Required(AllowEmptyStrings = false)]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        [Required]
        public Book Book { get; set; } = null!;


        //• CollectorId – a string, Primary Key, foreign key(required)
        //• Collector – IdentityUser
        //• BookId – an integer, Primary Key, foreign key(required)
        //• Book – Book
    }
}
