namespace FastFood.Models
{
    using FastFood.Common.EntityConfiguration;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        public Item()
        {
            OrderItems = new HashSet<OrderItem>();
            Id = Guid.NewGuid().ToString();
        }

        [MaxLength(EntitiesValidation.GuidMaxLength)]
        public string Id { get; set; }


        [MaxLength(EntitiesValidation.ItemNameMaxLength)]
        public string? Name { get; set; }


        public int CategoryId { get; set; }


        public virtual Category Category { get; set; } = null!;

        
        public decimal Price { get; set; }


        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}