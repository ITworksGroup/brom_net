using ITworks.Brom.SOAP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ITworks.Brom.Metadata {
	public abstract class УзелМетаданных : DynamicObject, IEnumerable<KeyValuePair<string, УзелМетаданных>> {
		protected УзелМетаданных(МетаданныеКонфигурация корень, УзелМетаданных родитель, string имя, string полноеИмя, string синоним) {
			this.root = корень;
			this.name = имя;
			this.fullName = полноеИмя;
			this.title = String.IsNullOrEmpty(синоним) ? имя : синоним;
			this.parent = родитель;

			this.children = new Dictionary<string, УзелМетаданных>(StringComparer.OrdinalIgnoreCase);

			if (родитель != null) {
				родитель.children[this.name] = this;
			}
			
			this.Корень()?.ЗарегистрироватьУзел(this);
		}
		protected УзелМетаданных(string имя, string полноеИмя, string синоним) : this(null, null, имя, полноеИмя, синоним) { }

		private readonly string name;
		private readonly string fullName;
		private readonly string title;
		private readonly УзелМетаданных parent;
		private readonly МетаданныеКонфигурация root;
		private Dictionary<string, УзелМетаданных> children;

		protected void Очистить() {
			this.children.Clear();
		}

		public virtual bool ПопыткаНайтиПодчиненный(string имя, out УзелМетаданных узел) {
			return this.children.TryGetValue(имя, out узел);
		}
		public virtual УзелМетаданных НайтиПодчиненный(string имя) {
			УзелМетаданных узел = null;
			this.children.TryGetValue(имя, out узел);
			return узел;
		}

		public string Имя() {
			return this.name;
		}
		public string ПолноеИмя() {
			return this.fullName;
		}
		public string Синоним() {
			return this.title;
		}
		public УзелМетаданных Родитель() {
			return this.parent;
		}
		public МетаданныеКонфигурация Корень() {
			if (this is МетаданныеКонфигурация) {
				return this as МетаданныеКонфигурация;
			}

			return this.root;
		}
		public string Путь() {
			if (this.Родитель() == null) {
				return "";
			}

			if (String.IsNullOrEmpty(this.Родитель().Путь())) {
				return this.Имя();
			}

			return this.Родитель().Путь() + "." + this.Имя();
		}
		public virtual БромКлиент Клиент() {
			return this.Корень().Клиент();
		}

		internal void ДобавитьУзел(УзелМетаданных узел) {
			this.children[узел.name] = узел;
			this.Корень().ЗарегистрироватьУзел(узел);
		}
		public УзелМетаданных Найти(string имя) {
			УзелМетаданных результат = null;
			this.ПопыткаНайти(имя, out результат);
			return результат;
		}
		public virtual bool ПопыткаНайти(string имя, out УзелМетаданных узел) {
			string[] имена = имя.Split(".");
			УзелМетаданных результат = this;
			foreach (string текИмя in имена) {
				if (!результат.ПопыткаНайтиПодчиненный(текИмя, out результат)) {
					узел = null;
					return false;
				}
			}

			узел = результат;
			return true;
		}
		public bool Содержит(string имя) {
			УзелМетаданных temp;
			return this.ПопыткаНайти(имя, out temp);
		}

		#region DynamicObject
		public bool TryGetMemberCommon(string fieldName, out object result) {
			УзелМетаданных узел;
			if (this.ПопыткаНайти(fieldName, out узел)) {
				result = узел;
				return true;
			}

			result = null;
			return false;
		}

		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			return this.TryGetMemberCommon((string)indexes[0], out result);
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return this.TryGetMemberCommon(binder.Name, out result);
		}

		public override IEnumerable<string> GetDynamicMemberNames() {
			return this.children.Keys;
		}
		#endregion

		#region IEnumerable 
		public virtual IEnumerator<KeyValuePair<string, УзелМетаданных>> GetEnumerator() {
			return this.children.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
		}
		#endregion

		public override string ToString() {
			return this.fullName;
		}

		protected static string ОбъектВXML(object объект) {
			XmlSerializer xmlSerializer = new XmlSerializer(объект.GetType(), "https://brom.itworks.group");
			string result;
			using (MemoryStream stream = new MemoryStream())
			using (XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8)) {
				xmlSerializer.Serialize(xmlWriter, объект);
				result = Encoding.UTF8.GetString(stream.GetBuffer());
			}

			return result;
		}
		protected static object ОбъектИзXML(string xml, Type type) {
			XmlSerializer xmlSerializer = new XmlSerializer(type, "https://brom.itworks.group");
			object result;
			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
			using (XmlTextReader xmlReader = new XmlTextReader(stream)) {
				result = xmlSerializer.Deserialize(xmlReader);
			}

			return result;
		}
		protected static T ОбъектИзXML<T>(string xml) {
			return (T)УзелМетаданных.ОбъектИзXML(xml, typeof(T));
		}

		protected static void ЗагрузитьРеквизиты(МетаданныеКонфигурация корень, УзелМетаданных узелРодитель, MetadataAttribute[] attributesSOAP) {
			УзелМетаданных реквизиты = new МетаданныеКоллекция(корень, узелРодитель, "Реквизиты", string.Format("{0}.Реквизиты", узелРодитель.ПолноеИмя()), "Реквизиты", typeof(MetadataAttribute));
			if (attributesSOAP != null) {
				foreach (MetadataAttribute attribute in attributesSOAP) {
					new МетаданныеРеквизит(реквизиты, attribute);
				}
			}
		}
		protected static void ЗагрузитьТабличныеЧасти(МетаданныеКонфигурация корень, УзелМетаданных узелРодитель, MetadataTableSection[] tablesSOAP) {
			УзелМетаданных табличныеЧасти = new МетаданныеКоллекция(корень, узелРодитель, "ТабличныеЧасти", string.Format("{0}.ТабличныеЧасти", узелРодитель.ПолноеИмя()), "ТабличныеЧасти", typeof(MetadataTableSection));
			if (tablesSOAP != null) {
				foreach (MetadataTableSection table in tablesSOAP) {
					new МетаданныеТабличнаяЧасть(табличныеЧасти, table);
				}
			}
		}

		protected static string КешПрефиксПутиУзла {
			get { return "#path."; }
		}
		protected static string КешПрефиксСпискаЭлементовКоллеции {
			get { return "#children."; }
		}
	}
}
