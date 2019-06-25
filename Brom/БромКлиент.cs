using ITworks.Brom.Metadata;
using ITworks.Brom.SOAP;
using ITworks.Brom.Types;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ITworks.Brom {
	/// <summary>
	/// Клиентский модуль, обеспечивающий взаимодействие с расширением "Бром", установленным в 1С:Предприятие.
	/// </summary>
	public class БромКлиент : DynamicObject {
		/// <summary>
		/// Конструктор клиента на основе настроек подключения.
		/// </summary>
		/// <param name="натройкиПодключения">Настройки подключения.</param>
		public БромКлиент(НастройкиПодключения натройкиПодключения) {
			this.connectionSettings = натройкиПодключения;

			BasicHttpBinding myBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
			myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
			myBinding.MaxReceivedMessageSize = 65536 * 1000;
			myBinding.ReceiveTimeout = TimeSpan.FromSeconds(120);
			myBinding.SendTimeout = TimeSpan.FromSeconds(120);
			myBinding.AllowCookies = true;

			string адресСервиса = натройкиПодключения.АдресПубликации.Uri.AbsoluteUri.TrimEnd('/') + @"/ws/brom_api";
			this.soapClient = new BromSoapClient(myBinding, new EndpointAddress(адресСервиса));
			this.soapClient.ClientCredentials.UserName.UserName = натройкиПодключения.ИмяПользователя;
			this.soapClient.ClientCredentials.UserName.Password = натройкиПодключения.Пароль;

			this.metadata = new МетаданныеКонфигурация(this);

			this.dataContext = new КонтекстДанных(this);
		}
		/// <summary>
		/// Конструктор на основе параметров подключения.
		/// </summary>
		/// <param name="адресПубликации">Адрес публикации информационной базы 1С:Предприятие во внутренней или внешней сети.</param>
		/// <param name="имяПользователя">Имя пользователя информационной базы 1С:Предприятие.</param>
		/// <param name="пароль">Пароль пользователя информационной базы 1С:Предприятие.</param>
		public БромКлиент(EndpointAddress адресПубликации, string имяПользователя, string пароль) : this(new НастройкиПодключения(адресПубликации, имяПользователя, пароль)) { }
		/// <summary>
		/// Конструктор клиента на основе строки подключения.
		/// </summary>
		/// <param name="строкаПодключения">Строка, содержащая параметры подключения. Строка должна содержать параметры: "Публикация", "Пользователь" и "Пароль". Параметры разделяются символом ";".</param>
		public БромКлиент(string строкаПодключения) : this(new НастройкиПодключения(строкаПодключения)) { }

		private readonly BromSoapClient soapClient;
		private readonly НастройкиПодключения connectionSettings;
		private МетаданныеКонфигурация metadata;
		private readonly КонтекстДанных dataContext;

		internal BromSoapClient SoapКлиент {
			get { return this.soapClient; }
		}

		private async Task<object> ВыполнитьЗапросОбщееАсинх(string текстЗапроса, IDictionary<string, object> параметры = null, IList<УсловиеОтбора> отбор = null, IList<ПолеДанных> поля = null, IList<Сортировка> порядок = null, bool пакетный = false, ОбходРезультатаЗапроса типОбхода = ОбходРезультатаЗапроса.Прямой, bool включатьВременныеДанные = false) {
			ExecuteRequest_Settings settings = new ExecuteRequest_Settings();
			if (параметры != null) {
				settings.Parameter = new RequestParameter[параметры.Count];
				int i = 0;
				foreach (KeyValuePair<string, object> параметр in параметры) {
					RequestParameter parameter = new RequestParameter();
					parameter.Key = параметр.Key;
					parameter.Value = ValueBase.From(параметр.Value);
					settings.Parameter[i] = parameter;
					i++;
				}
			}
			if (отбор != null) {
				settings.Filter = new RequestFilter[отбор.Count];
				for (int i = 0; i < отбор.Count; i++) {
					RequestFilter filter = new RequestFilter();
					filter.Key = отбор[i].Ключ;
					filter.Value = ValueBase.From(отбор[i].Значение);
					filter.ComparisonType = отбор[i].ВидСравнения.ToString();
					settings.Filter[i] = filter;
				}
			}
			if (поля != null) {
				settings.Field = new RequestField[поля.Count];
				int i = 0;
				foreach (ПолеДанных поле in поля) {
					RequestField field = new RequestField();
					field.Key = поле.Ключ;
					field.Name = поле.Псевдоним;
					settings.Field[i] = field;
					i++;
				}
			}
			if (порядок != null) {
				settings.Sort = new RequestSort[порядок.Count];
				int i = 0;
				foreach (Сортировка элементПорядка in порядок) {
					RequestSort sort = new RequestSort();
					sort.Key = элементПорядка.Ключ;
					sort.Direction = элементПорядка.Направление == НаправлениеСортировки.Убывание ? "Убыв" : "Возр";
					settings.Sort[i] = sort;
					i++;
				}
			}
			settings.QueryResultIteration			= типОбхода.ToString();
			settings.IncludeTemporalData			= включатьВременныеДанные;
			settings.IncludeTemporalDataSpecified	= включатьВременныеДанные;

			if (!пакетный) {
				Task<ExecuteRequestResponse> task = this.SoapКлиент.ExecuteRequestAsync(текстЗапроса, settings);
				return (await task).@return.GetValue(this);
			}
			else {
				Task<ExecuteRequestBatchResponse> task = this.SoapКлиент.ExecuteRequestBatchAsync(текстЗапроса, settings);

				return (await task).@return.GetValue(this);
			}
		}
		private object ВыполнитьЗапросОбщее(string текстЗапроса, IDictionary<string, object> параметры = null, IList<УсловиеОтбора> отбор = null, IList<ПолеДанных> поля = null, IList<Сортировка> порядок = null, bool пакетный = false, ОбходРезультатаЗапроса типОбхода = ОбходРезультатаЗапроса.Прямой, bool включатьВременныеДанные = false) {
			Task<object> task = this.ВыполнитьЗапросОбщееАсинх(текстЗапроса, параметры, отбор, поля, порядок, пакетный, типОбхода, включатьВременныеДанные);
			task.Wait();
			return task.Result;
		}

		/// <summary>
		/// Метаданные удаленной конфигурации 1С:Предприятие.
		/// </summary>
		public МетаданныеКонфигурация Метаданные {
			get { return this.metadata; }
		} 
		
		/// <summary>
		/// Контекст, содержащий данные объектов информационной базы 1С:Предприятие.
		/// </summary>
		/// <returns></returns>
		public КонтекстДанных Контекст() {
			return this.dataContext;
		}

		/// <summary>
		/// Текущие настройки подключения.
		/// </summary>
		/// <returns></returns>
		public НастройкиПодключения НастройкиПодключения() {
			return this.connectionSettings;
		}

		/// <summary>
		/// Загружает указанные метаданные с сервера 1С:Предприятие и кеширует их, если установлен объект кеша.
		/// </summary>
		/// <param name="состав">Список объектов метаданных, которые необходимо загрузить.</param>
		/// <param name="размерПакета">Максимальное количество объектов метаданных в одном пакете.</param>
		public void ЗагрузитьМетаданные(string состав, int размерПакета) {
			this.Метаданные.Загрузить(состав, размерПакета);
		}
		/// <summary>
		/// Загружает указанные метаданные с сервера 1С:Предприятие одним пакетом и кеширует их, если установлен объект кеша.
		/// </summary>
		/// <param name="состав">Список объектов метаданных, которые необходимо загрузить.</param>
		public void ЗагрузитьМетаданные(string состав) {
			this.Метаданные.Загрузить(состав);
		}
		/// <summary>
		/// Асинхронно загружает указанные метаданные с сервера 1С:Предприятие и кеширует их, если установлен объект кеша.
		/// </summary>
		/// <param name="состав">Список объектов метаданных, которые необходимо загрузить.</param>
		/// <param name="размерПакета">Максимальное количество объектов метаданных в одном пакете.</param>
		public Task ЗагрузитьМетаданныеАсинх(string состав, int размерПакета) {
			return this.Метаданные.ЗагрузитьАсинх(состав, размерПакета);
		}
		/// <summary>
		/// Асинхронно загружает указанные метаданные с сервера 1С:Предприятие одним пакетом и кеширует их, если установлен объект кеша.
		/// </summary>
		/// <param name="состав">Список объектов метаданных, которые необходимо загрузить.</param>
		public Task ЗагрузитьМетаданныеАсинх(string состав) {
			return this.Метаданные.ЗагрузитьАсинх(состав);
		}

		/// <summary>
		/// Вызывает удаленный метод на стороне 1C:Предприятие и возвращает результат.
		/// </summary>
		/// <param name="имяМодуля">Имя модуля удаленного приложения 1С:Предприятие.</param>
		/// <param name="имяМетода">Имя метода (процедуры или функции).</param>
		/// <param name="параметры">Параметры метода.</param>
		/// <returns></returns>
		public object ВызватьМетод(string имяМодуля, string имяМетода, object[] параметры) {
			ValueArray paramArray = ValueBase.From(параметры) as ValueArray;

			Task<object> task = this.ВызватьМетодАсинх(имяМодуля, имяМетода, параметры);
			task.Wait();

			return task.Result;
		}
		/// <summary>
		/// Асинхронно вызывает удаленный метод на стороне 1C:Предприятие и возвращает результат.
		/// </summary>
		/// <param name="имяМодуля">Имя модуля удаленного приложения 1С:Предприятие.</param>
		/// <param name="имяМетода">Имя метода (процедуры или функции).</param>
		/// <param name="параметры">Параметры метода.</param>
		/// <returns></returns>
		public async Task<object> ВызватьМетодАсинх(string имяМодуля, string имяМетода, object[] параметры) {
			ValueArray paramArray = ValueBase.From(параметры) as ValueArray;

			Task<ExecuteMethodResponse> task = this.SoapКлиент.ExecuteMethodAsync(имяМодуля, имяМетода, paramArray);

			return (await task).@return.GetValue(this);
		}

		/// <summary>
		/// Выполняет фрагмент кода на языке 1С:Предприятие на стороне сервера.
		/// </summary>
		/// <param name="исполняемыКод">Текст исполняемого кода.</param>
		/// <returns>Возвращает значение, которое было установлено в переменную "Результат" на стороне 1С.</returns>
		public object Выполнить(string исполняемыКод) {
			return this.Выполнить(исполняемыКод, null);
		}
		/// <summary>
		/// Выполняет фрагмент кода на языке 1С:Предприятие на стороне сервера.
		/// </summary>
		/// <param name="исполняемыКод">Текст исполняемого кода.</param>
		/// <param name="параметр">Значение параметра, которое доступно в исполняемом коде в переменной "Параметр".</param>
		/// <returns>Возвращает значение, которое было установлено в переменную "Результат" на стороне 1С.</returns>
		public object Выполнить(string исполняемыКод, object параметр) {
			Task<object> task = this.ВыполнитьАсинх(исполняемыКод, параметр);
			task.Wait();
			return task.Result;
		}
		/// <summary>
		/// Асинхронно выполняет фрагмент кода на языке 1С:Предприятие на стороне сервера.
		/// </summary>
		/// <param name="исполняемыКод">Текст исполняемого кода.</param>
		/// <returns>Возвращает значение, которое было установлено в переменную "Результат" на стороне 1С.</returns>
		public Task<object> ВыполнитьАсинх(string исполняемыКод) {
			return this.ВыполнитьАсинх(исполняемыКод, null);
		}
		/// <summary>
		/// Асинхронно выполняет фрагмент кода на языке 1С:Предприятие на стороне сервера.
		/// </summary>
		/// <param name="исполняемыКод">Текст исполняемого кода.</param>
		/// <param name="параметр">Значение параметра, которое доступно в исполняемом коде в переменной "Параметр".</param>
		/// <returns>Возвращает значение, которое было установлено в переменную "Результат" на стороне 1С.</returns>
		public async Task<object> ВыполнитьАсинх(string исполняемыКод, object параметр) {
			Task<ExecuteCodeResponse> task = this.SoapКлиент.ExecuteCodeAsync(исполняемыКод, ValueBase.From(параметр));
			return (await task).@return.GetValue(this);
		}

		public Task<object> ВыполнитьЗапросАсинх(
				string текстЗапроса,
				IDictionary<string, object> параметры = null,
				IList<УсловиеОтбора> отборы = null,
				IList<ПолеДанных> поля = null,
				IList<Сортировка> порядок = null,
				ОбходРезультатаЗапроса типОбхода = ОбходРезультатаЗапроса.Прямой) {
			return this.ВыполнитьЗапросОбщееАсинх(текстЗапроса, параметры, отборы, поля, порядок, false, типОбхода);
		}
		public object ВыполнитьЗапрос(
				string текстЗапроса, 
				IDictionary<string, object> параметры = null, 
				IList<УсловиеОтбора> отборы = null, 
				IList<ПолеДанных> поля = null,
				IList<Сортировка> порядок = null, 
				ОбходРезультатаЗапроса типОбхода = ОбходРезультатаЗапроса.Прямой) {
			return this.ВыполнитьЗапросОбщее(текстЗапроса, параметры, отборы, поля, порядок, false, типОбхода);
		}

		public Task<object> ВыполнитьПакетныйЗапросАсинх(
			string текстЗапроса, IDictionary<string, object>
			параметры = null, IList<УсловиеОтбора> отборы = null,
			IList<ПолеДанных> поля = null,
			IList<Сортировка> порядок = null,
			ОбходРезультатаЗапроса типОбхода = ОбходРезультатаЗапроса.Прямой,
			bool включатьВременныеДанные = false) {

			return this.ВыполнитьЗапросОбщееАсинх(текстЗапроса, параметры, отборы, поля, порядок, true, типОбхода, включатьВременныеДанные);
		}
		public object ВыполнитьПакетныйЗапрос(
			string текстЗапроса, IDictionary<string, object> 
			параметры = null, IList<УсловиеОтбора> отборы = null, 
			IList<ПолеДанных> поля = null,
			IList<Сортировка> порядок = null, 
			ОбходРезультатаЗапроса типОбхода = ОбходРезультатаЗапроса.Прямой,
			bool включатьВременныеДанные = false) {

			return this.ВыполнитьЗапросОбщее(текстЗапроса, параметры, отборы, поля, порядок, true, типОбхода, включатьВременныеДанные);
		}

		public object ПолучитьЗначениеПараметраСеанса(string имяПараметраСеанса) {
			Task<object> task = this.ПолучитьЗначениеПараметраСеансаАсинх(имяПараметраСеанса);
			task.Wait();

			return task.Result;
		}
		public async Task<object> ПолучитьЗначениеПараметраСеансаАсинх(string имяПараметраСеанса) {
			Task<ValueBase> task = this.SoapКлиент.GetSessionParameterAsync(имяПараметраСеанса);
			return (await task).GetValue(this);
		}

		public object ПолучитьЗначениеКонстанты(string имяКонстанты) {
			Task<object> task = this.ПолучитьЗначениеКонстантыАсинх(имяКонстанты);
			task.Wait();

			return task.Result;
		}
		public async Task<object> ПолучитьЗначениеКонстантыАсинх(string имяКонстанты) {
			Task<GetConstantResponse> task = this.SoapКлиент.GetConstantAsync(имяКонстанты, null);

			return (await task).@return.GetValue(this);
		}
		public void УстановитьЗначениеКонстанты(string имяКонстанты, object значение) {
			Task task = this.УстановитьЗначениеКонстантыАсинх(имяКонстанты, значение);
			task.Wait();
		}
		public async Task УстановитьЗначениеКонстантыАсинх(string имяКонстанты, object значение) {
			await this.SoapКлиент.SetConstantAsync(имяКонстанты, ValueBase.From(значение));
		}

		/// <summary>
		/// Создает новый запрос к базе данных 1С:Предприятие.
		/// </summary>
		/// <param name="текст">Текст запроса.</param>
		/// <returns>Возвращает новый объект запроса к базе данных 1С:Предприятие.</returns>
		public Запрос СоздатьЗапрос(string текст = "") {
			return new Запрос(this, текст);
		}

		public ДеревоЗначений ПолучитьДанныеОбъекта(
			Ссылка ссылка, 
			IEnumerable<string> поля = null, 
			АвтозагрузкаПолейОбъектов автозагрузкаПолей = null) {

			Task<ДеревоЗначений> task = this.ПолучитьДанныеОбъектаАсинх(ссылка, поля, автозагрузкаПолей);
			task.Wait();

			return task.Result;
		}
		public async Task<ДеревоЗначений> ПолучитьДанныеОбъектаАсинх(
			Ссылка ссылка,
			IEnumerable<string> поля = null,
			АвтозагрузкаПолейОбъектов автозагрузкаПолей = null) {

			автозагрузкаПолей = автозагрузкаПолей ?? АвтозагрузкаПолейОбъектов.Ничего;

			GetObject_Settings settings = new GetObject_Settings();
			settings.AddSkippedProperties = true;
			settings.AddSkippedPropertiesSpecified = true;
			settings.PropertiesHierarchyType = "Hierarchy";

			settings.FieldAutoinclusion = new RequestFieldAutoinclusionSettings();
			settings.FieldAutoinclusion.DefaultFields = автозагрузкаПолей.ЗагружатьСтандартныеРеквизиты;
			settings.FieldAutoinclusion.DefaultFieldsSpecified = автозагрузкаПолей.ЗагружатьСтандартныеРеквизиты;
			settings.FieldAutoinclusion.CustomFields = автозагрузкаПолей.ЗагружатьПользовательскиеРеквизиты;
			settings.FieldAutoinclusion.CustomFieldsSpecified = автозагрузкаПолей.ЗагружатьПользовательскиеРеквизиты;
			settings.FieldAutoinclusion.Tables = автозагрузкаПолей.ЗагружатьТабличныеЧасти;
			settings.FieldAutoinclusion.TablesSpecified = автозагрузкаПолей.ЗагружатьТабличныеЧасти;

			if (поля != null) {
				string[] именаПолей = поля.ToArray();
				settings.Field = new RequestField[именаПолей.Length];
				for (int i = 0; i < именаПолей.Length; i++) {
					RequestField field = new RequestField();
					field.Key = именаПолей[i];
					settings.Field[i] = field;
				}
			}

			Task<GetObjectResponse> task = this.SoapКлиент.GetObjectAsync((ValueRef)ValueBase.From(ссылка), settings);

			return (await task).@return.ToTree(this);
		}

		/// <summary>
		/// Создает селектор, позволяющий формировать выборки из коллекций ссылочного типа.
		/// </summary>
		/// <returns>Возвращает новый селектор.</returns>
		public Селектор СоздатьСелектор() {
			Селектор селектор = new Селектор(this);
			return селектор;
		}

		public async Task<Структура> ПолучитьИнформациюОСистемеАсинх() {
			Task<ValueStruct> task = this.soapClient.GetSystemInfoAsync();
			return (await task).GetValue<Структура>(this);
		}
		public Структура ПолучитьИнформациюОСистеме() {
			Task<Структура> task = this.ПолучитьИнформациюОСистемеАсинх();
			task.Wait();
			return task.Result;
		}

		/// <summary>
		/// Метод для отладки и тестирования. Возвращает пустую строку, отправленную сервером.
		/// </summary>
		public void Ping() {
			Task<string> task = this.soapClient.DebugPingAsync();
			task.Wait();
		}

		/// <summary>
		/// Метод для отладки и тестирования. Асинхронно возвращает обратно значение переданное серверу.
		/// </summary>
		/// <param name="значение">Значение, передаваемое на сервер.</param>
		/// <returns>Возвращает обратно значение переданное серверу.</returns>
		public async Task<object> ЭхоАсинх(object значение) {
			Task<ValueBase> task = this.soapClient.DebugEchoAsync(ValueBase.From(значение));
			return (await task).GetValue(this);
		}
		/// <summary>
		/// Метод для отладки и тестирования. Возвращает обратно значение переданное серверу.
		/// </summary>
		/// <param name="значение">Значение, передаваемое на сервер.</param>
		/// <returns>Возвращает обратно значение переданное серверу.</returns>
		public object Эхо(object значение) {
			Task<object> task = this.ЭхоАсинх(значение);
			task.Wait();
			return task.Result;
		}

		#region DynamicObject
		private bool TryGetMemberCommon(string name, out object result) {
			УзелМетаданных текМетаданные;
			if (this.Метаданные.ПопыткаНайти(name, out текМетаданные)) {
				switch (текМетаданные.Имя()) {
					case "ПараметрыСеанса":
						result = new ПараметрыСеансаМенеджер(this);
						return true;
					case "КритерииОтбора":
						result = new КритерииОтбораМенеджер(this);
						return true;
					case "Константы":
						result = new КонстантыМенеджер(this);
						return true;
					case "Справочники":
						result = new ОбъектыМенеджер(this, текМетаданные, ТипКоллекции.Справочник);
						return true;
					case "Документы":
						result = new ОбъектыМенеджер(this, текМетаданные, ТипКоллекции.Документ);
						return true;
					case "Перечисления":
						result = new ОбъектыМенеджер(this, текМетаданные, ТипКоллекции.Перечисление);
						return true;
					case "ПланыВидовХарактеристик":
						result = new ОбъектыМенеджер(this, текМетаданные, ТипКоллекции.ПланВидовХарактеристик);
						return true;
					case "ПланыСчетов":
						result = new ОбъектыМенеджер(this, текМетаданные, ТипКоллекции.ПланСчетов);
						return true;
					case "ПланыВидовРасчета":
						result = new ОбъектыМенеджер(this, текМетаданные, ТипКоллекции.ПланВидовРасчета);
						return true;
					case "БизнесПроцессы":
						result = new ОбъектыМенеджер(this, текМетаданные, ТипКоллекции.БизнесПроцесс);
						return true;
					case "Задачи":
						result = new ОбъектыМенеджер(this, текМетаданные, ТипКоллекции.Задача);
						return true;
					case "ЖуралыДокументов":
						result = new КоллекцияМенеджер(this, текМетаданные);
						return true;
					case "Обработки":
						result = new КоллекцияМенеджер(this, текМетаданные);
						return true;
					case "Отчеты":
						result = new КоллекцияМенеджер(this, текМетаданные);
						return true;
					case "РегистрыСведений":
						result = new КоллекцияМенеджер(this, текМетаданные);
						return true;
					case "РегистрыНакопления":
						result = new КоллекцияМенеджер(this, текМетаданные);
						return true;
					case "РегистрыБухгалтерии":
						result = new КоллекцияМенеджер(this, текМетаданные);
						return true;
					case "РегистрыРасчета":
						result = new КоллекцияМенеджер(this, текМетаданные);
						return true;
					case "Последовательности":
						result = new КоллекцияМенеджер(this, текМетаданные);
						return true;
					case "ОбщиеМодули":
						result = null;
						return false;
				}
			}
			else if (this.Метаданные.ПопыткаНайти("ОбщиеМодули." + name, out текМетаданные)) {
				result = new ОбщийМодуль(this, текМетаданные);
				return true;
			}

			result = null;
			return false;
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return TryGetMemberCommon(binder.Name, out result);
		}
		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			return TryGetMemberCommon(indexes[0].ToString(), out result);
		}

		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
			result = this.ВызватьМетод(String.Empty, binder.Name, args);
			return true;
		}
		#endregion
	}
}
