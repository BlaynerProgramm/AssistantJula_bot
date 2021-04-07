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
		private static string message;
		private string time;

		/// <summary>
		/// Создание напоминания
		/// </summary>
		/// <param name="e">Экземпляр сообщения</param>
		public void CreateRemider(Message e)
		{
			long cid = e.Chat.Id;

			switch (flag)
			{
				case 2: SaveToDb(e, cid); break;
				case 1: SetTime(e, cid); break;
				case 0: SetMessage(cid); break;
			}
		}

		private static void SetMessage(long cid)
		{
			flag = 1;
			Bot.AssistantJula.SendTextMessageAsync(cid, "О чём вам напомнить?", replyMarkup: KeyboardTemplates.cancelKeyboard);
		}

		private static void SetTime(Message e, long cid)
		{
			message = e.Text;
			if (message != "Отмена")
			{
				flag = 2;
				Bot.AssistantJula.SendTextMessageAsync(cid, "Через сколько минут?", replyMarkup: KeyboardTemplates.timeKeyboard);
			}
			else
			{
				flag = 4;
				Bot.AssistantJula.SendTextMessageAsync(cid, "Отмена операции");
			}
		}

		private void SaveToDb(Message e, long cid)
		{
			time = e.Text;
			Bot.Flag = false;
			flag = 4;
			Console.WriteLine("Создание напоминания от " + cid);
			string response = ReminderController.Add(e.Chat.Id, new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute + Convert.ToInt32(time), DateTime.Now.Second), message);
			Bot.AssistantJula.SendTextMessageAsync(cid, response, replyMarkup: KeyboardTemplates.mainKeyboard);
		}

		/// <summary>
		/// Отправка напоминаний в назначенное время
		/// </summary>
		public static async void SendReminder()
		{
			Reminder reminder = null;
			while (reminder is null)
			{
				reminder = ReminderController.CheckTimeReminders();
			}

			await Bot.AssistantJula.SendTextMessageAsync
			   (
			   chatId: reminder.IdChat,
			   text: $"Напоминание {reminder.Message}"
			   );
			ReminderController.Delete(reminder);
		}
	}
}