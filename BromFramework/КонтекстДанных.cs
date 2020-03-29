using ITworks.Brom.Metadata;
using ITworks.Brom.SOAP;
using ITworks.Brom.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITworks.Brom {
	/// <summary>
	/// Мнеджер хранения данных объектов базы данных 1С.
	/// </summary>
	public class КонтекстДанных {
		/// <summary>
		/// Базовый конструктор.
		/// </summary>
		/// <param name="клиент">Клиент для подключения к Бром.</param>
		internal КонтекстДанных(БромКлиент клиент) {
			this.bromClient = клиент ?? throw new ArgumentNullException("клиент");
			this.data = new Dictionary<Guid, Dictionary<string, object>>();

			this.references = new Dictionary<Guid, WeakReference<Ссылка>>();
		}

		private readonly БромКлиент bromClient;
		private readonly Dictionary<Guid, Dictionary<string, object>> data;
		private readonly Dictionary<Guid, WeakReference<Ссылка>> references;

		/// <summary>
		/// Клиент Бром.
		/// </summary>
		public БромКлиент Клиент {
			get { return this.bromClient; }
		}

		private Dictionary<string, object> ПолучитьУзелДанныхОбъекта(ОбъектСсылка ссылка) {
			Guid идСсылки = КонтекстДанных.ПолучитьОбобщенныйИдентификаторСсылки(ссылка);

			Dictionary<string, object> node = null;
			if (!this.data.TryGetValue(идСсылки, out node)) {
				node = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
				this.data.Add(идСсылки, node);
			}

			return node;
		}
		private void УдалитьУзелДанныхОбъекта(ОбъектСсылка ссылка) {
			Guid идСсылки = КонтекстДанных.ПолучитьОбобщенныйИдентификаторСсылки(ссылка);

			this.data.Remove(идСсылки);
		}
		private void ИнициализироватьДанныеОбъекта(ОбъектСсылка ссылка) {
			Dictionary<string, object> данныеОбъекта = ПолучитьУзелДанныхОбъекта(ссылка);
			данныеОбъекта.Clear();

			УзелМетаданных реквизиты = ссылка.Метаданные().НайтиПодчиненный("Реквизиты");
			foreach (var ключЗначение in реквизиты) {
				данныеОбъекта[ключЗначение.Key] = null;
			}
			данныеОбъекта["#"] = null;
		}

		private ТабличнаяЧасть ПолучитьТабличнуюЧасть(ОбъектСсылка ссылка, МетаданныеТабличнаяЧасть метаданные) {
			Dictionary<string, object> данныеОбъекта = this.ПолучитьУзелДанныхОбъекта(ссылка);
			object таблЧасть;
			if (!данныеОбъекта.TryGetValue(метаданные.Имя(), out таблЧасть) || !(таблЧасть is ТабличнаяЧасть)) {
				таблЧасть = new ТабличнаяЧасть(метаданные);
				this.УстановитьЗначениеПоляОбъекта(ссылка, метаданные.Имя(), таблЧасть);
			}
			return таблЧасть as ТабличнаяЧасть;
		}

		internal void УстановитьЗначениеПоляОбъекта(ОбъектСсылка ссылка, string имяПоля, object значение) {
			Dictionary<string, object> данныеОбъекта = this.ПолучитьУзелДанныхОбъекта(ссылка);
			данныеОбъекта[имяПоля] = значение;
		}
		internal void УстановитьПредставлениеОбъекта(ОбъектСсылка ссылка, string представление) {
			if (представление == null) {
				return;
			}

			Dictionary<string, object> данныеОбъекта = ПолучитьУзелДанныхОбъекта(ссылка);
			данныеОбъекта["#"] = представление;
		}

		internal void УстановитьЗначенияИзСвойствSOAP(ОбъектСсылка ссылка, ValueBase[] properties) {
			if (properties == null) {
				return;
			}

			УзелМетаданных реквизиты = ссылка.Метаданные().НайтиПодчиненный("Реквизиты");
			УзелМетаданных таблЧасти = ссылка.Метаданные().НайтиПодчиненный("ТабличныеЧасти");

			foreach (ValueBase property in properties) {
				УзелМетаданных текМета;
				if (реквизиты.ПопыткаНайтиПодчиненный(property.Name, out текМета) ) {
					object значение = property.GetValue(this.Клиент);
					this.УстановитьЗначениеПоляОбъекта(ссылка, текМета.Имя(), значение);
				}
				else if (таблЧасти.ПопыткаНайтиПодчиненный(property.Name, out текМета)) {
					object значение = property.GetValue(this.Клиент);
					if (значение is ТаблицаЗначений) {
						ТабличнаяЧасть таблЧасть = this.ПолучитьТабличнуюЧасть(ссылка, (МетаданныеТабличнаяЧасть)текМета);
						таблЧасть.ЗагрузитьДанные(значение as ТаблицаЗначений);
					}
				}
			}
		}

		internal void УничтожитьСсылку(Ссылка ссылка) {
			Guid идСсылки = КонтекстДанных.ПолучитьОбобщенныйИдентификаторСсылки(ссылка);

			if (ссылка is ОбъектСсылка) {
				this.ОчиститьДанныеОбъекта(ссылка as ОбъектСсылка);
			}

			this.references.Remove(идСсылки);
		}

		/// <summary>
		/// Получает значение свойства объекта по ссылке на объект и имени свойства.
		/// </summary>
		/// <param name="ссылка">Ссылка на объект.</param>
		/// <param name="имяПоля">Имя поля.</param>
		/// <param name="значение">Значение поля.</param>
		/// <returns>Возвращает true, Если значение установлено, в противном случае - false.</returns>
		public bool ПопыткаПолучитьЗначение(ОбъектСсылка ссылка, string имяПоля, out object значение) {
			ссылка = ссылка ?? throw new ArgumentNullException("ссылка");

			if (имяПоля.Equals("Ссылка", StringComparison.OrdinalIgnoreCase)) {
				значение = ссылка;
				return true;
			}

			УзелМетаданных реквизит;
			if (((dynamic)ссылка.Метаданные()).Реквизиты.ПопыткаНайтиПодчиненный(имяПоля, out реквизит)) {
				if (ссылка.Пустая()) {
					значение = null;
					return true;
				}

				Dictionary<string, object> данныеОбъекта = this.ПолучитьУзелДанныхОбъекта(ссылка);
				if (данныеОбъекта.TryGetValue(имяПоля, out значение)) {
					return true;
				}

				this.ЗагрузитьДанныеОбъекта(ссылка);
				return ПопыткаПолучитьЗначение(ссылка, имяПоля, out значение);
			}

			if (((dynamic)ссылка.Метаданные()).ТабличныеЧасти.ПопыткаНайти(имяПоля, out реквизит)) {
				if (ссылка.Пустая()) {
					значение = this.ПолучитьТабличнуюЧасть(ссылка, (МетаданныеТабличнаяЧасть)реквизит);
					return true;
				}

				Dictionary<string, object> данныеОбъекта = this.ПолучитьУзелДанныхОбъекта(ссылка);
				object таблЧасть;
				if (данныеОбъекта.TryGetValue(имяПоля, out таблЧасть)) {
					if (!(таблЧасть is ТабличнаяЧасть)) {
						таблЧасть = this.ПолучитьТабличнуюЧасть(ссылка, (МетаданныеТабличнаяЧасть)реквизит);
						данныеОбъекта[имяПоля] = таблЧасть;
					}

					значение = таблЧасть;
					return true;
				}

				this.ЗагрузитьДанныеОбъекта(ссылка);
				return this.ПопыткаПолучитьЗначение(ссылка, имяПоля, out значение);
			}


			значение = null;
			return false;
		}
		/// <summary>
		/// Получает текстовое представление объекта по ссылке на объект.
		/// </summary>
		/// <param name="ссылка">Ссылка на объект.</param>
		/// <returns>Возвращает текстовое представление объекта.</returns>
		public string ПолучитьПредставлениеОбъекта(ОбъектСсылка ссылка) {
			ссылка = ссылка ?? throw new ArgumentNullException("ссылка");

			if (ссылка.Пустая()) {
				return "";
			}

			object представление = null;
			Dictionary<string, object> данныеОбъекта = this.ПолучитьУзелДанныхОбъекта(ссылка);
			if (данныеОбъекта.TryGetValue("#", out представление)) {
				return (string)представление;
			}

			this.ЗагрузитьДанныеОбъекта(ссылка);

			return this.ПолучитьПредставлениеОбъекта(ссылка);
		}

		/// <summary>
		/// Удаляет данные объекта из контекста.
		/// </summary>
		/// <param name="ссылка">Ссылка на объект.</param>
		public void ОчиститьДанныеОбъекта(ОбъектСсылка ссылка) {
			this.УдалитьУзелДанныхОбъекта(ссылка);
		}
		/// <summary>
		/// Загружает данные объекта с сервера.
		/// </summary>
		/// <param name="ссылка">Ссылка на объект.</param>
		public void ЗагрузитьДанныеОбъекта(ОбъектСсылка ссылка) {
			Task task = this.ЗагрузитьДанныеОбъектаАсинх(ссылка);
			task.Wait();
		}
		/// <summary>
		/// Асинхронно загружает данные объекта с сервера.
		/// </summary>
		/// <param name="ссылка">Ссылка на объект.</param>
		public async Task ЗагрузитьДанныеОбъектаАсинх(ОбъектСсылка ссылка) {
			GetObject_Settings settings = new GetObject_Settings();
			settings.AddSkippedProperties = true;

			settings.FieldAutoinclusion = new RequestFieldAutoinclusionSettings();
			settings.FieldAutoinclusion.DefaultFields = true;
			settings.FieldAutoinclusion.DefaultFieldsSpecified = true;
			settings.FieldAutoinclusion.CustomFields = true;
			settings.FieldAutoinclusion.CustomFieldsSpecified = true;
			settings.FieldAutoinclusion.Tables = true;
			settings.FieldAutoinclusion.TablesSpecified = true;

			Task<GetObjectResponse> task = this.bromClient.SoapКлиент.GetObjectAsync((ValueObjectRef)ValueBase.From(ссылка), settings);

			ValueObjectRef refSoap = (await task).@return as ValueObjectRef;

			this.ИнициализироватьДанныеОбъекта(ссылка);

			this.УстановитьПредставлениеОбъекта(ссылка, refSoap.Presentation);
			this.УстановитьЗначенияИзСвойствSOAP(ссылка, refSoap.Property);
		}

		/// <summary>
		/// Создает ссылку на объект.
		/// </summary>
		/// <param name="полноеИмяТипа">Полное имя типа объекта, например "Справочник.Номенклатура".</param>
		/// <param name="указатель">Уникальный идентификатор ссылки.</param>
		/// <returns>Возвращает ссылку на объект.</returns>
		public ОбъектСсылка ПолучитьОбъектСсылку(string полноеИмяТипа, Guid указатель) {
			УзелМетаданных узелМетаданных;
			if(!this.Клиент.Метаданные.ПопыткаПолучить(полноеИмяТипа, out узелМетаданных)) {
				throw new ArgumentException(String.Format("Ошибка при получении ссылки на объект. Не удалось обнаружить объект метаданных \"{0}\".", полноеИмяТипа), "полноеИмяТипа");
			}

			Guid идСсылки = КонтекстДанных.ПолучитьОбобщенныйИдентификаторСсылки(полноеИмяТипа, указатель.ToString());
			Ссылка ссылка = null;

			WeakReference<Ссылка> слабСсылка = null;
			if (this.references.TryGetValue(идСсылки, out слабСсылка) && слабСсылка.TryGetTarget(out ссылка)) {
				return (ОбъектСсылка)ссылка;
			}

			switch (((МетаданныеОбъект)узелМетаданных).ТипКоллекции()) {
				case ТипКоллекции.Справочник:
					ссылка = new СправочникСсылка(this.bromClient, узелМетаданных.Имя(), указатель);
					break;
				case ТипКоллекции.Документ:
					ссылка = new ДокументСсылка(this.bromClient, узелМетаданных.Имя(), указатель);
					break;
				case ТипКоллекции.ПланВидовХарактеристик:
					ссылка = new ПланВидовХарактеристикСсылка(this.bromClient, узелМетаданных.Имя(), указатель);
					break;
				case ТипКоллекции.ПланСчетов:
					ссылка = new ПланСчетовСсылка(this.bromClient, узелМетаданных.Имя(), указатель);
					break;
				case ТипКоллекции.ПланВидовРасчета:
					ссылка = new ПланВидовРасчетаСсылка(this.bromClient, узелМетаданных.Имя(), указатель);
					break;
				case ТипКоллекции.Задача:
					ссылка = new ЗадачаСсылка(this.bromClient, узелМетаданных.Имя(), указатель);
					break;
				case ТипКоллекции.БизнесПроцесс:
					ссылка = new БизнесПроцессСсылка(this.bromClient, узелМетаданных.Имя(), указатель);
					break;
				default:
					throw new Exception("Указан неверный тип коллекции.");
			}

			this.references[идСсылки] = new WeakReference<Ссылка>(ссылка);
			return (ОбъектСсылка)ссылка;
		}
		/// <summary>
		/// Создает ссылку на элемент перечисления.
		/// </summary>
		/// <param name="полноеИмяТипа">Полное имя типа объекта, например "Перечисление.СтавкиНДС".</param>
		/// <param name="указатель">Имя (идетификатор) элемента.</param>
		/// <param name="синоним">Синоним элемента.</param>
		/// <returns>Возвращает ссылку на элемент перечисления.</returns>
		public ПеречислениеСсылка ПолучитьПеречислениеСсылку(string полноеИмяТипа, string указатель, string синоним = "") {
			УзелМетаданных узелМетаданных;
			if (!this.Клиент.Метаданные.ПопыткаПолучить(полноеИмяТипа, out узелМетаданных)) {
				throw new ArgumentException(String.Format("Ошибка при получении ссылки на объект. Не удалось обнаружить объект метаданных \"{0}\".", полноеИмяТипа), "полноеИмяТипа");
			}
			if (((МетаданныеОбъект)узелМетаданных).ТипКоллекции() != ТипКоллекции.Перечисление) {
				throw new Exception("Указан неверный тип коллекции.");
			}

			Guid идСсылки = КонтекстДанных.ПолучитьОбобщенныйИдентификаторСсылки(полноеИмяТипа, указатель);
			Ссылка ссылка = null;
			WeakReference<Ссылка> слабСсылка;
			if (this.references.TryGetValue(идСсылки, out слабСсылка) && слабСсылка.TryGetTarget(out ссылка)) {
				return (ПеречислениеСсылка)ссылка;
			}

			ссылка = new ПеречислениеСсылка(this.bromClient, узелМетаданных.Имя(), указатель, синоним);

			this.references[идСсылки] = new WeakReference<Ссылка>(ссылка);
			return (ПеречислениеСсылка)ссылка;
		}

		private static Guid ПолучитьОбобщенныйИдентификаторСсылки(string полноеИмяТипа, string указатель) {
			string representation = (полноеИмяТипа + "#" + указатель).ToLower();
			byte[] stringbytes = Encoding.UTF8.GetBytes(representation);
			byte[] hashedBytes = new System.Security.Cryptography
				.SHA1CryptoServiceProvider()
				.ComputeHash(stringbytes);
			System.Array.Resize(ref hashedBytes, 16);
			return new Guid(hashedBytes);
		}
		private static Guid ПолучитьОбобщенныйИдентификаторСсылки(Ссылка ссылка) {
			if (ссылка is ОбъектСсылка) {
				ОбъектСсылка текСсылка = ссылка as ОбъектСсылка;
				return ПолучитьОбобщенныйИдентификаторСсылки(текСсылка.ПолноеИмяТипа(), текСсылка.УникальныйИдентификатор().ToString());
			}
			else {
				ПеречислениеСсылка текСсылка = ссылка as ПеречислениеСсылка;
				return ПолучитьОбобщенныйИдентификаторСсылки(текСсылка.ПолноеИмяТипа(), текСсылка.Имя);
			}
		}
	}
}
