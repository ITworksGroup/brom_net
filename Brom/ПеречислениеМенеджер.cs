using ITworks.Brom.Metadata;
using ITworks.Brom.Types;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ITworks.Brom {
	public class ПеречислениеМенеджер : МодульМенеджер {
		public ПеречислениеМенеджер(БромКлиент bromClient, УзелМетаданных метаданныеКоллекции):base(bromClient, метаданныеКоллекции) {
		}

		private bool TryGetMemberCommon(string fieldName, out object result) {
			result = null;
			Ссылка resultRef = null;
			var predefined = (this.moduleMetadata as МетаданныеОбъект).Предопределенные;
			bool checkResult = predefined != null ? predefined.TryGetValue(fieldName, out resultRef) : false;
			result = resultRef;
			return checkResult;
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return this.TryGetMemberCommon(binder.Name, out result);
		}
		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			return this.TryGetMemberCommon((string)indexes[0], out result);
		}

		public override IEnumerable<string> GetDynamicMemberNames() {
			var predefined = (this.moduleMetadata as МетаданныеОбъект).Предопределенные;
			return predefined?.Keys ?? new string[0];
		}

		public Селектор СоздатьСелектор() {
			Селектор селектор = new Селектор(this.bromClient);
			селектор.УстановитьКоллекцию(ТипКоллекции.Перечисление, this.moduleMetadata.Имя());
			return селектор;
		}

		public ПеречислениеСсылка ПустаяСсылка() {
			return Ссылка.СоздатьСсылку(this.bromClient, ТипКоллекции.Перечисление, null) as ПеречислениеСсылка;
		}
	}
}
