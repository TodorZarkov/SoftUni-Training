﻿namespace Forum.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static Forum.Common.Validations.EntityValidation.Post;

	public class Post
	{
		public Post()
		{
			Id = Guid.NewGuid();
		}

		[Key]
		public Guid Id { get; set; }


		[Required]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(ContentMaxLength)]
		public string Content { get; set; } = null!;
	}
}
