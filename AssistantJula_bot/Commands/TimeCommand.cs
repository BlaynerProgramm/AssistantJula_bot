using AssistantJula_bot.Model;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Commands;

/// <summary>
/// Узнать время
/// </summary>
internal class TimeCommand : ICommand
{
    public string Name { get; init; } = "Time";

    public async void Execute(Message message) =>
        await Bot.AssistantJula.SendTextMessageAsync
        (
            chatId: message.Chat,
            text: DateTime.Now.ToUniversalTime().ToShortTimeString()
        ).ConfigureAwait(false);
}