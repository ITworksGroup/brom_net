using ITworks.Brom.SOAP;
using ITworks.Brom.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITworks.Brom.Metadata {
	public class МетаданныеКоллекция : УзелМетаданных {
		public МетаданныеКоллекция(МетаданныеКонфигурация корень, УзелМетаданных родитель, string имя, string полноеИмя, string синоним, Type типSoap, bool проверятьКеш = false) : base(корень, родитель, имя, полноеИмя, синоним) {
			this.checkCache = проверятьКеш;
			this.soapType = типSoap;
		}

		private readonly bool checkCache;
		private readonly Type soapType;
		private string[] childrenNames;

		public override IEnumerable<string> GetDynamicMemberNames() {
			if (!this.checkCache) {
				return base.GetDynamicMemberNames();
			}

			if (this.childrenNames != null) {
				return this.childrenNames;
			}

			// пытаемся получить из кеша
			ИКешМетаданных кеш = this.Корень().Кеш;
			if (кеш != null) {
				string именаXML;
				if (кеш.ПопыткаПолучитьЗначение("#list." + this.Путь(), out именаXML)) {
					this.childrenNames = УзелМетаданных.ОбъектИзXML<string[]>(именаXML);
					return this.childrenNames;
				}
			}

			// пытаемся загрузить с сервера
			Соответствие картаИмен = this.Корень().ПолучитьИменаОбъектовКоллекций(this.Путь());
			Массив именаВрем = картаИмен[this.Путь()] as Массив;
			if (именаВрем != null) {
				string[] имена = new string[именаВрем.Count];
				for (int i = 0; i < именаВрем.Count; i++) {
					имена[i] = (string)именаВрем[i];
				}
				this.childrenNames = имена;
				if (кеш != null) {
					кеш.УстановитьЗначение("#list." + this.Путь(), УзелМетаданных.ОбъектВXML(имена));
				}
				return this.childrenNames;
			}

			throw new Exception(String.Format("Не удалось получить имена подчиненых узлов для коллекции \"{0}\"", this.Путь()));
		}

		protected override bool ПопыткаНайтиПодчиненный(string имя, out УзелМетаданных узел) {
			if(base.ПопыткаНайтиПодчиненный(имя, out узел)) {
				return true;
			}

			if (this.checkCache) {
				ИКешМетаданных кеш = this.Корень().Кеш;
				string xmlМетаданные;
				if (кеш != null && кеш.ПопыткаПолучитьЗначение(this.Путь() + "." + имя, out xmlМетаданные)) {
					узел = ((MetadataNode)УзелМетаданных.ОбъектИзXML(xmlМетаданные, this.soapType)).GetValue(this);
					return true;
				}

				IEnumerable<string> именаПодчиненных = this.GetDynamicMemberNames();
				if (именаПодчиненных.Contains(имя, StringComparer.OrdinalIgnoreCase)) {
					this.Корень().Загрузить(String.Format("{0}.{1}", this.Путь(), имя));
					return this.ПопыткаНайтиПодчиненный(имя, out узел);
				}
			}

			узел = null;
			return false;
		}

		public override IEnumerator<KeyValuePair<string, УзелМетаданных>> GetEnumerator() {
			if (this.checkCache) {
				IEnumerable<string> names = this.GetDynamicMemberNames();
				foreach (string name in names) {
					УзелМетаданных узел;
					if (this.ПопыткаНайтиПодчиненный(name, out узел)) {
						yield return new KeyValuePair<string, УзелМетаданных>(name, узел);
					}
				}
			}
			else {
				var baseEnumerator = base.GetEnumerator();
				while (baseEnumerator.MoveNext()) {
					yield return baseEnumerator.Current;
				}
			}
		}
	}
}
