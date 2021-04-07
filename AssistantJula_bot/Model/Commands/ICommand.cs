using Telegram.Bot.Types;

namespace AssistantJula_bot.Model
{
	internal interface ICommand
	{
		/// <summary>
		/// Название команды
		/// </summary>
		public string Name { get; init; }

		/// <summary>
		/// Действие команды
		/// </summary>
		/// <param name="message"></param>
		public void Execute(Message message);
	}
}