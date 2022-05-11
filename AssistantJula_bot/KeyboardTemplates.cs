using Telegram.Bot.Types.ReplyMarkups;

namespace AssistantJula_bot;

/// <summary>
/// Шаблоны клавиатур для бота
/// </summary>
internal static class KeyboardTemplates
{
	#region ReplyKeyboard

	/// <summary>
	/// Меню
	/// </summary>
	public static readonly ReplyKeyboardMarkup mainKeyboard = new()
	{
		Keyboard =
			new KeyboardButton[][]
			{
				new KeyboardButton[]
				{
					new KeyboardButton("Время"),
				},
				new KeyboardButton[]
				{
					new KeyboardButton("Погода"),
				},
				new KeyboardButton[]
				{
					new KeyboardButton("Создание напоминания"),
				},
				new KeyboardButton[]
				{
					new KeyboardButton("Курс"),
				},
				new KeyboardButton[]
				{
					new KeyboardButton("Газета"),
				},
				new KeyboardButton[]
				{
					new KeyboardButton("Почта"),
				}
			}
	};
	/// <summary>
	/// Время
	/// </summary>
	public static readonly ReplyKeyboardMarkup timeKeyboard = new()
	{
		Keyboard =
			new KeyboardButton[][]
			{
				new KeyboardButton[]
				{
					new KeyboardButton("5"),
				},
				new KeyboardButton[]
				{
					new KeyboardButton("10"),
				},
				new KeyboardButton[]
				{
					new KeyboardButton("15"),
				},
				new KeyboardButton[]
				{
					new KeyboardButton("20"),
				}
			}
	};
	/// <summary>
	/// Города
	/// </summary>
	public static readonly ReplyKeyboardMarkup cityKeyboard = new()
	{
		Keyboard =
			new KeyboardButton[][]
			{
				new KeyboardButton[]
				{
					new KeyboardButton("Samara"),
				},
				new KeyboardButton[]
				{
					new KeyboardButton("Moscow"),
				},
				new KeyboardButton[]
				{
					new KeyboardButton("Tolyatti"),
				}
			}
	};
	/// <summary>
	/// Кнопка отмены операции
	/// </summary>
	public static readonly ReplyKeyboardMarkup cancelKeyboard = new()
	{
		Keyboard =
			new KeyboardButton[][]
			{
				new KeyboardButton[]
				{
					new KeyboardButton("Отмена")
				}
			}
	};
	#endregion
	#region InlineKeyboard
	/// <summary>
	/// Встроенная клавиатура для новостей
	/// </summary>
	public static readonly InlineKeyboardMarkup inlineNewsKeyboard = new
	(
		new InlineKeyboardButton[][]
		{
			new []
			{
				new InlineKeyboardButton() { Text = "Назад", CallbackData = "back" },
				new InlineKeyboardButton() { Text = "Дальше", CallbackData = "next"},
			},
		}
	);
	/// <summary>
	/// Встроенная клавиатура для писем
	/// </summary>
	public static readonly InlineKeyboardMarkup inlineEmailKeyboard = new
	(
		new InlineKeyboardButton[][]
		{
			new []
			{
				new InlineKeyboardButton() { Text = "Назад", CallbackData = "backE" },
				new InlineKeyboardButton() { Text = "Дальше", CallbackData = "nextE"},
			},
		}
	);
	#endregion
}