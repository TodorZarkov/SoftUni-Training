namespace SoftUniBazar.Models.Ad
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Ad;
    using SoftUniBazar.Models.Category;

    public class AdFormModel
    {
       

        [Required]
        [StringLength(NameMax, MinimumLength = NameMin)]
        public string Name { get; set; } = null!;


        [Required]
        [StringLength(DescriptionMax, MinimumLength = DescriptionMin)]
        public string Description { get; set; } = null!;



        [Range(ValueMinValue, ValueMaxValue)]
        public decimal Price { get; set; }




        [Required]
        [StringLength(ImageUrlMax, MinimumLength = ImageUrlMin)]
        public string ImageUrl { get; set; } = null!;


        //[Required]
        //public DateTime CreatedOn { get; set; }


        
        [Required]//todo: validate valid id async
        [Range(0, int.MaxValue)]
        public int CategoryId { get; set; }

        public ICollection<CategorySelectViewModel>? AvailableCategories { get; set; }


    }
}
