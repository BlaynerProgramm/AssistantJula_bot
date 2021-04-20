using System;

using Telegram.Bot.Types;

namespace AssistantJula_bot.Model.Commands
{
	/// <summary>
	/// Узнать время
	/// </summary>
	public class TimeCommand : ICommand
	{
		public string Name { get; init; } = "Время";

		public async void Execute(Message message)
		{
			await Bot.AssistantJula.SendTextMessageAsync
			  (
				  chatId: message.Chat,
				  text: DateTime.Now.ToUniversalTime().ToShortTimeString()
				  ).ConfigureAwait(false);
		}
	}
}
