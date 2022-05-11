using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace AssistantJula_bot.Model.Newspapers.ria;

internal sealed record RiaRu : INewspaper<RiaRu>
{
	public string Title { get; private set; }
	public string Link { get; private set; }
	public string Date { get; private set; }
	public string Description { get; private set; }

	[Obsolete("Obsolete")]
	public static IEnumerable<RiaRu> GetNews()
	{
		const string url = @"https://ria.ru/export/rss2/archive/index.xml";
		var request = WebRequest.Create(url);
		var response = request.GetResponse();
		XmlDocument xmlDocument = new();

		using (StreamReader stream = new(response.GetResponseStream()))
		{
			xmlDocument.LoadXml(stream.ReadToEnd());
		}

		return ParseXml(xmlDocument);
	}

	private static IEnumerable<RiaRu> ParseXml(XmlDocument xmlDocument)
	{
		var xRoot = xmlDocument.DocumentElement;
		var newsArticle = new RiaRu();
		
		foreach (var node in from XmlElement el in xRoot
		         from XmlNode node in el.ChildNodes
		         where node.Name == "item" select node)
		{
			foreach (XmlNode item in node.ChildNodes)
			{
				switch (item.Name)
				{
					case "title":
						newsArticle.Title = item.InnerText;
						break;
					case "description":
						newsArticle.Description = item.InnerText;
						break;
					case "link":
						newsArticle.Link = item.InnerText;
						break;
					case "pubDate":
						newsArticle.Date = item.InnerText;
						break;
				}
			}
			yield return newsArticle;
		}
	}
	public override string ToString() => $"{Title}\n{Description}\n\n{Date}\n{Link}";
}