using Films.Application.Hubs.IHubs;
using Microsoft.AspNetCore.SignalR;

namespace Films.Application.Hubs
{
	public class NotificationHub : Hub<INotificationHub>
	{
	}
}
