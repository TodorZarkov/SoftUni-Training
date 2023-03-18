namespace ProductShop.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public User()
    {
        ProductsSold = new HashSet<Product>();
        ProductsBought = new HashSet<Product>();
    }
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }

    [InverseProperty(nameof(Product.Seller))]
    public virtual ICollection<Product> ProductsSold { get; set; }


    [InverseProperty(nameof(Product.Buyer))]
    public virtual ICollection<Product> ProductsBought { get; set; }
}