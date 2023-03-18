namespace ProductShop.Models;

public class Category
{
    public Category()
    {
        CategoryProducts = new HashSet<CategoryProduct>();
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
}
