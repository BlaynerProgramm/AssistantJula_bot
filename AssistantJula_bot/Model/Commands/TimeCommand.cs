using System;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Model.Commands
{
	public class TimeCommand : ICommand
	{
		public string Name { get; init; } = "Время";

		public async void Execute(Message message, TelegramBotClient client)
		{
			await client.SendTextMessageAsync
			  (
				  chatId: message.Chat,
				  text: DateTime.Now.ToLocalTime().ToShortTimeString()
				  ).ConfigureAwait(false);
		}
	}
}
