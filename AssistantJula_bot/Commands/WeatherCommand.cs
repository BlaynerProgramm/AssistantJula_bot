using AssistantJula_bot.Model;
using AssistantJula_bot.Model.Weather;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Commands;
/// <summary>
/// Узнать погоду
/// </summary>
internal class WeatherCommand : ICommand
{
    public string Name { get; init; } = "Weather";

    public async void Execute(Message message) =>
        await Bot.AssistantJula.SendTextMessageAsync
        (
            chatId: message.Chat,
            text: GetWeather("Samara")
        ).ConfigureAwait(false);


    private static string GetWeather(string city)
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