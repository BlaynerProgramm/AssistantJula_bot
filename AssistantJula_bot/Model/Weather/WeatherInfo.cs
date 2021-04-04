namespace AssistantJula_bot.Model.Weather
{
	/// <summary>
	/// Прогноз погоды
	/// </summary>
	public class WeatherInfo
	{
		/// <summary>
		/// Прогноз
		/// </summary>
		public string main { get; set; }
		/// <summary>
		/// Подробности
		/// </summary>
		public string description { get; set; }
	}
}