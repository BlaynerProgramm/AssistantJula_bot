using AssistantJula_bot.Model.Valute;
using System.IO;
using System.Net;
using System.Text.Json;

namespace AssistantJula_bot.Model.Currencies;

public class Valute_
{
    public ListValite Valute { get; set; }

    public static string GetExchangeRates()
    {
        string url = "https://www.cbr-xml-daily.ru/daily_json.js";
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();

        string jsonResponse;
        using (StreamReader stream = new(response.GetResponseStream()))
        {
            jsonResponse = stream.ReadToEnd();
        }
        Valute_ currency = JsonSerializer.Deserialize<Valute_>(jsonResponse);
        return $"1 {currency.Valute.USD.CharCode} = {currency.Valute.USD.Value}₽\n1 {currency.Valute.EUR.CharCode} = {currency.Valute.EUR.Value}₽";
    }
}
