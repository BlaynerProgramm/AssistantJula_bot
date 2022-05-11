using System.Configuration;
using System.IO;
using System.Net;
using System.Text.Json;

namespace AssistantJula_bot.Model.Weather;

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

    public static string GetWeather(string city)
    {
        string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={ConfigurationManager.AppSettings.Get("ApiKeyWeather")}";
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        string jsonResponse;

        using (StreamReader stream = new(response.GetResponseStream()))
        {
            jsonResponse = stream.ReadToEnd();
        }

        Weather weatherResponse = JsonSerializer.Deserialize<Weather>(jsonResponse);

        return $"Сейчас в {weatherResponse.name} {weatherResponse.main.temp}°C чувствуется как {weatherResponse.main.feels_like}°C\n" +
            $"В первой половине дня {weatherResponse.weather[0].description}\nВетер {weatherResponse.wind.speed} м/с";
    }
}
