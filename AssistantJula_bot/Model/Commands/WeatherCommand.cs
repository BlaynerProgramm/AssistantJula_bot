using System.Configuration;
using System.IO;
using System.Net;
using System.Text.Json;

using Telegram.Bot.Types;

namespace AssistantJula_bot.Model.Commands
{
	/// <summary>
	/// Узнать погоду
	/// </summary>
	public class WeatherCommand : ICommand
	{
		public string Name { get; init; } = "Погода";

		public async void Execute(Message message) =>
			await Bot.AssistantJula.SendTextMessageAsync
						(
							chatId: message.Chat,
							text: GetWeather("Samara")
						).ConfigureAwait(false);

		/// <summary>
		/// Получить погоду.
		/// </summary>
		/// <param name="city">Город</param>
		/// <returns>Отформатированную строку</returns>
		private static string GetWeather(string city)
		{
			string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={ConfigurationManager.AppSettings.Get("ApiKeyWeather")}";
			WebRequest request = WebRequest.Create(url);
			WebResponse webResponse = request.GetResponse();
			string jsonResponse;

			using (StreamReader stream = new(webResponse.GetResponseStream()))
			{
				jsonResponse = stream.ReadToEnd();
			}
			Weather.Weather weatherResponse = JsonSerializer.Deserialize<Weather.Weather>(jsonResponse);

			return $"Сейчас в {weatherResponse.name} {weatherResponse.main.temp}°C чувствуется как {weatherResponse.main.feels_like}°C\nВ первой половине дня {weatherResponse.weather[0].description}\nВетер {weatherResponse.wind.speed} м/с";
		}
	}
}
