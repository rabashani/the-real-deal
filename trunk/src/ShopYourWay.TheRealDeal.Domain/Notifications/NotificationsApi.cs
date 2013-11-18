using System;
using System.Linq;
using Platform.Client.Common.Context;

namespace ShopYourWay.TheRealDeal.Domain.Notifications
{
	public interface INotificationsApi
	{
		void Push(string message, params long[] userIds);
	}
	public class NotificationsApi : ApiBase, INotificationsApi
	{
		private readonly INotificationsSettings _settings;

		public NotificationsApi(IContextProvider contextProvider,
			INotificationsSettings settings)
			: base(contextProvider)
		{
			_settings = settings;
		}

		public void Push(string message, params long[] userIds)
		{
			if (_settings.Disable || userIds == null || !userIds.Any() || string.IsNullOrEmpty(message))
				return;

			try
			{
				Call<object>("push", new { ids = userIds, text = message, payload = "message=" + message });
			}
			catch (Exception)
			{
				//_logger.Warn(string.Format("Error occurred while trying to send notification to users: {0}. Text:{1}", string.Join(",", userIds), message), ex);
			}
		}

		protected override string BasePath
		{
			get { return "notifications/mobile"; }
		}
	}
}