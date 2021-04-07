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
		/// Список всех напоминаний из бд.
		/// </summary>
		public List<Reminder> Reminders { get; init; }

		/// <summary>
		/// Получение всех напоминаний.
		/// </summary>
		public ReminderController()
		{
			Reminders = new();
			string queryString = "SELECT Id, IdChat, Time, Message FROM dbo.Reminder";
			using SqlConnection connection = new(ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString);
			SqlCommand command = new(queryString, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				Reminders.Add(new Reminder() { Id = (Guid)reader[0], IdChat = (long)reader[1], Time = (TimeSpan)reader[2], Message = (string)reader[3] });
			}
		}
		//TODO:Сделать logs
		/// <summary>
		/// Добавление в бд.
		/// </summary>
		/// <param name="idChat">Id чата (long)</param>
		/// <param name="time">Время</param>
		/// <param name="message">Сообщение</param>
		/// <returns>0 - если всё прошло успешно, 1 - с ошибкой</returns>
		public static string Add(long idChat, TimeSpan time, string message)
		{
			try
			{
				string queryString = $"INSERT INTO dbo.Reminder (IdChat, Time, Message) VALUES ({idChat},'{time}','{message}')";
				using SqlConnection connection = new(ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString);
				connection.Open();
				SqlDataAdapter adapter = new(queryString, connection);
				adapter.Fill(new DataSet());
				return $"{message} через {time}";
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine(ex.ToString());
				return ex.Message;
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.ToString());
				return ex.Message;
			}
			catch (ConfigurationErrorsException ex)
			{
				Console.WriteLine(ex.ToString());
				return ex.Message;
			}
		}
		/// <summary>
		/// Удаление
		/// </summary>
		/// <param name="reminder"></param>
		/// <returns></returns>
		public static string Delete(Reminder reminder)
		{
			try
			{
				string queryString = $"DELETE dbo.Reminder WHERE Id = '{reminder.Id}'";
				using SqlConnection connection = new(ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString);
				connection.Open();
				SqlDataAdapter adapter = new(queryString, connection);
				adapter.Fill(new DataSet());
				return "Операция прошла успешно";
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine(ex.ToString());
				return ex.Message;
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.ToString());
				return ex.Message;
			}
			catch (ConfigurationErrorsException ex)
			{
				Console.WriteLine(ex.ToString());
				return ex.Message;
			}
		}
		/// <summary>
		/// Проверка времени напоминаний
		/// </summary>
		/// <returns></returns>
		public static Reminder CheckTimeReminders()
		{
			TimeSpan time = new(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
			string queryString = $"SELECT Id, IdChat, Time, Message FROM dbo.Reminder WHERE Time = '{time}'";
			using SqlConnection connection = new(ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString);
			SqlCommand command = new(queryString, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			Reminder reminder = null;
			while (reader.Read())
			{
				reminder = new Reminder() { Id = (Guid)reader[0], IdChat = (long)reader[1], Time = (TimeSpan)reader[2], Message = (string)reader[3] };
			}
			return reminder;
		}
	}
}
