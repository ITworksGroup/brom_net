using ITworks.Brom.Metadata;
using ITworks.Brom.SOAP;
using ITworks.Brom.Types;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace ITworks.Brom {
	/// <summary>
	/// Контекст объекта базы данных 1С.
	/// </summary>
	public abstract class КонтекстОбъекта : DynamicObject {
		/// <summary>
		/// Базовый конструктор на основании ссылки на объект.
		/// </summary>
		/// <param name="ссылка"></param>
		internal КонтекстОбъекта(ОбъектСсылка ссылка) {
			this.reference = ссылка;
			this.data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
			this.modifiedFields = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			this.additionalProperties = new Структура();

			this.isExchangeLoadMode = false;
		}

		private ОбъектСсылка reference;
		private readonly Dictionary<string, object> data;
		private readonly Структура additionalProperties;
		private readonly HashSet<string> modifiedFields;

		private bool isExchangeLoadMode;

		private ТабличнаяЧастьКонтекст ДобавитьТабличнуюЧасть(МетаданныеТабличнаяЧасть метаданные) {
			object таблЧасть;
			if (!this.data.TryGetValue(метаданные.Имя(), out таблЧасть) || таблЧасть == null) { 
				таблЧасть = new ТабличнаяЧастьКонтекст(метаданные as МетаданныеТабличнаяЧасть);
				this.data[метаданные.Имя()] = таблЧасть;
				(таблЧасть as ТабличнаяЧастьКонтекст).OnModifiedChanged += this.TableSection_OnModifiedChanged;
			}

			return таблЧасть as ТабличнаяЧастьКонтекст;
		}

		private void TableSection_OnModifiedChanged(object sender, string e) {
			if (!this.modifiedFields.Contains(e)) {
				this.modifiedFields.Add(e);
			}
		}

		internal void УстановитьЗначенияИзСвойствSOAP(ValueBase[] properties) {
			if (properties == null) {
				return;
			}

			УзелМетаданных реквизиты = this.reference.Метаданные().Найти("Реквизиты");
			foreach (ValueBase property in properties) {
				УзелМетаданных реквизит;
				if (реквизиты.ПопыткаНайти(property.Name, out реквизит)) {
					object значение = property.GetValue(this.Клиент());
					this.data[реквизит.Имя()] = значение;
				}
			}

			УзелМетаданных таблЧасти = this.reference.Метаданные().Найти("ТабличныеЧасти");
			foreach (ValueBase property in properties) {
				УзелМетаданных таблЧастьМета;
				if (таблЧасти.ПопыткаНайти(property.Name, out таблЧастьМета)) {
					object значение = property.GetValue(this.Клиент());
					ТабличнаяЧастьКонтекст табличнаяЧасть = this.ДобавитьТабличнуюЧасть(таблЧастьМета as МетаданныеТабличнаяЧасть);
					if (значение is ТаблицаЗначений) {
						табличнаяЧасть.ЗагрузитьДанные((ТаблицаЗначений)значение);
					}
					else {
						табличнаяЧасть.ЗагрузитьДанные(new ТаблицаЗначений());
					}
					табличнаяЧасть.SetIsModified(false);
				}
			}
		}

		/// <summary>
		/// Записывает данные объекта на сервере.
		/// </summary>
		/// <param name="режимЗаписиДокумента">Режим записи документа (только для документов).</param>
		/// <param name="режимПроведенияДокумента">Режим проведения документа (только для документов).</param>
		protected void ЗаписатьДанные(РежимЗаписиДокумента режимЗаписиДокумента = РежимЗаписиДокумента.Запись, РежимПроведенияДокумента режимПроведенияДокумента = РежимПроведенияДокумента.Неоперативный) {
			Task task = this.ЗаписатьДанныеАсинх(режимЗаписиДокумента, режимПроведенияДокумента);
			task.Wait();
		}
		/// <summary>
		/// Асинхронно записывает данные объекта на сервере.
		/// </summary>
		/// <param name="режимЗаписиДокумента">Режим записи документа (только для документов).</param>
		/// <param name="режимПроведенияДокумента">Режим проведения документа (только для документов).</param>
		/// <returns></returns>
		protected async Task ЗаписатьДанныеАсинх(РежимЗаписиДокумента режимЗаписиДокумента = РежимЗаписиДокумента.Запись, РежимПроведенияДокумента режимПроведенияДокумента = РежимПроведенияДокумента.Неоперативный) {
			ValueObjectRef tempObject = new ValueObjectRef(this.reference);
			tempObject.Property = new ValueBase[this.modifiedFields.Count];
			int i = 0;
			foreach (string key in this.modifiedFields) {
				object value = null;
				this.data.TryGetValue(key, out value);
				ValueBase property = ValueBase.From(value);
				property.Name = key;
				tempObject.Property[i] = property;
				i++;
			}

			PostObject_Settings settings = new PostObject_Settings(
				this.ДополнительныеСвойства,
				режимЗаписиДокумента,
				режимПроведенияДокумента,
				this.isExchangeLoadMode
			);

			Task<PostObjectResponse> task = this.Клиент().SoapКлиент.PostObjectAsync(tempObject, settings);

			ValueObjectRef returnObject = (await task).@return;
			ОбъектСсылка ссылка = returnObject.GetValue(this.Клиент()) as ОбъектСсылка;

			this.УстановитьСсылку(ссылка);

			this.УстановитьЗначенияИзСвойствSOAP(returnObject.Property);

			this.modifiedFields.Clear();
		}

		/// <summary>
		/// Дополнительные свойства объекта, передаваемые на сервер при записи.
		/// </summary>
		public Структура ДополнительныеСвойства {
			get { return this.additionalProperties; }
		}
		/// <summary>
		/// Флаг режима загрузки при записи объекта (Обмен.Загрузка = Истина/Ложь).
		/// </summary>
		public bool РежимЗагрузки {
			get { return this.isExchangeLoadMode; }
			set { this.isExchangeLoadMode = value; }
		}

		/// <summary>
		/// Клиент Бром.
		/// </summary>
		/// <returns>Клиент Бром.</returns>
		public БромКлиент Клиент() {
			return this.reference.Клиент();
		}
		/// <summary>
		/// Метаданные удаленной конфигурации приложения 1С.
		/// </summary>
		/// <returns>Метаданные удаленной конфигурации приложения 1С.</returns>
		public МетаданныеОбъект Метаданные() {
			return this.reference.Метаданные() as МетаданныеОбъект;
		}
		/// <summary>
		/// Признак того, что объект является новым и еще не существет в базе данных 1С.
		/// </summary>
		/// <returns>Возвращает true, если ссылка на объект пустая.</returns>
		public bool ЭтоНовый() {
			return this.reference.Пустая();
		}

		/// <summary>
		/// Устанавливает ссылку на объект базы данных 1С.
		/// </summary>
		/// <param name="ссылка"></param>
		public void УстановитьСсылку(ОбъектСсылка ссылка) {
			if (ссылка == this.reference) {
				return;
			}

			if (ссылка.ТипКоллекции() != this.reference.ТипКоллекции() || ссылка.ИмяКоллекции() != this.reference.ИмяКоллекции()) {
				throw new ArgumentException(String.Format("Тип аргумента \"ссылка\" не соответствует требуемому типу \"{0}\".", this.reference.ПолноеИмяТипа()), "ссылка");
			}

			this.reference = ссылка;
		}
		
		/// <summary>
		/// Устанавливает или снимает пометку удаления.
		/// </summary>
		/// <param name="значение"></param>
		public void УстановитьПометкуУдаления(bool значение) {
			((dynamic)this).ПометкаУдаления = значение;
		}

		public override string ToString() {
			return String.Format("{0}.{1}", base.ToString(), this.reference.ИмяКоллекции());
		}

		/// <summary>
		/// Загружает данные объекта с сервера.
		/// </summary>
		public void ЗагрузитьДанные() {
			Task task = this.ЗагрузитьДанныеАсинх();
			task.Wait();
		}
		/// <summary>
		/// Асинхронно загружает данные объекта с сервера.
		/// </summary>
		public async Task ЗагрузитьДанныеАсинх() {
			GetObject_Settings settings = new GetObject_Settings();

			settings.FieldAutoinclusion = new RequestFieldAutoinclusionSettings();
			settings.FieldAutoinclusion.DefaultFields = true;
			settings.FieldAutoinclusion.DefaultFieldsSpecified = true;
			settings.FieldAutoinclusion.CustomFields = true;
			settings.FieldAutoinclusion.CustomFieldsSpecified = true;
			settings.FieldAutoinclusion.Tables = true;
			settings.FieldAutoinclusion.TablesSpecified = true;

			Task<GetObjectResponse> task = this.Клиент().SoapКлиент.GetObjectAsync(new ValueObjectRef(this.reference), settings);

			ValueObjectRef refSoap = (await task).@return as ValueObjectRef;

			this.Клиент().Контекст().УстановитьПредставлениеОбъекта(this.reference, refSoap.Presentation);
			this.Клиент().Контекст().УстановитьЗначенияИзСвойствSOAP(this.reference, refSoap.Property);

			this.УстановитьЗначенияИзСвойствSOAP(refSoap.Property);

			this.modifiedFields.Clear();
		}

		/// <summary>
		/// Записывает данные на сервере.
		/// </summary>
		public virtual void Записать() {
			this.ЗаписатьДанные();
		}
		/// <summary>
		/// Асинхронно записывает данные на сервере.
		/// </summary>
		public virtual Task ЗаписатьАсинх() {
			return this.ЗаписатьДанныеАсинх();
		}

		/// <summary>
		/// Удаляет объект из базы данных.
		/// </summary>
		public virtual void Удалить() {
			if (this.ЭтоНовый()) {
				throw new Exception("Не возможно удалить объект, который является новым.");
			}

			Task<DeleteObjectResponse> task = this.Клиент().SoapКлиент.DeleteObjectAsync(new ValueObjectRef(this.reference));
			task.Wait();

			this.Клиент().Контекст().ОчиститьДанныеОбъекта(this.reference);
		}

		internal static КонтекстОбъекта ПолучитьКонтекстОбъекта(ОбъектСсылка ссылка) {
			if (ссылка == null) {
				throw new ArgumentNullException("ссылка");
			}

			switch (ссылка.ТипКоллекции()) {
				case ТипКоллекции.Справочник:
					return new СправочникОбъект(ссылка as СправочникСсылка);
				case ТипКоллекции.Документ:
					return new ДокументОбъект(ссылка as ДокументСсылка);
				case ТипКоллекции.ПланВидовХарактеристик:
					return new ПланВидовХарактеристикОбъект(ссылка as ПланВидовХарактеристикСсылка);
				case ТипКоллекции.ПланСчетов:
					return new ПланСчетовОбъект(ссылка as ПланСчетовСсылка);
				case ТипКоллекции.ПланВидовРасчета:
					return new ПланВидовРасчетаОбъект(ссылка as ПланВидовРасчетаСсылка);
				case ТипКоллекции.БизнесПроцесс:
					return new БизнесПроцессОбъект(ссылка as БизнесПроцессСсылка);
				case ТипКоллекции.Задача:
					return new ЗадачаОбъект(ссылка as ЗадачаСсылка);
				default:
					throw new ArgumentException();
			}
		}

		#region DynamicObject
		private bool TryGetMemberCommon(string fieldName, out object result) {
			if (fieldName.Equals("Ссылка", StringComparison.OrdinalIgnoreCase)) {
				result = this.reference;
				return true;
			}

			dynamic метаданные = this.reference.Метаданные();
			УзелМетаданных текМета;
			if (метаданные.Реквизиты.ПопыткаНайти(fieldName, out текМета)) {
				this.data.TryGetValue(текМета.Имя(), out result);
				return true;
			}
			else if (метаданные.ТабличныеЧасти.ПопыткаНайти(fieldName, out текМета)) {
				result = this.ДобавитьТабличнуюЧасть(текМета as МетаданныеТабличнаяЧасть);
				return true;
			}


			result = null;
			return false;
		}
		public bool TrySetMemberCommon(string fieldName, object value) {
			if (fieldName.Equals("Ссылка", StringComparison.OrdinalIgnoreCase)) {
				throw new MemberAccessException("Реквизит \"Ссылка\" доступен только для чтения.");
			}

			dynamic метаданные = this.reference.Метаданные();
			УзелМетаданных реквизит;
			if (метаданные.ТабличныеЧасти.ПопыткаНайти(fieldName, out реквизит)) {
				throw new MemberAccessException(String.Format("Реквизит \"{0}\" доступен только для чтения.", реквизит.Имя()));
			}

			if (метаданные.Реквизиты.ПопыткаНайти(fieldName, out реквизит)) {
				this.data[реквизит.Имя()] = value;
				if (!this.modifiedFields.Contains(реквизит.Имя())) {
					this.modifiedFields.Add(реквизит.Имя());
				}
				return true;
			}

			return false;
		}

		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			return this.TryGetMemberCommon((string)indexes[0], out result);
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return this.TryGetMemberCommon(binder.Name, out result);
		}

		public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value) {
			return this.TrySetMemberCommon((string)indexes[0], value);
		}
		public override bool TrySetMember(SetMemberBinder binder, object value) {
			return this.TrySetMemberCommon(binder.Name, value);
		}

		public override IEnumerable<string> GetDynamicMemberNames() {
			return this.reference.GetDynamicMemberNames();
		}
		#endregion
	}
}
