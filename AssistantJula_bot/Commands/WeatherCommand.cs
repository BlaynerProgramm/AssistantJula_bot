using AssistantJula_bot.Model;
using AssistantJula_bot.Model.Weather;
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
            text: Weather.GetWeather("Samara")
        ).ConfigureAwait(false);
}