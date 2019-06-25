using ITworks.Brom.Metadata;
using ITworks.Brom.SOAP;
using ITworks.Brom.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;

namespace ITworks.Brom {
	/// <summary>
	/// Класс для формирования выборок из ссылочных коллекций 1С.
	/// </summary>
	public class Селектор : IReadOnlyList<Ссылка> {
		internal Селектор(БромКлиент клиент) {
			this.bromClient = клиент;

			this.fields = new ObservableCollection<string>();
			this.filters = new ObservableCollection<УсловиеОтбора>();
			this.sort = new ObservableCollection<Сортировка>();

			this.fields.CollectionChanged += this.OnSettingsChanged;
			this.filters.CollectionChanged += this.OnSettingsChanged;
			this.sort.CollectionChanged += this.OnSettingsChanged;

			this.fieldsAutoloadSettings = АвтозагрузкаПолейОбъектов.Ничего;
			this.АвтозагрузкаПолей.ПриИзменении += this.АвтозагрузкаПолей_ПриИзменении;

			this.items = new List<Ссылка>();

			this.isModified = false;
		}

		private void АвтозагрузкаПолей_ПриИзменении(object sender, EventArgs e) {
			this.isModified = true;
		}

		private void OnSettingsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
			this.isModified = true;
		}

		private readonly БромКлиент bromClient;
		private readonly List<Ссылка> items;
		private ТипКоллекции collectionType;
		private string collectionName;
		private МетаданныеОбъект collectionMetadata;
		private АвтозагрузкаПолейОбъектов fieldsAutoloadSettings;
		private uint limit;
		private bool isModified;

		private readonly ObservableCollection<string> fields;
		private readonly ObservableCollection<УсловиеОтбора> filters;
		private readonly ObservableCollection<Сортировка> sort;

		/// <summary>
		/// Бром-клиент, обеспечивающий взаимодействие с приложением 1С:Предприятие. 
		/// </summary>
		public БромКлиент Клиент {
			get { return this.bromClient; }
		}
		/// <summary>
		/// Тип коллекции конфигурации 1С.
		/// </summary>
		public ТипКоллекции ТипКоллекции {
			get { return this.collectionType; }
		}
		/// <summary>
		/// Имя коллекции конифгурации 1С.
		/// </summary>
		public string ИмяКоллекции {
			get { return this.collectionName; }
		}
		/// <summary>
		/// Максимальное количество элементов выборки.
		/// </summary>
		public uint Лимит {
			get { return this.limit; }
			set {
				this.limit = value;
				this.isModified = true;
			}
		}
		/// <summary>
		/// Узел метаданных коллекции, из которой происходит выборка.
		/// </summary>
		public МетаданныеОбъект МетаданныеКоллекции {
			get { return this.collectionMetadata; }
		}
		/// <summary>
		/// Текущее количество элементов в выборке.
		/// </summary>
		/// <returns></returns>
		public int Количество() {
			return this.items.Count;
		}
		/// <summary>
		/// Настройки автозагрузки полей.
		/// </summary>
		public АвтозагрузкаПолейОбъектов АвтозагрузкаПолей {
			get { return this.fieldsAutoloadSettings; }
			set {
				this.fieldsAutoloadSettings = value ?? АвтозагрузкаПолейОбъектов.Ничего;
				this.isModified = true;
			}
		}

		/// <summary>
		/// Поля контекстных данных, которые будут загружены вместе с выборкой.
		/// </summary>
		public IList<string> Поля {
			get { return this.fields; }
		}
		/// <summary>
		/// Условия отбора выборки.
		/// </summary>
		public IList<УсловиеОтбора> Отбор {
			get { return this.filters; }
		}
		/// <summary>
		/// Правила упорядочения выборки.
		/// </summary>
		public IList<Сортировка> Порядок {
			get { return this.sort; }
		}

		/// <summary>
		/// Вышружает результат выборки в масив ссылок.
		/// </summary>
		/// <returns>Возвращает массив ссылок, полученных в выборке.</returns>
		public Ссылка[] ВыгрузитьРезультат() {
			if (this.isModified) {
				this.Выполнить();
			}

			return this.items.ToArray();
		}

		/// <summary>
		/// Устанавливает коллекцию, из которой будет происходить выборка.
		/// </summary>
		/// <param name="полноеИмяКоллекции">Полное имя коллекции, например "Справочник.Номенклатура".</param>
		public void УстановитьКоллекцию(string полноеИмяКоллекции) {
			полноеИмяКоллекции = !String.IsNullOrWhiteSpace(полноеИмяКоллекции) ? полноеИмяКоллекции : throw new ArgumentException("Указано некорректное полноеИмяКоллекции коллекции.", "имяКоллекции");

			string[] фрагментыИмени = полноеИмяКоллекции.Split(".");
			if (фрагментыИмени.Length != 2) {
				throw new ArgumentException("Указано некорректное полноеИмяКоллекции коллекции.", "имяКоллекции");
			}
			ТипКоллекции типКоллекции;
			if (!Enum.TryParse<ТипКоллекции>(фрагментыИмени[0], out типКоллекции)) {
				throw new ArgumentException(String.Format("Тип коллекции \"{0}\" не определен.", фрагментыИмени[0]), "имяКоллекции");
			}
			УзелМетаданных метаданные;
			if (!this.bromClient.Метаданные.ПопыткаПолучить(полноеИмяКоллекции, out метаданные) || !(метаданные is МетаданныеОбъект)) {
				throw new ArgumentException(String.Format("Коллекция с именем \"{0}\" не определена.", полноеИмяКоллекции), "имяКоллекции");
			}

			this.collectionType = типКоллекции;
			this.collectionName = метаданные.Имя();
			this.collectionMetadata = метаданные as МетаданныеОбъект;

			this.isModified = true;
		}
		/// <summary>
		/// Устанавливает коллекцию, из которой будет происходить выборка.
		/// </summary>
		/// <param name="типКоллекции">Тип коллекции 1С.</param>
		/// <param name="имяКоллекции">Имя коллекции 1С.</param>
		public void УстановитьКоллекцию(ТипКоллекции типКоллекции, string имяКоллекции) {
			this.УстановитьКоллекцию(String.Format("{0}.{1}", типКоллекции, имяКоллекции));
		}

		/// <summary>
		/// Добавляет поля контекстных данных, которые должны быть загружены вместе с выборкой.
		/// </summary>
		/// <param name="ключиПолей">Список ключей полей данных. Ключ поля указывается в виде полного пути к данным, например "Производитель.Код".</param>
		public void ДобавитьПоля(params string[] ключиПолей) {
			this.ДобавитьПоля(ключиПолей as IEnumerable<string>);
		}
		/// <summary>
		/// Добавляет поля контекстных данных, которые должны быть загружены вместе с выборкой.
		/// </summary>
		/// <param name="ключиПолей">Список ключей полей данных. Ключ поля указывается в виде полного пути к данным, например "Производитель.Код".</param>
		public void ДобавитьПоля(IEnumerable<string> ключиПолей) {
			foreach (string ключ in ключиПолей) {
				string[] фрагментыКлючей = ключ.Split(",", StringSplitOptions.RemoveEmptyEntries);
				foreach (string фрагмент in фрагментыКлючей) {
					this.fields.Add(фрагмент.Trim());
				}
			}
			this.isModified = true;
		}

		/// <summary>
		/// Добавляет сортировку выборки по указанному полю.
		/// </summary>
		/// <param name="ключПоля">Ключ поля. Указывается в виде полного пути к данным поля, например "Производитель.Код"</param>
		/// <param name="направление">Направление сортировки.</param>
		public void ДобавитьСортировку(string ключПоля, НаправлениеСортировки направление = НаправлениеСортировки.Возрастание) {
			this.ДобавитьСортировку(new Сортировка(ключПоля, направление));
		}
		/// <summary>
		/// Добавляет одну или несколько сортировок.
		/// </summary>
		/// <param name="элементыСортировки">Список элементов, которые устанавливают правила сортировки.</param>
		public void ДобавитьСортировку(params Сортировка[] элементыСортировки) {
			this.ДобавитьСортировку(элементыСортировки as IEnumerable<Сортировка>);
		}
		/// <summary>
		/// Добавляет одну или несколько сортировок.
		/// </summary>
		/// <param name="элементыСортировки">Список элементов, которые устанавливают правила сортировки.</param>
		public void ДобавитьСортировку(IEnumerable<Сортировка> элементыСортировки) {
			foreach (Сортировка элемент in элементыСортировки) {
				this.sort.Add(элемент);
			}
			this.isModified = true;
		}	

		/// <summary>
		/// Добавляет условие отбора выборки.
		/// </summary>
		/// <param name="ключ">Клбч поля (путь к данным поля), например "Производитель.Код".</param>
		/// <param name="значение">Значение сравнения.</param>
		/// <param name="видСравнения">Вид сравнения.</param>
		public void ДобавитьОтбор(string ключ, object значение, ВидСравнения видСравнения = ВидСравнения.Равно) {
			this.ДобавитьОтбор(new УсловиеОтбора(ключ, значение, видСравнения));
		}
		/// <summary>
		///  Добавляет одно или несколько условий отбора выборки.
		/// </summary>
		/// <param name="элементыОтбора">Элементы отбора, которые описываю условия отбора выборки.</param>
		public void ДобавитьОтбор(params УсловиеОтбора[] элементыОтбора) {
			this.ДобавитьОтбор(элементыОтбора as IEnumerable<УсловиеОтбора>);
		}
		/// <summary>
		/// Добавляет один или несколько условий отбора выборки.
		/// </summary>
		/// <param name="элементыОтбора">Элементы отбора, которые описываю условия отбора выборки.</param>
		public void ДобавитьОтбор(IEnumerable<УсловиеОтбора> элементыОтбора) {
			foreach (УсловиеОтбора элемент in элементыОтбора) {
				this.filters.Add(элемент);
			}
			this.isModified = true;
		}

		/// <summary>
		/// Получает данные выборки с учетом всех установленных настроек.
		/// </summary>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Выполнить() {
			Task<Селектор> task = this.ВыполнитьАсинх();
			task.Wait();
			return task.Result;
		}
		/// <summary>
		/// Получает данные выборки асинхронно с учетом всех установленных настроек.
		/// </summary>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public async Task<Селектор> ВыполнитьАсинх() {
			if (this.collectionMetadata == null) {
				throw new Exception("Не установлена коллекция для получения выборки.");
			}

			GetObjectList_Settings settings = new GetObjectList_Settings();
			settings.AddSkippedProperties = true;
			settings.AddSkippedPropertiesSpecified = true;

			settings.PropertiesHierarchyType = "Hierarchy";

			settings.FieldAutoinclusion = new RequestFieldAutoinclusionSettings();
			settings.FieldAutoinclusion.DefaultFields = this.АвтозагрузкаПолей.ЗагружатьСтандартныеРеквизиты;
			settings.FieldAutoinclusion.DefaultFieldsSpecified = this.АвтозагрузкаПолей.ЗагружатьСтандартныеРеквизиты;
			settings.FieldAutoinclusion.CustomFields = this.АвтозагрузкаПолей.ЗагружатьПользовательскиеРеквизиты;
			settings.FieldAutoinclusion.CustomFieldsSpecified = this.АвтозагрузкаПолей.ЗагружатьПользовательскиеРеквизиты;
			settings.FieldAutoinclusion.Tables = this.АвтозагрузкаПолей.ЗагружатьТабличныеЧасти;
			settings.FieldAutoinclusion.TablesSpecified = this.АвтозагрузкаПолей.ЗагружатьТабличныеЧасти;

			if (this.limit > 0) {
				settings.Limit = this.limit;
				settings.LimitSpecified = true;
			}

			settings.Field = new RequestField[this.Поля.Count];
			int i = 0;
			foreach (string fieldName in this.Поля) {
				RequestField field = new RequestField();
				field.Key = fieldName;
				settings.Field[i] = field;
				i++;
			}

			settings.Filter = new RequestFilter[this.Отбор.Count];
			for (i = 0; i < this.Отбор.Count; i++) {
				RequestFilter filter = new RequestFilter();
				filter.Key = this.Отбор[i].Ключ;
				filter.Value = ValueBase.From(this.Отбор[i].Значение);
				filter.ComparisonType = this.Отбор[i].ВидСравнения.ToString();
				settings.Filter[i] = filter;
			}

			settings.Sort = new RequestSort[this.Порядок.Count];
			for (i = 0; i < this.Порядок.Count; i++) {
				RequestSort field = new RequestSort();
				field.Key = this.Порядок[i].Ключ;
				field.Direction = this.Порядок[i].Направление == НаправлениеСортировки.Убывание ? "Убыв" : "Возр";
				settings.Sort[i] = field;
			}

			Task<GetObjectListResponse> task = this.bromClient.SoapКлиент.GetObjectListAsync(this.ТипКоллекции.ToString(), this.ИмяКоллекции, settings);

			ValueArray objectList = (await task).@return;

			this.items.Clear();
			if (objectList.Item != null) {
				foreach (ValueBase item in objectList.Item) {
					this.items.Add(item.GetValue(this.Клиент) as Ссылка);
				}
			}

			this.isModified = false;

			return this;
		}
		
		/// <summary>
		/// Сбрасыввает все настройки выборки.
		/// </summary>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Сбросить() {
			this.items.Clear();
			this.fields.Clear();
			this.filters.Clear();
			this.sort.Clear();

			this.limit = 0;

			this.collectionMetadata = null;
			this.collectionName = null;

			this.isModified = false;

			return this;
		}

		#region Request like methods
		/// <summary>
		/// Указывает один или несколько полей контекстных данных, которые должны быть загружены вместе с выборкой.
		/// </summary>
		/// <param name="ключиПолей">Список ключей полей данных. Ключ поля указывается в виде полного пути к данным, например "Производитель.Код".</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Выбрать(params string[] ключиПолей) {
			this.ДобавитьПоля(ключиПолей as IEnumerable<string>);
			return this;
		}
		/// <summary>
		/// Указывает поля контекстных данных, которые должны быть загружены вместе с выборкой.
		/// </summary>
		/// <param name="ключиПолей">Список ключей полей данных. Ключ поля указывается в виде полного пути к данным, например "Производитель.Код".</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Выбрать(IEnumerable<string> ключиПолей) {
			this.ДобавитьПоля(ключиПолей);
			return this;
		}

		/// <summary>
		/// Устанавливает максимальное количество элементов в выборке.
		/// </summary>
		/// <param name="лимит">Максимальное количество элементов в выборке.</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Первые(uint лимит) {
			this.Лимит = лимит;
			return this;
		}

		/// <summary>
		/// Устанавливает коллекцию, из которой будет происходить выборка.
		/// </summary>
		/// <param name="полноеИмяКоллекции">Полное имя коллекции, например "Справочник.Номенклатура".</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Из(string полноеИмяКоллекции) {
			this.УстановитьКоллекцию(полноеИмяКоллекции);
			return this;
		}
		/// <summary>
		/// Устанавливает коллекцию, из которой будет происходить выборка.
		/// </summary>
		/// <param name="типКоллекции">Тип коллекции 1С.</param>
		/// <param name="имяКоллекции">Имя коллекции 1С.</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Из(ТипКоллекции типКоллекции, string имяКоллекции) {
			this.УстановитьКоллекцию(типКоллекции, имяКоллекции);
			return this;
		}

		/// <summary>
		/// Добавляет условие отбора выборки.
		/// </summary>
		/// <param name="ключ">Клбч поля (путь к данным поля), например "Производитель.Код".</param>
		/// <param name="значение">Значение сравнения.</param>
		/// <param name="видСравнения">Вид сравнения.</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Где(string ключ, object значение, ВидСравнения видСравнения = ВидСравнения.Равно) {
			this.ДобавитьОтбор(ключ, значение, видСравнения);
			return this;
		}
		/// <summary>
		///  Добавляет одно или несколько условий отбора выборки.
		/// </summary>
		/// <param name="элементыОтбора">Элементы отбора, которые описываю условия отбора выборки.</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Где(params УсловиеОтбора[] элементыОтбора) {
			this.ДобавитьОтбор(элементыОтбора);
			return this;
		}
		/// <summary>
		///  Добавляет условия отбора выборки.
		/// </summary>
		/// <param name="элементыОтбора">Элементы отбора, которые описываю условия отбора выборки.</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Где(IEnumerable<УсловиеОтбора> элементыОтбора) {
			this.ДобавитьОтбор(элементыОтбора);
			return this;
		}

		/// <summary>
		/// Добавляет сортировку выборки по указанному полю.
		/// </summary>
		/// <param name="ключПоля">Ключ поля. Указывается в виде полного пути к данным поля, например "Производитель.Код"</param>
		/// <param name="направление">Направление сортировки.</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Упорядочить(string ключ, НаправлениеСортировки направление = НаправлениеСортировки.Возрастание) {
			this.ДобавитьСортировку(ключ, направление);
			return this;
		}
		/// <summary>
		/// Добавляет одну или несколько сортировок.
		/// </summary>
		/// <param name="элементыСортировки">Список элементов, которые устанавливают правила сортировки.</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Упорядочить(params Сортировка[] элементыСортировки) {
			this.ДобавитьСортировку(элементыСортировки);
			return this;
		}
		/// <summary>
		/// Добавляет одну или несколько сортировок.
		/// </summary>
		/// <param name="элементыСортировки">Список элементов, которые устанавливают правила сортировки.</param>
		/// <returns>Метод возвращает ссылку на исходный селектор.</returns>
		public Селектор Упорядочить(IEnumerable<Сортировка> элементыСортировки) {
			this.ДобавитьСортировку(элементыСортировки);
			return this;
		}
		#endregion

		#region IReadOnlyList
		/// <summary>
		/// Current elements quantity.
		/// </summary>
		public int Count => this.items.Count;

		/// <summary>
		/// Get element by index.
		/// </summary>
		/// <param name="index">Index of the element.</param>
		/// <returns></returns>
		public Ссылка this[int index] => this.items[index];

		/// <summary>
		/// Return collection Enumerator.
		/// </summary>
		/// <returns>Return collection Enumerator.</returns>
		public IEnumerator<Ссылка> GetEnumerator() {
			if (this.isModified) {
				this.Выполнить();
			}

			return ((IReadOnlyList<Ссылка>)this.items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			if (this.isModified) {
				this.Выполнить();
			}

			return ((IReadOnlyList<Ссылка>)this.items).GetEnumerator();
		}
		#endregion
	}
}
