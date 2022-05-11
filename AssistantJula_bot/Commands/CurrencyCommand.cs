using AssistantJula_bot.Model;
using AssistantJula_bot.Model.Currencies;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Commands;

internal class CurrencyCommand : ICommand
{
    public string Name { get; init; } = "Currency";

    public async void Execute(Message message) =>
        await Bot.AssistantJula.SendTextMessageAsync
                        (
                            chatId: message.Chat,
                            text: Valute_.GetExchangeRates()
                        ).ConfigureAwait(false);
}