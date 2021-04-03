using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Model
{
	internal interface ICommand
	{
		public string Name { get; init; }

		public void Execute(Message message, TelegramBotClient client);

		public bool Contains(string command)
		{
			return true; //TODO: Проверка
		}

	}
}
