﻿namespace ProductShop.Models;


public class Product
{
    public Product()
    {
        CategoryProducts = new HashSet<CategoryProduct>();
    }


    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int SellerId { get; set; }
    public virtual User Seller { get; set; }

    public int? BuyerId { get; set; }
    public virtual User? Buyer { get; set; }

    public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
}
