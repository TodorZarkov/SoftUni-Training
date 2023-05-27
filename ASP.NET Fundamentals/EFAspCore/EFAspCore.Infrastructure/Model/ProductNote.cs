namespace EFAspCore.Infrastructure.Model
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("Product note table")]
    public class ProductNote
    {
        [Comment("Product note id")]
        [Key]
        public int Id { get; set; }

        [Comment("Product note text")]
        [MaxLength(500)]
        [Required]
        public string Note { get; set; } = null!;

        [Comment("Product note date")]
        [Required]
        public DateTime NoteDate { get; set; }

        [Comment("Product note Product id")]
        [Required]
        public int ProductId { get; set; }

        [Comment("Product note Product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
