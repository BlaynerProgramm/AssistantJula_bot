using System.IO;
using System.Net;
using System.Text.Json;

using Telegram.Bot.Types;

namespace AssistantJula_bot.Model.Commands
{
	/// <summary>
	/// Узнать курс
	/// </summary>
	internal class CurrencyCommand : ICommand
	{
		public string Name { get; init; } = "Курс";

		public async void Execute(Message message) =>
			await Bot.AssistantJula.SendTextMessageAsync
						(
							chatId: message.Chat,
							text: GetExchangeRates()
						).ConfigureAwait(false);

		private static string GetExchangeRates()
		{
			string url = "https://www.cbr-xml-daily.ru/daily_json.js";
			WebRequest request = WebRequest.Create(url);
			WebResponse webResponse = request.GetResponse();

			string jsonResponse;
			using (StreamReader stream = new(webResponse.GetResponseStream()))
			{
				jsonResponse = stream.ReadToEnd();
			}
			Valute.Valute_ currency = JsonSerializer.Deserialize<Valute.Valute_>(jsonResponse);
			return $"1 {currency.Valute.USD.CharCode} = {currency.Valute.USD.Value}₽\n1 {currency.Valute.EUR.CharCode} = {currency.Valute.EUR.Value}₽";
		}

	}
}
