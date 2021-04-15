using System.Configuration;
using System.Data.SqlClient;

namespace AssistantJula_bot.Controller
{
	public class EmailController
	{
		/// <summary>
		/// Получить определенный аккаунт
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Массив строк, где элемент 0 - логин, 1 - пароль</returns>
		public static string[] GetInfoEmailBox(long id)
		{
			string[] accountInfo = new string[2];

			string queryString = $"SELECT Login, Password FROM dbo.Email WHERE IdChat = {id}";
			using SqlConnection connection = new(ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString);
			SqlCommand command = new(queryString, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				accountInfo[0] = (string)reader[0];
				accountInfo[1] = (string)reader[1];
			}
			return accountInfo;
		}
	}
}
