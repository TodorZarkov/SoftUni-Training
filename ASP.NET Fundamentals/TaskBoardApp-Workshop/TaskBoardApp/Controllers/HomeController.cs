namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TaskBoardApp.Extensions;
    using TaskBoardApp.Services.Interfaces;
    using TaskBoardApp.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IBoardService boardService;
        public HomeController(ITaskService taskService, IBoardService boardService)
        {
            this.taskService = taskService;
            this.boardService = boardService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                AllTasksCount = await taskService.CountAsync(),
                UserTasksCount = await taskService.CountAsync(User.GetId()),
                BoardsWithTasksCount = await boardService.AllWithTasksAsync()
            };
            

            return View(model);
        }
    }
}