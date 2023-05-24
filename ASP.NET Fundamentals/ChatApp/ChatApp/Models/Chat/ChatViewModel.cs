namespace ChatApp.Models.Chat
{
	public class ChatViewModel
	{
		public ChatViewModel()
		{
			AllMessages = new HashSet<MessageViewModel>();
		}
		public MessageViewModel CurrentMessage { get; set; } = null!;

		public ICollection<MessageViewModel> AllMessages { get; set; }
	}
}
