namespace TaskBoardApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Board;
    public class Board
    {
        public Board()
        {
            Tasks = new HashSet<Task>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardMaxName)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
