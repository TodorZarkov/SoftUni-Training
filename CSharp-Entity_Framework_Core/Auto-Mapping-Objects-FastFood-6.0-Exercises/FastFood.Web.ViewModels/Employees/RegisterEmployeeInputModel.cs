namespace FastFood.Core.ViewModels.Employees
{
    using FastFood.Common.EntityConfiguration;
    using System.ComponentModel.DataAnnotations;

    public class RegisterEmployeeInputModel
    {
        [MinLength(ViewModelsValidation.EmployeeNameMinLength)]
        [MaxLength(ViewModelsValidation.EmployeeNameMaxLength)]
        public string Name { get; set; } = null!;


        [Range(ViewModelsValidation.EmployeeMinAge, ViewModelsValidation.EmployeeMaxAge)]
        public int Age { get; set; }

        public int PositionId { get; set; }

        //public string PositionName { get; set; } = null!;


        [MinLength(ViewModelsValidation.EmployeeAddressMinLength)]
        [MaxLength(ViewModelsValidation.EmployeeAddressMaxLength)]
        public string Address { get; set; } = null!;
    }
}
