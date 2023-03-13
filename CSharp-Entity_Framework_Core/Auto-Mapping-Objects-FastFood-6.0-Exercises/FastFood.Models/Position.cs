namespace FastFood.Models
{
    using FastFood.Common.EntityConfiguration;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>(); 
        }


        public int Id { get; set; }


        [MaxLength(EntitiesValidation.PositionNameMaxLength)]
        public string Name { get; set; } = null!;


        public virtual ICollection<Employee> Employees { get; set; }
    }
}