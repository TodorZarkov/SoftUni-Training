namespace TaskBoardApp.Web.ViewModels.Home
{
	using TaskBoardApp.Web.ViewModels.Board;

	public class HomeViewModel
	{
		public HomeViewModel()
		{
			BoardsWithTasksCount = new List<BoardCountViewModel>();
		}
		public int AllTasksCount { get; set; }

		public int UserTasksCount { get; set; }

		public ICollection<BoardCountViewModel> BoardsWithTasksCount { get; set; }
	}
}
