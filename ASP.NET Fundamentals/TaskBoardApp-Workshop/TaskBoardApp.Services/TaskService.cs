namespace TaskBoardApp.Services
{
	using Microsoft.EntityFrameworkCore;
	using TaskBoardApp.Data;
	using TaskBoardApp.Services.Interfaces;
	using TaskBoardApp.Web.ViewModels.Task;

	public class TaskService : ITaskService
	{
		TaskBoardDbContext dbContext;
		public TaskService(TaskBoardDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async System.Threading.Tasks.Task AddAsync(string ownerId, TaskFormModel viewModel)
		{
			TaskBoardApp.Data.Models.Task task = new Data.Models.Task()
			{
				Title = viewModel.Title,
				Description = viewModel.Description,
				BoardId = viewModel.BoardId,
				CreatedOn = DateTime.UtcNow,
				OwnerId = ownerId
			};

			await dbContext.Tasks.AddAsync(task);
			await dbContext.SaveChangesAsync();
		}

		public async Task<int> CountAsync()
		{
			int tasksCount = await dbContext.Tasks.CountAsync();

			return tasksCount;
		}

		public async Task<int> CountAsync(string userId)
		{
			int tasksCount = await dbContext.Tasks
				.CountAsync(t => t.OwnerId == userId);

			return tasksCount;
		}

		public async System.Threading.Tasks.Task DeleteAsync(string taskId)
		{
			Data.Models.Task taskToDelete = await dbContext.Tasks
				.FirstAsync(t => t.Id == new Guid(taskId));

			dbContext.Tasks.Remove(taskToDelete);

			await dbContext.SaveChangesAsync();
		}

		public async Task<TaskViewModel> GetForDeleteByIdAsync(string id)
		{
			Data.Models.Task task = await dbContext.Tasks
				.FirstAsync(t => t.Id == new Guid(id));

			TaskViewModel model = new TaskViewModel()
			{
				Id = task.Id.ToString(),
				Title = task.Title,
				Description = task.Description,
				
			};

			return model;
		}

		public async Task<TaskDetailsViewModel> GetForDetailsByIdAsync(string id)
		{
			TaskDetailsViewModel viewModel = await dbContext
				.Tasks
				.AsNoTracking()
				.Select(t => new TaskDetailsViewModel
				{
					Id = t.Id.ToString(),
					Title = t.Title,
					Description = t.Description,
					Owner = t.Owner.UserName,
					CreatedOn = t.CreatedOn.ToString("f"),
					Board = t.Board.Name
				})
				.FirstAsync(t => t.Id == id);

			return viewModel;
		}

		public async Task<TaskFormModel> GetForEditByIdAsync(string id)
		{
			Guid idAsGuid = new Guid(id);
			Data.Models.Task task = await dbContext
				.Tasks
				.FirstAsync(t => t.Id == idAsGuid);

			TaskFormModel taskModel = new TaskFormModel()
			{
				Title = task.Title,
				BoardId = task.BoardId,
				Description = task.Description,
			};

			return taskModel;
		}

		public async System.Threading.Tasks.Task UpdateAsync(string taskId, TaskFormModel viewModel)
		{
			Data.Models.Task task = await dbContext.Tasks
				.FirstAsync(t => t.Id == new Guid(taskId));
			task.BoardId = viewModel.BoardId;
			task.Title = viewModel.Title;
			task.Description = viewModel.Description;

			await dbContext.SaveChangesAsync();
		}

	}
}
