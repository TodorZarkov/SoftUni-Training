namespace P02_FootballBetting.Data;

using Microsoft.EntityFrameworkCore;

using Common;
using Models;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;

public class FootballBettingContext : DbContext
{
	public FootballBettingContext() //: base()
	{
	}

	public FootballBettingContext(DbContextOptions options) : base(options)
	{
	}


	public virtual DbSet<Team> Teams { get; set; } = null!;
	public virtual DbSet<Color> Colors { get; set; } = null!;
	public virtual DbSet<Country> Countries { get; set; } = null!;
	public virtual DbSet<Town> Towns { get; set; } = null!;
	public virtual DbSet<Position> Positions { get; set; } = null!;
	public virtual DbSet<Player> Players { get; set; } = null!;
	public virtual DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;
	public virtual DbSet<Game> Games { get; set; } = null!;
	public virtual DbSet<Bet> Bets { get; set; } = null!;
	public virtual DbSet<User> Users { get; set; } = null!;



	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(DbConfig.SqlConnectionString);
		}

		base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Color>()
			.HasMany(c => c.PrimaryKitTeams)
			.WithOne(t => t.PrimaryKitColor)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Color>()
			.HasMany(c => c.SecondaryKitTeams)
			.WithOne(t => t.SecondaryKitColor)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<PlayerStatistic>()
			.HasKey(ps => new { ps.PlayerId, ps.GameId });

		modelBuilder.Entity<Team>()
			.HasMany(t => t.HomeGames)
			.WithOne(g => g.HomeTeam)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Team>()
			.HasMany(t => t.AwayGames)
			.WithOne(g => g.AwayTeam)
			.OnDelete(DeleteBehavior.Restrict);



		//base.OnModelCreating(modelBuilder);
	}
}
