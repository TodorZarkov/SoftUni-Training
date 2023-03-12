namespace FastFood.Data;

using Microsoft.EntityFrameworkCore;

using Common.DataConfiguration;
using Models;

public class FastFoodContext : DbContext
{
    public FastFoodContext()
    {
    }

    public FastFoodContext(DbContextOptions<FastFoodContext> options)
    : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Position> Positions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString)
                .UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ItemId });

        builder.Entity<Position>()
            .HasAlternateKey(p => p.Name);

        builder.Entity<Item>()
            .HasAlternateKey(i => i.Name);
    }
}
