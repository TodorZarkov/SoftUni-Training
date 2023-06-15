namespace TaskBoardApp.Services.Interfaces
{
	using Microsoft.EntityFrameworkCore;
	using TaskBoardApp.Web.ViewModels.Task;

	public interface ITaskService
	{
		public Task AddAsync(string ownerId, TaskFormModel viewModel);

		public Task<TaskDetailsViewModel> GetForDetailsByIdAsync(string id);

		public Task<TaskFormModel> GetForEditByIdAsync(string id);

		public Task UpdateAsync(string taskId, TaskFormModel taskModel);

		public System.Threading.Tasks.Task DeleteAsync(string taskId);

		public Task<TaskViewModel> GetForDeleteByIdAsync(string id);

		public Task<int> CountAsync();

		public Task<int> CountAsync(string userId);

	}
}
