namespace TaskBoardApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using Task = Models.Task;
    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(GenerateTasks());
        }

        private ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task()
                {
                    Title = "Improve css styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = "79a30247-dad3-4084-b998-d5b58bf7438f",
                    BoardId = 1
                },

                new Task()
                {
                    Title = "Android Client app",
                    Description = "Create android client app for restfull task board service",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = "9f38a765-116e-4f82-b21f-1b91c890281c",
                    BoardId = 1
                },

                new Task()
                {
                    Title = "Desktop client app",
                    Description = "Create desktop client app for restfull task board service",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = "79a30247-dad3-4084-b998-d5b58bf7438f",
                    BoardId = 2
                },

                 new Task()
                {
                    Title = "Create taksk",
                    Description = "Implement create taks page for addingn tasks",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = "79a30247-dad3-4084-b998-d5b58bf7438f",
                    BoardId = 3
                }
            };

            return tasks;
        }
    }
}
