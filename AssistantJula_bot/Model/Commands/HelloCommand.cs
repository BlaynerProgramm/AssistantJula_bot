using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AssistantJula_bot.Model.Commands
{
	internal class HelloCommand : ICommand
	{
		public string Name { get; init; } = "Hello";

		public async void Execute(Message message, TelegramBotClient client) =>
			await client.SendTextMessageAsync
						(
							chatId: message.Chat,
							text: "Приветствую, меня зовут Jula, вот мои функции на данный момент: ",
							replyMarkup: mainKeyboard
						).ConfigureAwait(false);

		/// <summary>
		/// Настройка клавиатуры
		/// </summary>
		private readonly ReplyKeyboardMarkup mainKeyboard = new()
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
	}
}
