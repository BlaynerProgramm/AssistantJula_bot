using AssistantJula_bot.Model;
using AssistantJula_bot.Model.Commands;

using System;

namespace AssistantJula_bot
{
	internal class Program
	{
		private static void Main()
		{
			Console.Title = Bot.Me.FirstName;
			Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"Бот {Bot.Me.Id}:{Bot.Me.FirstName} подключён"); Console.ResetColor();
			Bot.AssistantJula.OnMessage += AJula_OnMessage;

			Bot.AssistantJula.StartReceiving();
			Console.ReadKey();
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
					Bot.flag = true;
					break;
			}
			if (Bot.flag)
			{
				command = new ReminderCommand();
				command.Execute(e.Message);
			}
		}
	}
}
