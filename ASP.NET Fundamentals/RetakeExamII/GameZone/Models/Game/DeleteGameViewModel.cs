namespace GameZone.Models.Game
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteGameViewModel
    {
        [Required]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Publisher { get; set; }
    }
}
