namespace Forum.App.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static Forum.App.Common.EntityValidation.Post;

	public class Post
	{
		public Post()
		{
			Id = new Guid();
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
