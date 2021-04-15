using AssistantJula_bot.Controller;

using MailKit;
using MailKit.Net.Imap;

using System;
using System.Collections.Generic;

using Telegram.Bot.Types;

namespace AssistantJula_bot.Model.Commands
{
	/// <summary>
	/// Работа с почтой
	/// </summary>
	public class EmailCommand : ICommand
	{
		public string Name { get; init; } = "Email";
		/// <summary>
		/// Список писем
		/// </summary>
		private static readonly List<Email> _emails = new();
		/// <summary>
		/// Счётчик писем
		/// </summary>
		private static int _i;
		/// <summary>
		/// Операция над сообщениями
		/// </summary>
		/// <returns></returns>
		public delegate int OperationEmail();

		/// <summary>
		/// Получение информации об аккаунте
		/// </summary>
		/// <param name="idChat"></param>
		public EmailCommand(long idChat)
		{
			string[] account = EmailController.GetInfoEmailBox(idChat);
			GetEmail(account[0], account[1]);
		}

		public void Execute(Message message) =>
			Bot.AssistantJula.SendTextMessageAsync
						(
							chatId: message.Chat,
							text: _emails[_i = 0].ToString(),
							replyMarkup: KeyboardTemplates.inlineEmailKeyboard
						).ConfigureAwait(false);

		#region Навигация
		/// <summary>
		/// Следующее письмо
		/// </summary>
		/// <returns>Следующее письмо</returns>
		public static int NextEmail() => ++_i;
		/// <summary>
		/// Предыдущее письмо
		/// </summary>
		/// <returns>Предыдущее письмо</returns>
		public static int BackEmail() => --_i;
		/// <summary>
		/// Навигация по письмам
		/// </summary>
		/// <param name="operation">Следующее или предыдущее</param>
		/// <returns>Письмо</returns>
		public static string NavigationEmail(OperationEmail operation)
		{
			try
			{
				return _emails[operation.Invoke()].ToString();
			}
			catch (ArgumentOutOfRangeException)
			{
				return "Некуда листать";
			}
		}
		#endregion
		/// <summary>
		/// Получить все письма
		/// </summary>
		/// <param name="login">Логин</param>
		/// <param name="password">Пароль</param>
		private static void GetEmail(string login, string password)
		{
			using (ImapClient client = new())
			{
				IMailFolder inbox;
				#region Проверка ошибок при подключении к почте
				try
				{
					client.Connect("imap.gmail.com", 993, true);
					client.Authenticate(login, password);
					inbox = client.Inbox;
				}
				catch (ArgumentNullException ex)
				{
					throw new ArgumentNullException(ex.Message);
				}
				catch (ArgumentOutOfRangeException ex)
				{
					throw new ArgumentOutOfRangeException(ex.Message);
				}
				catch (ArgumentException ex)
				{
					throw new ArgumentException(ex.Message);
				}
				catch (ObjectDisposedException ex)
				{
					throw new ObjectDisposedException(ex.Message);
				}
				catch (InvalidOperationException ex)
				{
					throw new InvalidOperationException(ex.Message);
				}
				catch (OperationCanceledException ex)
				{
					throw new OperationCanceledException(ex.Message);
				}
				catch (System.Net.Sockets.SocketException ex)
				{
					throw new System.Net.Sockets.SocketException(ex.ErrorCode);
				}
				catch (System.IO.IOException ex)
				{
					throw new System.IO.IOException(ex.Message);
				}
				catch (ProtocolException ex)
				{
					throw new Exception(ex.Message);
				}
				catch (MailKit.Security.AuthenticationException ex)
				{
					throw new MailKit.Security.AuthenticationException(ex.Message);
				}
				#endregion

				inbox.Open(FolderAccess.ReadOnly);
				for (int i = 0; i < inbox.Count; i++)
				{
					_emails.Add(new Email() { SenderName = inbox.GetMessage(i).From[0].Name, Subject = inbox.GetMessage(i).Subject, Text = inbox.GetMessage(i).TextBody });
				}
			}
			_emails.Reverse();
		}
	}
}
