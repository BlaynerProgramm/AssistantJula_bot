using Telegram.Bot.Types.ReplyMarkups;

namespace AssistantJula_bot;

/// <summary>
/// Шаблоны клавиатур для бота
/// </summary>
internal static class KeyboardTemplates
{
	/// <summary>
	/// Меню
	/// </summary>
	public static readonly ReplyKeyboardMarkup mainKeyboard = new(new[]
	{
		new KeyboardButton[] { "Time", "Test2", "Test 3" }
	})
	{
		ResizeKeyboard = true
	};
}