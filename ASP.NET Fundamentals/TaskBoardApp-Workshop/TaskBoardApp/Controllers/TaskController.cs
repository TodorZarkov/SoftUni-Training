namespace TaskBoardApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using TaskBoardApp.Extensions;
	using TaskBoardApp.Services.Interfaces;
	using TaskBoardApp.Web.ViewModels.Task;

	[Authorize]
	public class TaskController : Controller
	{
		private readonly IBoardService boardService;
		private readonly ITaskService taskService;

		public TaskController(IBoardService boardService, ITaskService taskService)
		{
			this.boardService = boardService;
			this.taskService = taskService;
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			TaskFormModel viewModel = new TaskFormModel()
			{
				AllBoards = await boardService.AllForSelectAsync()
			};

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(TaskFormModel taskModel)
		{
			if (!ModelState.IsValid)
			{
				taskModel.AllBoards = await boardService.AllForSelectAsync();
				return View(taskModel);
			}

			bool boardExists = await boardService.ExistsByIdAsync(taskModel.BoardId);
			if (!boardExists)
			{
				ModelState.AddModelError(nameof(taskModel.BoardId), "Selected board does not exist!");
				taskModel.AllBoards = await boardService.AllForSelectAsync();
				return View(taskModel);
			}

			string currentUserId = User.GetId();

			await taskService.AddAsync(currentUserId, taskModel);

			return RedirectToAction("All", "Board");

		}

		[HttpGet]
		public async Task<IActionResult> Details(string id)
		{
			try
			{
				TaskDetailsViewModel viewModel = 
					await taskService.GetForDetailsByIdAsync(id);

				return View(viewModel);
			}
			catch (Exception)
			{
				return RedirectToAction("All", "Board");
			}
		}

	}
}
