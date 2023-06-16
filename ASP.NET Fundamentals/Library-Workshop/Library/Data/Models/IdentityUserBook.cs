namespace Library.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class IdentityUserBook
    {
        [Required]
        public string CollectorId { get; set; } = null!;

        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;


        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
