namespace AssistantJula_bot.Model.Weather
{
	/// <summary>
	/// Класс содержащий всю информацию о погоде
	/// </summary>
	internal class Weather
	{
		/// <summary>
		/// Информация о температуре
		/// </summary>
		public TemperatureInfo main { get; set; }
		/// <summary>
		/// Прогноз за день
		/// </summary>
		public WeatherInfo[] weather { get; set; }
		/// <summary>
		/// Информация о ветре
		/// </summary>
		public Wind wind { get; set; }
		/// <summary>
		/// Название региона
		/// </summary>
		public string name { get; set; }
	}
}
