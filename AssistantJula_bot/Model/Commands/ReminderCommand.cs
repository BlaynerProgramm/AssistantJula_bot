using AssistantJula_bot.Controller;

using System;

using Telegram.Bot.Types;

namespace AssistantJula_bot.Model.Commands
{
	/// <summary>
	/// Создание напоминания
	/// </summary>
	public class ReminderCommand : ICommand
	{
		public string Name { get; init; } = "Создание напоминания";

		public void Execute(Message message) => CreateRemider(message);


		private static byte flag = 0;
		string message;
		string time;
		public void CreateRemider(Message e)
		{
			long cid = e.Chat.Id;

			switch (flag)
			{
				case 2: Step3(e, cid); break;
				case 1: Step2(e, cid); break;
				case 0: Step1(cid); break;
			}
		}

		private void Step1(long cid)
		{
			flag = 1;
			Bot.AssistantJula.SendTextMessageAsync(cid, "О чём вам напомнить?", replyMarkup: KeyboardTemplates.cancelKeyboard);
		}

		private void Step2(Message e, long cid)
		{
			message = e.Text;
			if (message != "Отмена")
			{
				flag = 2;
				Bot.AssistantJula.SendTextMessageAsync(cid, "Через сколько минут?");
			}
			else
			{
				flag = 4;
				Bot.AssistantJula.SendTextMessageAsync(cid, "Отмена операции");
			}
		}

		private void Step3(Message e, long cid)
		{
			time = e.Text;
			Bot.flag = false;
			flag = 4;
			Console.WriteLine("Создание напоминания от " + cid); //TODO: Проверки
			ReminderController.Add(e.Chat.Id, new TimeSpan(DateTime.Now.Hour, Convert.ToInt32(time), DateTime.Now.Second), message);
			Bot.AssistantJula.SendTextMessageAsync(cid, $"{message} через {time}");
		}
	}
}
