namespace AssistantJula_bot.Model;

internal sealed record Email(string SenderName, string Subject, string Text)
{
	public override string ToString() => $"Ваша почта:\n\nОт {SenderName}\n{Subject}\n{Text}\n";
}