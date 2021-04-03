using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Model.Commands
{
	public class ReminderCommand : ICommand
	{
		public string Name { get; init; } = "Создание напоминания";

		public void Execute(Message message, TelegramBotClient client)
		{
			//TODO: Доделать напоминания
		}
	}
}
