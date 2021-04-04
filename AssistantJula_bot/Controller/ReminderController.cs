using AssistantJula_bot.Model;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AssistantJula_bot.Controller
{
	public class ReminderController
	{
		/// <summary>
		/// Список всех напоминаний из бд
		/// </summary>
		public List<Reminder> Reminders;

		public ReminderController()
		{
			string queryString = "SELECT IdChat, Time, Message FROM dbo.Reminder";
			using SqlConnection connection = new(ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString);
			SqlCommand command = new(queryString, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				Reminders.Add(new Reminder() { IdChat = (long)reader[0], Time = (TimeSpan)reader[1], Message = (string)reader[2] });
			}
		}

		/// <summary>
		/// Добавление в бд
		/// </summary>
		/// <param name="idChat"></param>
		/// <param name="time"></param>
		/// <param name="message"></param>
		/// <returns>0 - если всё прошло успешно, 1 - с ошибкой</returns>
		public static int Add(long idChat, TimeSpan time, string message)
		{
			try
			{
				string queryString = $"INSERT INTO dbo.Reminder (IdChat, Time, Message) VALUES ({idChat},'{time}','{message}')";
				using SqlConnection connection = new(@"Server=DESKTOP-25EV0KI\DEV;Database=AssistanJula_Db;Trusted_Connection = True;");
				connection.Open();
				SqlDataAdapter adapter = new(queryString, connection);
				adapter.Fill(new DataSet());
				return 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return 1;
			}
		}
	}
}
