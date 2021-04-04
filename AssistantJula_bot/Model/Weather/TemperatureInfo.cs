namespace AssistantJula_bot.Model.Weather
{
	/// <summary>
	/// Информация о температуре
	/// </summary>
	public class TemperatureInfo
	{
		/// <summary>
		/// Фактическая температура
		/// </summary>
		public float temp { get; set; }
		/// <summary>
		/// По ощущению
		/// </summary>
		public double feels_like { get; set; }
	}
}
