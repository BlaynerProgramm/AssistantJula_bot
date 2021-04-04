using System;
using System.Configuration;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Model
{
	/// <summary>
	/// Информация о боте
	/// </summary>
	public static class Bot
	{
		public static bool flag;
		/// <summary>
		/// Экземпляр бота
		/// </summary>
		public static TelegramBotClient AssistantJula { get; private set; } = new(ConfigurationManager.AppSettings.Get("ApiKeyBot")) { Timeout = TimeSpan.FromSeconds(10) };

		/// <summary>
		/// Информация о боте
		/// </summary>
		public static User Me { get; private set; } = AssistantJula.GetMeAsync().Result;

		/// <summary>
		/// Получить всю информацию о боте
		/// </summary>
		/// <returns>Строка со всей информацией</returns>
		public static string GetFullInfo()
		{
			return "";
		}
	}
}
