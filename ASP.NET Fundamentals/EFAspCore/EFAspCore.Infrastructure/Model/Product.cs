namespace EFAspCore.Infrastructure.Model
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    [Comment("Product table")]
    public class Product
    {
        public Product()
        {
            ProductNotes = new List<ProductNote>();
        }

        [Comment("Product Id")]
        [Key]
        public int Id { get; set; }

        [Comment("Product name")]
        [MaxLength(150)]
        [Required]
        public string ProductName { get; set; } = null!;

        [Comment("Product quantity")]
        [Required]
        public int Quantity { get; set; }

        [Comment("Product price")]
        public decimal? Price { get; set; }

        public ICollection<ProductNote> ProductNotes { get; set; }
    }
}
