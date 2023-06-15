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
	}
}
