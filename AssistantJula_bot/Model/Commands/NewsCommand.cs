using AssistantJula_bot.Model.Newspapers;

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

using Telegram.Bot.Types;

namespace AssistantJula_bot.Model.Commands
{
	/// <summary>
	/// Новости
	/// </summary>
	public class NewsCommand : ICommand
	{
		public string Name { get; init; } = "Газета";

		private static int i = 0;

		public async void Execute(Message message)
		{
			await Bot.AssistantJula.SendTextMessageAsync
					   (
						   chatId: message.Chat,
						   text: GetNews()[0].ToString(),
						   replyMarkup: KeyboardTemplates.inlineNewsKeyboard
					   ).ConfigureAwait(false);
		}
		/// <summary>
		/// Перелестнуть страницу
		/// </summary>
		/// <returns></returns>
		public static string TurningPages() => GetNews()[i++].ToString();

		/// <summary>
		/// Получить новости
		/// </summary>
		/// <returns></returns>
		private static List<MeduzaNewspaper> GetNews()
		{
			string url = @"https://meduza.io/rss2/all";
			WebRequest request = WebRequest.Create(url);
			WebResponse response = request.GetResponse();
			XmlDocument xmlDocument = new();
			using (StreamReader stream = new StreamReader(response.GetResponseStream()))
			{
				xmlDocument.LoadXml(stream.ReadToEnd());
			}
			XmlElement xRoot = xmlDocument.DocumentElement;
			List<MeduzaNewspaper> listNews = new(); //TODO: ArrayList
			MeduzaNewspaper news;

			foreach (XmlElement el in xRoot)
			{
				foreach (XmlNode node in el.ChildNodes)
				{
					if (node.Name == "item")
					{
						news = new();
						foreach (XmlNode item in node.ChildNodes)
						{
							if (item.Name == "title")
							{
								news.Title = item.InnerText;
							}

							if (item.Name == "description")
							{
								news.Description = item.InnerText;
							}
							if (item.Name == "link")
							{
								news.Url = item.InnerText;
							}
							if (item.Name == "pubDate")
							{
								news.Date = item.InnerText;
							}
							if (item.Name == "enclosure")
							{
								news.Image = item.Attributes.GetNamedItem("url").Value;
							}
						}
						listNews.Add(news);
					}
				}
			}
			return listNews;
		}
	}
}
