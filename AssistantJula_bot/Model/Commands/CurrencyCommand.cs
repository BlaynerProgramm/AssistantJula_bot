using System.IO;
using System.Net;
using System.Text.Json;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace AssistantJula_bot.Model.Commands
{
	internal class CurrencyCommand : ICommand
	{
		public string Name { get; init; } = "Курс";

		public async void Execute(Message message, TelegramBotClient client) =>
			await client.SendTextMessageAsync
						(
							chatId: message.Chat,
							text: GetExchangeRates()
						).ConfigureAwait(false);

		private static string GetExchangeRates()
		{
			string url = "https://www.cbr-xml-daily.ru/daily_json.js";
			WebRequest request = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();

			string jsonResponse;
			using (StreamReader stream = new(webResponse.GetResponseStream()))
			{
				jsonResponse = stream.ReadToEnd();
			}
			Valute.Valute_ currency = JsonSerializer.Deserialize<Valute.Valute_>(jsonResponse);
			return $"{currency.Valute.USD.Value} - {currency.Valute.USD.CharCode}";
		}

	}
}
