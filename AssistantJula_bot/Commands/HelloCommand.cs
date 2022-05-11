using AssistantJula_bot.Model;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Commands;

/// <summary>
/// Приветствие
/// </summary>
internal class HelloCommand : ICommand
{
    public string Name { get; init; } = "Hello";

    public async void Execute(Message message) =>
        await Bot.AssistantJula.SendTextMessageAsync
        (
            chatId: message.Chat,
            text: "Приветствую, меня зовут Jula, вот мои функции на данный момент: ",
            replyMarkup: KeyboardTemplates.mainKeyboard
        ).ConfigureAwait(false);
}