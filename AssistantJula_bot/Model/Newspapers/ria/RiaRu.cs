namespace AssistantJula_bot.Model.Newspapers.ria;

internal sealed record RiaRu
{
	public string Title { get; set; }
	public string Link { get; set; }
	public string Date { get; set; }
	public string Description { get; set; }

	public override string ToString() => $"{Title}\n{Description}\n\n{Date}\n{Link}";
}