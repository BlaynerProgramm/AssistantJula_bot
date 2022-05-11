using Telegram.Bot.Types;

namespace AssistantJula_bot.Commands;

internal interface ICommand
{
    /// <summary>
    /// Название команды
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <param name="message"></param>
    public void Execute(Message message);
}