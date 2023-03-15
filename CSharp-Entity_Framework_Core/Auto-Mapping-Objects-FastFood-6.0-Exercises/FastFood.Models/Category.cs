namespace FastFood.Models
{
    using FastFood.Common.EntityConfiguration;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }

        [MaxLength(EntitiesValidation.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
