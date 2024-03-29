﻿namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;
    using FastFood.Common.EntityConfiguration;

    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            Id = Guid.NewGuid().ToString();
        }

        [MaxLength(EntitiesValidation.GuidMaxLength)]
        public string Id { get; set; }


        public string Customer { get; set; } = null!;


        public DateTime DateTime { get; set; }


        public OrderType Type { get; set; }


        [NotMapped]
        public decimal TotalPrice => 
            OrderItems != null ? OrderItems.Sum(i => i.Item.Price * i.Quantity) : 0m;


        public string EmployeeId { get; set; } = null!;


        public virtual Employee Employee { get; set; } = null!;


        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}