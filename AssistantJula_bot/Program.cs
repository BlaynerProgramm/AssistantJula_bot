using AssistantJula_bot.Model;
using AssistantJula_bot.Model.Commands;

using System;
using System.Threading.Tasks;

namespace AssistantJula_bot
{
	internal class Program
	{
		private static void Main()
		{
			Task checkTimeReminders = new(() => ReminderCommand.SendReminder());
			checkTimeReminders.Start();

			Console.Title = Bot.Me.FirstName;
			Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"Бот {Bot.Me.Id}:{Bot.Me.FirstName} подключён"); Console.ResetColor();
			Bot.AssistantJula.OnMessage += AJula_OnMessage;
			Bot.AssistantJula.OnCallbackQuery += AssistantJula_OnCallbackQuery;

			Bot.AssistantJula.StartReceiving();
			Console.ReadKey();
		}

		private static void AssistantJula_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
		{
			switch (e.CallbackQuery.Data)
			{
				case "next":
					Bot.AssistantJula.EditMessageTextAsync
					   (
						   chatId: e.CallbackQuery.From.Id,
						   messageId: e.CallbackQuery.Message.MessageId,
						   text: NewsCommand.TurningPages(),
						   replyMarkup: KeyboardTemplates.inlineNewsKeyboard
					   ).ConfigureAwait(false);
					break;
			}
		}

		private static void AJula_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
		{
			ICommand command;
			switch (e.Message.Text.ToLower())
			{
				case null: return;
				case "привет":
					command = new HelloCommand();
					command.Execute(e.Message);
					break;
				case "время":
					command = new TimeCommand();
					command.Execute(e.Message);
					break;
				case "погода":
					command = new WeatherCommand();
					command.Execute(e.Message);
					break;
				case "курс":
					command = new CurrencyCommand();
					command.Execute(e.Message);
					break;
				case "создание напоминания":
					Bot.Flag = true;
					break;
				case "газета":
					command = new NewsCommand();
					command.Execute(e.Message);
					break;

			}
			if (Bot.Flag)
			{
				command = new ReminderCommand();
				command.Execute(e.Message);
			}
		}
	}
}
