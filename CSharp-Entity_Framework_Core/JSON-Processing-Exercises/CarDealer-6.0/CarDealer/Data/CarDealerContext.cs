namespace CarDealer.Data;

using Microsoft.EntityFrameworkCore;
using CarDealer.Models;

public class CarDealerContext : DbContext
{
	public CarDealerContext()
	{
	}

	public CarDealerContext(DbContextOptions options) : base(options)
	{
	}


	public DbSet<Supplier> Suppliers { get; set; }
	public DbSet<Part> Parts { get; set; }
	public DbSet<PartCar> PartsCars { get; set; }
	public DbSet<Car> Cars { get; set; }
	public DbSet<Sale> Sales { get; set; }
	public DbSet<Customer> Customers { get; set; }


	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(Configuration.ConnectionString);
		}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<PartCar>()
			.HasKey(cp => new { cp.PartId, cp.CarId });

		modelBuilder.Entity<Sale>()
			.HasKey(s => new { s.CarId, s.CustomerId });
    }
}
