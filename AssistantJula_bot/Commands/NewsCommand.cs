using AssistantJula_bot.Model;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Commands;

/// <summary>
/// Новости
/// </summary>
internal class NewsCommand : ICommand
{
    public string Name { get; init; } = "News";

    public async void Execute(Message message) =>
        await Bot.AssistantJula.SendTextMessageAsync
        (
            chatId: message.Chat
        )
}
