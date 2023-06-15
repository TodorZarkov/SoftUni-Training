namespace TaskBoardApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using TaskBoardApp.Data;
    using TaskBoardApp.Services.Interfaces;
    using TaskBoardApp.Web.ViewModels.Board;
    using TaskBoardApp.Web.ViewModels.Task;

    public class BoardService : IBoardService
    {
        private readonly TaskBoardDbContext dbContext;

        public BoardService(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		

		public async Task<IEnumerable<BoardAllViewModel>> AllAsync()
        {
            IEnumerable<BoardAllViewModel> allBoards = await dbContext
                .Boards
                .Select(b => new BoardAllViewModel
                {
                    Name = b.Name,
                    Tasks = b.Tasks
                        .Select(t => new TaskViewModel
                        {
                            Description = t.Description,
                            Id = t.Id.ToString(),
                            Owner = t.Owner.UserName,
                            Title = t.Title
                        })
                        .ToArray()
                })
                .ToArrayAsync();

            return allBoards;
        }

		public async Task<IEnumerable<BoardSelectViewModel>> AllForSelectAsync()
		{
            IEnumerable<BoardSelectViewModel> boards = await dbContext
                .Boards
                .Select(b => new BoardSelectViewModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToArrayAsync();

            return boards;
		}

		public async Task<bool> ExistsByIdAsync(int id)
		{
            bool result = await dbContext
                .Boards
                .AnyAsync(b => b.Id == id);

            return result;
		}
	}
}
