using System;
using System.Configuration;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Models;

/// <summary>
/// Информация о боте
/// </summary>
internal static class Bot
{
	/// <summary>
	/// Экземпляр бота
	/// </summary>
	public static TelegramBotClient AssistantJula { get; } = new(ConfigurationManager.AppSettings.Get("ApiKeyBot")) { Timeout = TimeSpan.FromSeconds(10) };

	/// <summary>
	/// Информация о боте
	/// </summary>
	public static User Me { get; } = AssistantJula.GetMeAsync().Result;
}