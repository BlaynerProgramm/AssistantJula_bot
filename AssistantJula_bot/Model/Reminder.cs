using System;

namespace AssistantJula_bot.Model
{
	/// <summary>
	/// Напоминание
	/// </summary>
	public class Reminder
	{
		public Guid Id { get; set; }
		/// <summary>
		/// ID чата для отправки
		/// </summary>
		public long IdChat { get; set; }
		/// <summary>
		/// Через сколько отправить напоминание
		/// </summary>
		public TimeSpan Time { get; set; }
		/// <summary>
		/// Текст напоминания
		/// </summary>
		public string Message { get; set; }
	}
}
