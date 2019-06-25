using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ITworks.Brom {
	/// <summary>
	/// Настройки подключения клиента Бром к опубликованной информационной базе 1С:Предприятие.
	/// </summary>
	public sealed class НастройкиПодключения {
		/// <summary>
		/// Конструктор настроек подключения.
		/// </summary>
		/// <param name="адресПубликации">Адрес публикации информационной базы 1С:Предприятие во внутренней или внешней сети.</param>
		/// <param name="имяПользователя">Имя пользователя информационной базы 1С:Предприятие.</param>
		/// <param name="пароль">Пароль пользователя информационной базы 1С:Предприятие.</param>
		public НастройкиПодключения(EndpointAddress адресПубликации, string имяПользователя, string пароль) {
			this.publicationAddress = адресПубликации;
			this.userName = имяПользователя;
			this.password = пароль;
		}
		/// <summary>
		/// Конструктор настроек подключения.
		/// </summary>
		/// <param name="строкаПодключения">Строка, содержащая параметры подключения. Строка должна содержать параметры: "Публикация", "Пользователь" и "Пароль". Параметры разделяются символом ";".</param>
		public НастройкиПодключения(string строкаПодключения) {
			Dictionary<string, string> значения = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			string[] фрагменты = строкаПодключения.Split(';');
			foreach (string фрагмент in фрагменты) {
				string[] разбивка = фрагмент.Split('=', StringSplitOptions.RemoveEmptyEntries);
				if (разбивка.Length == 2) {
					значения[разбивка[0].Trim()] = разбивка[1].Trim();
				}
			}

			string адресПубликации;
			if (!значения.TryGetValue("Публикация", out адресПубликации) && !значения.TryGetValue("Publication", out адресПубликации)) {
				throw new ArgumentException("Не указан параметр \"Публикация (Publication)\"", "строкаПодключения");
			}
			string имяПользователя;
			if (!значения.TryGetValue("Пользователь", out имяПользователя) && !значения.TryGetValue("User", out имяПользователя)) {
				throw new ArgumentException("Не указан параметр \"Пользователь (User)\"", "строкаПодключения");
			}
			string пароль = "";
			bool парольПолучен = значения.TryGetValue("Пароль", out пароль) || значения.TryGetValue("Password", out пароль);

			this.publicationAddress = new EndpointAddress(адресПубликации);
			this.userName = имяПользователя;
			this.password = пароль;
		}

		private readonly EndpointAddress publicationAddress;
		private readonly string userName;
		private readonly string password;

		/// <summary>
		/// Адрес публикации информационной базы 1С:Предприятие во внутренней или внешней сети.
		/// </summary>
		public EndpointAddress АдресПубликации {
			get { return this.publicationAddress; }
		}
		/// <summary>
		/// Имя пользователя информационной базы 1С:Предприятие.
		/// </summary>
		public string ИмяПользователя {
			get { return this.userName; }
		}
		/// <summary>
		/// Пароль пользователя информационной базы 1С:Предприятие.
		/// </summary>
		public string Пароль {
			get { return this.password; }
		}
	}
}
