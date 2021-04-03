using AssistantJula_bot.Model;
using AssistantJula_bot.Model.Commands;

using System;
using System.Configuration;

using Telegram.Bot;

namespace AssistantJula_bot
{
	class Program
	{
		private static TelegramBotClient AJula { get; set; } 
		static void Main()
		{
			Console.Title = "Assistant Jula";

			AJula = new(ConfigurationManager.AppSettings.Get("ApiKeyBot")) { Timeout = TimeSpan.FromSeconds(10) };

			var me = AJula.GetMeAsync().Result;
			Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"Бот {me.Id}:{me.FirstName} подключён"); Console.ResetColor();

			AJula.OnMessage += AJula_OnMessage;

			AJula.StartReceiving();
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
					command.Execute(e.Message, AJula);
					break;
				case "время":
					command = new TimeCommand();
					command.Execute(e.Message, AJula);
					break;
				case "погода":
					command = new WeatherCommand();
					command.Execute(e.Message, AJula);
					break;
				case "курс":
					command = new CurrencyCommand();
					command.Execute(e.Message, AJula);
					break;
			}
		}
	}
}
