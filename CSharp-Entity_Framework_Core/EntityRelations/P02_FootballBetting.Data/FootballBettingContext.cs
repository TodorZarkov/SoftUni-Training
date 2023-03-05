namespace P02_FootballBetting.Data;

using Microsoft.EntityFrameworkCore;
using Common;

public class FootballBettingContext : DbContext
{
	public FootballBettingContext() : base()
	{
	}

	public FootballBettingContext(DbContextOptions options) : base(options)
	{
	}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(DbConfig.SqlConnectionString);
		}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
