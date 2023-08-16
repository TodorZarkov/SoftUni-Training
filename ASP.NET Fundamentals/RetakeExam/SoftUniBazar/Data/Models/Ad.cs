namespace SoftUniBazar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Ad;

    public class Ad
    {
        public Ad()
        {
            AdsBuyers = new HashSet<AdBuyer>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(NameMax)]
        public string Name { get; set; } = null!;


        [Required]
        [MaxLength(DescriptionMax)]
        public string Description { get; set; } = null!;



        [Precision(ValuePrecision, ValueScale)]
        public decimal Price { get; set; }


        [Required]
        //[ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        [Required]
        public IdentityUser Owner { get; set; } = null!;


        [Required]
        [MaxLength(ImageUrlMax)]
        public string ImageUrl { get; set; } = null!;


        [Required]
        public DateTime CreatedOn { get; set; }


        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;


        public ICollection<AdBuyer> AdsBuyers { get; set; }
    }
}
