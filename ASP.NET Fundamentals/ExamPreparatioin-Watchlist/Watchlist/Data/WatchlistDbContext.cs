namespace Watchlist.Data
{
	using static ValidationConstants.UserConstants;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class WatchlistDbContext : IdentityDbContext<Watchlist.Data.User>
	{
		public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options)
			: base(options)
		{
		}

        public DbSet<Movie> Movies { get; set; } = null!;

		public DbSet<Genre> Genres { get; set; } = null!;

		public DbSet<UserMovie> UsersMovies { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder); //This must be before the custom configuration, so it can override the default one!!!

			builder
				.Entity<UserMovie>()
				.HasKey((um => new { um.UserId, um.MovieId }));

			builder
				.Entity<User>()
				.Property(p => p.UserName)
				.HasMaxLength(NameMaxLength);

			builder
				.Entity<User>()
				.Property(u => u.Email)
				.HasMaxLength(EmailMaxLength);

			builder
				.Entity<Genre>()
				.HasData(new Genre()
				{
					Id = 1,
					Name = "Action"
				},
				new Genre()
				{
					Id = 2,
					Name = "Comedy"
				},
				new Genre()
				{
					Id = 3,
					Name = "Drama"
				},
				new Genre()
				{
					Id = 4,
					Name = "Horror"
				},
				new Genre()
				{
					Id = 5,
					Name = "Romantic"
				});

			
		}
	}
}