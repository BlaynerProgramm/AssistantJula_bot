using Telegram.Bot.Types.ReplyMarkups;

namespace AssistantJula_bot.Model
{
	/// <summary>
	/// Шаблоны клавиатур для бота
	/// </summary>
	public static class KeyboardTemplates
	{
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
						}
				   }
		};
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
		private static readonly ReplyKeyboardMarkup cityKeyboard = new ReplyKeyboardMarkup
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
		public static readonly ReplyKeyboardMarkup cancelKeyboard = new ReplyKeyboardMarkup
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
	}
}
