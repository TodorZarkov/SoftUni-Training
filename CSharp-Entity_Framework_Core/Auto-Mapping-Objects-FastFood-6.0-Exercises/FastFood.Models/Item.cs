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

        [MaxLength(ValidationConstants.GuidMaxLength)]
        public string Id { get; set; }


        [StringLength(ValidationConstants.ItemNameMaxLength, MinimumLength = 3)]
        public string? Name { get; set; }


        public int CategoryId { get; set; }


        public virtual Category Category { get; set; } = null!;


        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }


        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}