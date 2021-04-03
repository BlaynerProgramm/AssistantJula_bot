using System;

namespace AssistantJula_bot.Model
{
	public class Reminder
	{
		public int Id { get; set; }
		public long IdChat { get; set; }
		public TimeSpan Time { get; set; }
		public string Message { get; set; }
	}
}
