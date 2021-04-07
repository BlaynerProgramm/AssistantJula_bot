namespace AssistantJula_bot.Model.Newspapers
{
	/// <summary>
	/// Новости Медузы
	/// </summary>
	public class MeduzaNewspaper
	{
		public string Title { get; set; }
		public string Description { get; set; }
		/// <summary>
		/// Дата публикации
		/// </summary>
		public string Date { get; set; }
		/// <summary>
		/// Ссылка на публикацию
		/// </summary>
		public string Url { get; set; }
		/// <summary>
		/// Ссылка на картинку
		/// </summary>
		public string Image { get; set; }

		public override string ToString() => $"{Title}\nПодробней:\n{Description}\nСсылка: {Url}\nОпубликовано: {Date}";
	}
}
