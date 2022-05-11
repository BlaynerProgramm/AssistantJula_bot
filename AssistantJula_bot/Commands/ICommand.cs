using Telegram.Bot.Types;

namespace AssistantJula_bot.Commands;

internal interface ICommand
{
    /// <summary>
    /// �������� �������
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// ���������� �������
    /// </summary>
    /// <param name="message"></param>
    public void Execute(Message message);
}