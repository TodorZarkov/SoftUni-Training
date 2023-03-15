namespace FastFood.Core.ViewModels.Categories
{
    using FastFood.Common.EntityConfiguration;
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryInputModel
    {
        [MinLength(ViewModelsValidation.CategoryNameMinLength)]
        [MaxLength(ViewModelsValidation.CategoryNameMaxLength)]
        public string CategoryName { get; set; } = null!;
    }
}
