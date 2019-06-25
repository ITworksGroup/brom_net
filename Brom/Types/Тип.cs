using System;
using System.Collections.Generic;

namespace ITworks.Brom.Types {
	public sealed class Тип : IEquatable<Тип> {
		public Тип(string xmlИмяТипа, string xmlПространствоИмен) {
			this.name = xmlИмяТипа;
			this.nameSpace = xmlПространствоИмен;
		}

		private readonly string name;
		private readonly string nameSpace;

		public string XmlИмя {
			get { return this.name; }
		}
		public string XmlПространствоИмен {
			get { return this.nameSpace; }
		}

		public override string ToString() {
			return this.name;
		}

		public override bool Equals(object obj) {
			return this.Equals(obj as Тип);
		}

		public bool Equals(Тип other) {
			if (Object.ReferenceEquals(other, null)) {
				return false;
			}

			if (Object.ReferenceEquals(this, other)) {
				return true;
			}

			if (this.GetType() != other.GetType()) {
				return false;
			}

			return this.name.Equals(other.name, StringComparison.OrdinalIgnoreCase) && this.nameSpace.Equals(other.nameSpace, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode() {
			var hashCode = 243084502;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.name);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.nameSpace);
			return hashCode;
		}

		public static bool operator ==(Тип type1, Тип type2) {
			if (Object.ReferenceEquals(type1, null)) {
				return Object.ReferenceEquals(type2, null);
			}
			return type1.Equals(type2);
		}
		public static bool operator !=(Тип type1, Тип type2) {
			return !(type1 == type2);
		}

		public static string XMLПространствоИменXmlSchema {
			get { return "#xs"; }
		}
		public static string XMLПространствоИмен1C {
			get { return "#1c"; }
		}

		public static Тип Строка {
			get { return new Тип("string", Тип.XMLПространствоИменXmlSchema); }
		}
		public static Тип Число {
			get { return new Тип("decimal", Тип.XMLПространствоИменXmlSchema); }
		}
		public static Тип Дата {
			get { return new Тип("dateTime", Тип.XMLПространствоИменXmlSchema); }
		}
		public static Тип Булево {
			get { return new Тип("boolean", Тип.XMLПространствоИменXmlSchema); }
		}
		public static Тип ДвоичныеДанные {
			get { return new Тип("base64Binary", Тип.XMLПространствоИменXmlSchema); }
		}
		public static Тип ХранилищеЗначения {
			get { return new Тип("ValueStorage", Тип.XMLПространствоИмен1C); }
		}
		public static Тип УникальныйИдентификатор {
			get { return new Тип("UUID", Тип.XMLПространствоИмен1C); }
		}

		public static Тип ВидДвиженияНакопления {
			get { return new Тип("AccumulationMovementType", Тип.XMLПространствоИмен1C); }
		}
		public static Тип ВидДвиженияБухгалтерии {
			get { return new Тип("AccountingMovementType", Тип.XMLПространствоИмен1C); }
		}
		public static Тип ВидСчета {
			get { return new Тип("AccountType", Тип.XMLПространствоИмен1C); }
		}

		public static Тип СправочникСсылка(string имя) {
			return new Тип("CatalogRef." + имя, String.Empty);
		}
		public static Тип ДокументСсылка(string имя) {
			return new Тип("DocumentRef." + имя, String.Empty);
		}
		public static Тип ПеречислениеСсылка(string имя) {
			return new Тип("EnumRef." + имя, String.Empty);
		}
		public static Тип ПланВидовХарактеристикСсылка(string имя) {
			return new Тип("ChartOfCharacteristicTypesRef." + имя, String.Empty);
		}
		public static Тип ПланСчетовСсылка(string имя) {
			return new Тип("ChartOfAccountsRef." + имя, String.Empty);
		}
		public static Тип ПланВидовРасчетаСсылка(string имя) {
			return new Тип("ChartOfCalculationTypesRef." + имя, String.Empty);
		}
		public static Тип БизнесПроцессСсылка(string имя) {
			return new Тип("BusinessProcessRef." + имя, String.Empty);
		}
		public static Тип ЗадачаСсылка(string имя) {
			return new Тип("TaskRef." + имя, String.Empty);
		}
	}
}
