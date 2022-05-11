using System;
using System.Collections.Generic;
using AssistantJula_bot.Models;
using AssistantJula_bot.Models.Newspapers.ria;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Commands;

internal sealed class NewsCommand : ICommand
{
    private static int _indexArticle;
    private static readonly List<RiaRu> _newsList = new(RiaRu.GetNews());
    
    public string Name { get; init; } = "Новости";
    public delegate int Operation();
    
    public async void Execute(Message message) =>
        await Bot.AssistantJula.SendTextMessageAsync
        (
            chatId: message.Chat,
            text: _newsList[_indexArticle=0].ToString(),
            replyMarkup: KeyboardTemplates.inlineNewsKeyboard
        ).ConfigureAwait(false);
    
    /// <summary>
    /// Навигация по газете
    /// </summary>
    /// <param name="operation">Куда перелестнуть</param>
    /// <returns></returns>
    public static string NewspaperNavigation(Operation operation)
    {
        try
        {
            return _newsList[operation.Invoke()].ToString();
        }
        catch (ArgumentOutOfRangeException)
        {
            return "Некуда листать";
        }
    }
    public static int NextPages() => ++_indexArticle;
    public static int BackPages() => --_indexArticle;
}