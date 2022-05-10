namespace AssistantJula_bot.Model
{
	public class Email
	{
		public string SenderName { get; set; }
		public string Subject { get; set; }
		public string Text { get; set; }
		public int CountEmails { get; set; }
		
		public override string ToString() => $"Ваша почта:\n\nОт {SenderName}\n{Subject}\n{Text}\n";
	}
}