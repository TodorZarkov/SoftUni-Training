namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>(); 
        }


        public int Id { get; set; }


        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; } = null!;


        public virtual ICollection<Employee> Employees { get; set; }
    }
}