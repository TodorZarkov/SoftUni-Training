namespace FastFood.Core.ViewModels.Orders
{
    using FastFood.Common.EntityConfiguration;
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderInputModel
    {
        [MinLength(ViewModelsValidation.CustomerMinLength)]
        [MaxLength(ViewModelsValidation.CustomerMaxLength)]
        public string Customer { get; set; } = null!;

        public string ItemId { get; set; } = null!;

        public string EmployeeId { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
