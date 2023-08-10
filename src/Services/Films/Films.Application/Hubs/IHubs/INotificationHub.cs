namespace Films.Application.Hubs.IHubs
{
	public interface INotificationHub
	{
		public Task SendMessage(string message);
	}
}
