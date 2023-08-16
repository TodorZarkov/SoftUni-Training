namespace SoftUniBazar.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Category;

    public class Category
    {
        public Category()
        {
            Ads = new HashSet<Ad>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(NameMax)]
        public string Name { get; set; } = null!;


        public ICollection<Ad> Ads { get; set; }

    }
}
