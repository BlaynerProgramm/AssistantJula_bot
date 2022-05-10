using Telegram.Bot.Types;

namespace AssistantJula_bot.Commands;

internal interface ICommand
{
    public string Name { get; init; }

    public void Execute(Message message);
}