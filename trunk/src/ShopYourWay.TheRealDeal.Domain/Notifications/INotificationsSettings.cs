using ShopYourWay.TheRealDeal.Domain.Configuration;

namespace ShopYourWay.TheRealDeal.Domain.Notifications
{
	public interface INotificationsSettings
	{
		bool Disable { get; }
	}

	public class NotificationsSettings : INotificationsSettings
	{
		public bool Disable { get { return Config.GetBoolean("notifications:disable"); } }
	}
}