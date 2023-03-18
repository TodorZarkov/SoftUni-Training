namespace ProductShop.Data;

using Microsoft.EntityFrameworkCore;

using Common.DataConfiguration;
using Models;

public class ProductShopContext : DbContext
{
	public ProductShopContext()
	{
	}

	public ProductShopContext(DbContextOptions options) : base(options)
	{
	}


	public virtual DbSet<User> Users { get; set; } = null!;
	public virtual DbSet<Product> Products { get; set; } = null!;
	public virtual DbSet<CategoryProduct> CategoriesProducts { get; set; } = null!;
	public virtual DbSet<Category> Categories { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(Config.SqlConnectionString)
				.UseLazyLoadingProxies();
		}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<CategoryProduct>()
			.HasKey(e => new { e.CategoryId, e.ProductId });
    }
}