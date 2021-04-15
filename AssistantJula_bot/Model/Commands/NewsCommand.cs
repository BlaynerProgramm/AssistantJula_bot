using AssistantJula_bot.Model.Newspapers;

using System;
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

		/// <summary>
		/// Счётчик
		/// </summary>
		private static int _i;
		/// <summary>
		/// Коллекция всех новостей
		/// </summary>
		private static readonly List<MeduzaNewspaper> _meduzaNewspapers = GetNews();
		/// <summary>
		/// Операция
		/// </summary>
		/// <returns></returns>
		public delegate int Operation();

		public async void Execute(Message message) =>
			await Bot.AssistantJula.SendTextMessageAsync
					   (
						   chatId: message.Chat,
						   text: _meduzaNewspapers[_i=0].ToString(),
						   replyMarkup: KeyboardTemplates.inlineNewsKeyboard
					   ).ConfigureAwait(false);

		#region Навигация
		/// <summary>
		/// Следующая страница
		/// </summary>
		/// <returns></returns>
		public static int NextPages() => ++_i;
		/// <summary>
		/// Предыдущая страница
		/// </summary>
		/// <returns></returns>
		public static int BackPages() => --_i;
		/// <summary>
		/// Навигация по газете
		/// </summary>
		/// <param name="operation">Следующая или предыдущая</param>
		/// <returns></returns>
		public static string NavigationNewspaper(Operation operation)
		{
			try
			{
				return _meduzaNewspapers[operation.Invoke()].ToString();
			}
			catch (ArgumentOutOfRangeException)
			{
				return "Некуда листать";
			}
		}
		#endregion
		/// <summary>
		/// Получить новости
		/// </summary>
		/// <returns>Коллекцию новостей</returns>
		private static List<MeduzaNewspaper> GetNews()
		{
			string url = @"https://meduza.io/rss2/all";
			WebRequest request = WebRequest.Create(url);
			WebResponse response = request.GetResponse();
			XmlDocument xmlDocument = new();
			using (StreamReader stream = new(response.GetResponseStream()))
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
