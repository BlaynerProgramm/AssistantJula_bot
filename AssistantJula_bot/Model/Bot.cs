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
		/// <summary>
		/// Вспомогательный флаг
		/// </summary>
		public static bool Flag { get; set; }
		/// <summary>
		/// Экземпляр бота
		/// </summary>
		public static TelegramBotClient AssistantJula { get; } = new(ConfigurationManager.AppSettings.Get("ApiKeyBot")) { Timeout = TimeSpan.FromSeconds(10) };

		/// <summary>
		/// Информация о боте
		/// </summary>
		public static User Me { get; private set; } = AssistantJula.GetMeAsync().Result;
	}
}
