namespace FastFood.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;

    public class OrderItem
    {
        public OrderItem()
        {
            OrderId = Guid.NewGuid().ToString();
        }


        [MaxLength(EntitiesValidation.GuidMaxLength)]
        public string OrderId { get; set; }


        public virtual Order Order { get; set; } = null!;


        public string ItemId { get; set; }


        public virtual Item Item { get; set; } = null!;


        
        public int Quantity { get; set; }
    }
}