using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using AssistantJula_bot.Model.Newspapers.ria;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Commands;

internal sealed class NewsCommand : ICommand
{
    private readonly LinkedList<RiaRu> _newsList;
    
    public string Name { get; init; } = "Новости";
    public delegate RiaRu Operation();
    
    public void Execute(Message message)
    {
        
    }
    
    public string NavigationNewspaper(Operation operation)
    {
        try
        {
            return _newsList.ToString();
        }
        catch (ArgumentOutOfRangeException)
        {
            return "Некуда листать";
        }
    }
    public NewsCommand()
    {
        _newsList = new LinkedList<RiaRu>(GetNews());
    }
    public RiaRu NextPage() => _newsList.First.Next.Value;
    public RiaRu BackPage() => _newsList.First.Previous.Value;
    [Obsolete("Obsolete")]
    private static IEnumerable<RiaRu> GetNews()
    {
        const string url = @"https://ria.ru/export/rss2/archive/index.xml";
        var request = WebRequest.Create(url);
        var response = request.GetResponse();
        XmlDocument xmlDocument = new();
        var xRoot = xmlDocument.DocumentElement;
        RiaRu news = new();
        
        using (StreamReader stream = new(response.GetResponseStream()))
        {
            xmlDocument.LoadXml(stream.ReadToEnd());
        }
        
        foreach (var node in from XmlElement el in xRoot
                 from XmlNode node in el.ChildNodes
                 where node.Name == "item" select node)
        {
            foreach (XmlNode item in node.ChildNodes)
            {
                switch (item.Name)
                {
                    case "title":
                        news.Title = item.InnerText;
                        break;
                    case "description":
                        news.Description = item.InnerText;
                        break;
                    case "link":
                        news.Link = item.InnerText;
                        break;
                    case "pubDate":
                        news.Date = item.InnerText;
                        break;
                }
            }
            yield return news;
        }
    }
}