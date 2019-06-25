using ITworks.Brom.SOAP;
using ITworks.Brom.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITworks.Brom.Metadata {
	public class МетаданныеКонфигурация : УзелМетаданных {
		internal МетаданныеКонфигурация(БромКлиент клиент) : base("", "", "") {
			this.bromClient = клиент;

			this.metadataMap = new Dictionary<string, УзелМетаданных>(StringComparer.OrdinalIgnoreCase);

			this.Init();
		}

		private readonly БромКлиент bromClient;
		private readonly Dictionary<string, УзелМетаданных> metadataMap;
		private ИКешМетаданных cache;
		private Dictionary<string, string> fullNameToPathMap;

		private void Init() {
			this.Очистить();
			this.metadataMap.Clear();

			this.fullNameToPathMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
				{"Справочник", "Справочники"},
				{"Документ", "Документы"},
				{"Перечисление", "Перечисления"},
				{"ПланВидовХарактеристик", "ПланыВидовХарактеристик"},
				{"ПланСчетов", "ПланыСчетов"},
				{"ПланВидовРасчета", "ПланыВидовРасчета"},
				{"БизнесПроцесс", "БизнесПроцессы"},
				{"Задача", "Задачи"},
				{"Константа", "Константы"},
				{"ОбщийМодуль", "ОбщиеМодули"},
				{"ПараметрСеанса", "ПараметрыСеанса"},
				{"КритерийОтбора", "КритерииОтбора"},
				{"Обработка", "Обработки"},
				{"Отчет", "Отчеты"},
				{"ЖурналДокументов", "ЖурналыДокументов"},

				{"РегистрСведений", "РегистрыСведений"},
				{"РегистрНакопления", "РегистрыНакопления"},
				{"РегистрБухгалтерии", "РегистрыБухгалтерии"},
				{"РегистрРасчета", "РегистрыРасчета"},

				{"Последовательность", "Последовательности"},

				{"Реквизит", "Реквизиты"},
				{"ТабличнаяЧасть", "ТабличныеЧасти"},
			};

			new МетаданныеКоллекция(this, this, "ПараметрыСеанса", "ПараметрыСеанса", "ПараметрыСеанса", typeof(MetadataAttribute), true);
			new МетаданныеКоллекция(this, this, "КритерииОтбора", "КритерииОтбора", "Критерии отбора", typeof(MetadataModule), true);
			new МетаданныеКоллекция(this, this, "Константы", "Константы", "Константы", typeof(MetadataAttribute), true);

			new МетаданныеКоллекция(this, this, "Справочники", "Справочники", "Справочники", typeof(MetadataObject), true);
			new МетаданныеКоллекция(this, this, "Документы", "Документы", "Документы", typeof(MetadataObject), true);
			new МетаданныеКоллекция(this, this, "Перечисления", "Перечисления", "Перечисления", typeof(MetadataObject), true);
			new МетаданныеКоллекция(this, this, "ПланыВидовХарактеристик", "ПланыВидовХарактеристик", "Планы видов характеристик", typeof(MetadataObject), true);
			new МетаданныеКоллекция(this, this, "ПланыСчетов", "ПланыСчетов", "Планы счетов", typeof(MetadataObject), true);
			new МетаданныеКоллекция(this, this, "ПланыВидовРасчета", "ПланыВидовРасчета", "Планы видов расчета", typeof(MetadataObject), true);
			new МетаданныеКоллекция(this, this, "БизнесПроцессы", "БизнесПроцессы", "Бизнес-процессы", typeof(MetadataObject), true);
			new МетаданныеКоллекция(this, this, "Задачи", "Задачи", "Задачи", typeof(MetadataObject), true);

			new МетаданныеКоллекция(this, this, "ЖурналыДокументов", "ЖурналыДокументов", "Журналы документов", typeof(MetadataModule), true);
			new МетаданныеКоллекция(this, this, "Обработки", "Обработки", "Обработки", typeof(MetadataModule), true);
			new МетаданныеКоллекция(this, this, "Отчеты", "Отчеты", "Отчеты", typeof(MetadataModule), true);

			new МетаданныеКоллекция(this, this, "РегистрыСведений", "РегистрыСведений", "Регистры сведений", typeof(MetadataModule), true);
			new МетаданныеКоллекция(this, this, "РегистрыНакопления", "РегистрыНакопления", "Регистры накопления", typeof(MetadataModule), true);
			new МетаданныеКоллекция(this, this, "РегистрыБухгалтерии", "РегистрыБухгалтерии", "Регистры бухгалтерии", typeof(MetadataModule), true);
			new МетаданныеКоллекция(this, this, "РегистрыРасчета", "РегистрыРасчета", "Регистры расчета", typeof(MetadataModule), true);

			new МетаданныеКоллекция(this, this, "Последовательности", "Последовательности", "Последовательности", typeof(MetadataModule), true);

			new МетаданныеКоллекция(this, this, "ОбщиеМодули", "ОбщиеМодули", "Общие модули", typeof(MetadataModule), true);
		}

		public ИКешМетаданных Кеш {
			get { return this.cache; }
			set { this.cache = value; }
		}

		internal void ЗарегистрироватьУзел(УзелМетаданных узел) {
			if (this.metadataMap != null) {
				this.metadataMap[узел.ПолноеИмя()] = узел;
			}
		}

		public void Загрузить(string состав, int размерПакета = 0) {
			Task task = this.ЗагрузитьАсинх(состав, размерПакета);
			task.Wait();
		}
		public async Task ЗагрузитьАсинх(string состав, int размерПакета = 0) {
			int индексПакета = 0;
			while(true) {
				MetadataApplication soapMetadataPack = await this.ПолучитьМетаданныеSOAPАсинх(состав, размерПакета, индексПакета);
				this.ЗаполнитьМетаданныеИзПакетаSOAP(soapMetadataPack);
				int запрошеноПакетов	= soapMetadataPack.RequestedObjectsCount;
				int текРазмерПакета		= soapMetadataPack.PackSize;
				int всегоПакетов = текРазмерПакета > 0 ? (запрошеноПакетов + текРазмерПакета - 1) / текРазмерПакета : 0;
				if (индексПакета >= всегоПакетов - 1) {
					break;
				}
				индексПакета++;
			}
		}
		private void ЗаполнитьМетаданныеИзПакетаSOAP(MetadataApplication soapMetadataPack) {
			if (soapMetadataPack.Collection == null) {
				return;
			}

			foreach (MetadataCollection collection in soapMetadataPack.Collection) {
				УзелМетаданных узелКоллекции;
				if (this.ПопыткаНайтиПодчиненный(collection.Name, out узелКоллекции)) {
					if (collection.Item != null) {
						foreach (MetadataNode node in collection.Item) {
							УзелМетаданных узел = node.GetValue(узелКоллекции);
							this.ЗакешироватьЭлементКоллекции(узел, node);
						}
					}
				}
			}
		}

		public override БромКлиент Клиент() {
			return this.bromClient;
		}

		private async Task<MetadataApplication> ПолучитьМетаданныеSOAPАсинх(string состав, int размерПакета, int индексПакета) {
			return (await this.bromClient.SoapКлиент.GetMetadataAsync(состав, (uint)размерПакета, (uint)индексПакета)).@return;
		}

		public Соответствие ПолучитьИменаОбъектовКоллекций(string коллекции) {
			Task<Соответствие> task = this.ПолучитьИменаОбъектовКоллекцийАсинх(коллекции);
			task.Wait();
			return task.Result;
		}
		public async Task<Соответствие> ПолучитьИменаОбъектовКоллекцийАсинх(string коллекции) {
			ValueBase result = await this.bromClient.SoapКлиент.GetMetadaChildrenNamesAsync(коллекции);
			return result.GetValue<Соответствие>(this.bromClient);
		}

		private void ЗакешироватьЭлементКоллекции(УзелМетаданных узелМетаданных, MetadataNode node) {
			if (this.cache != null) {
				this.cache.УстановитьЗначение(узелМетаданных.Путь(), УзелМетаданных.ОбъектВXML(node));
			}
		}
		private void ЗакешироватьИменаЭлементовКоллекции<T> (T[] metadataNodes, УзелМетаданных узелРодитель) where T : MetadataNode {
			if (this.cache != null) {
				string[] именаЧленов = Array.ConvertAll(metadataNodes != null ? metadataNodes : new T[0], new Converter<T, string>(val => val.Name));
				this.cache.УстановитьЗначение("#list." + узелРодитель.Путь(), УзелМетаданных.ОбъектВXML(именаЧленов));
			}
		}

		public bool ПопыткаПолучить(string полноеИмя, out УзелМетаданных метаданные) {
			if (this.metadataMap.TryGetValue(полноеИмя, out метаданные)) {
				return true;
			}


			string[] фрагменты = полноеИмя.Split(".");
			if (фрагменты.Length >= 1) {
				string новФрагмент;
				if (this.fullNameToPathMap.TryGetValue(фрагменты[0], out новФрагмент)) {
					фрагменты[0] = новФрагмент;
				}
			}

			if (фрагменты.Length >= 3) {
				string новФрагмент;
				if (this.fullNameToPathMap.TryGetValue(фрагменты[2], out новФрагмент)) {
					фрагменты[2] = новФрагмент;
				}
			}

			string путь = String.Join('.', фрагменты);

			return this.ПопыткаНайти(путь, out метаданные);
		}
	}
}
