using ITworks.Brom.Metadata;
using ITworks.Brom.Types;
using System.Dynamic;

namespace ITworks.Brom {
	public class ОбъектыМенеджер : КоллекцияМенеджер {
		public ОбъектыМенеджер(БромКлиент клиент, УзелМетаданных метаданныеКоллекции, ТипКоллекции типКоллекции):base(клиент, метаданныеКоллекции) {
			this.типКоллекции = типКоллекции;
		}

		protected ТипКоллекции типКоллекции;

		private bool TryGetMemberCommon(string name, out object result) {
			УзелМетаданных текМетаданные = null;

			текМетаданные = this.moduleMetadata.Найти(name);
			if (текМетаданные != null) {
				switch (this.типКоллекции) {
					case ТипКоллекции.Справочник:
						result = new СправочникМенеджер(this.bromClient, текМетаданные);
						return true;
					case ТипКоллекции.Документ:
						result = new ДокументМенеджер(this.bromClient, текМетаданные);
						return true;
					case ТипКоллекции.Перечисление:
						result = new ПеречислениеМенеджер(this.bromClient, текМетаданные);
						return true;
					case ТипКоллекции.ПланВидовХарактеристик:
						result = new ПланВидовХарактеристикМенеджер(this.bromClient, текМетаданные);
						return true;
					case ТипКоллекции.ПланСчетов:
						result = new ПланСчетовМенеджер(this.bromClient, текМетаданные);
						return true;
					case ТипКоллекции.ПланВидовРасчета:
						result = new ПланВидовРасчетаМенеджер(this.bromClient, текМетаданные);
						return true;
					case ТипКоллекции.БизнесПроцесс:
						result = new БизнесПроцессМенеджер(this.bromClient, текМетаданные);
						return true;
					case ТипКоллекции.Задача:
						result = new ЗадачаМенеджер(this.bromClient, текМетаданные);
						return true;
				}
			}

			result = null;
			return false;
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return this.TryGetMemberCommon(binder.Name, out result);
		}
		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			return this.TryGetMemberCommon(indexes[0].ToString(), out result);
		}
	}
}
