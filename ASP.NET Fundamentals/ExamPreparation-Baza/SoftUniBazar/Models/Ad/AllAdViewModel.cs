﻿namespace SoftUniBazar.Models.Ad
{
	public class AllAdViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;


		public string Description { get; set; } = null!;

		public decimal Price { get; set; }


		public string Owner { get; set; } = null!;


		public string ImageUrl { get; set; } = null!;


		public string CreatedOn { get; set; } = null!;


		public string Category { get; set; } = null!;

	}
}
