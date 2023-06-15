namespace TaskBoardApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    using static Common.EntityValidationConstants.Task;

    public class Task
    {
        public Task()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }


        [Required]
        [MaxLength(TaskMaxTitle)]
        public string Title { get; set; } = null!;


        [Required]
        [MaxLength(TaskMaxDescription)]
        public string Description { get; set; } = null!;


        public DateTime CreatedOn { get; set; }


        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }

        public virtual Board? Board { get; set; }


        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        public virtual IdentityUser Owner { get; set; } = null!;
    }
}
