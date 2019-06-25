using ITworks.Brom.Metadata;
using System.Collections.Generic;
using System.Dynamic;

namespace ITworks.Brom {
	/// <summary>
	/// Модуль менеджера коллекции.
	/// </summary>
	public class КоллекцияМенеджер : ПрограммныйМодуль {
		internal КоллекцияМенеджер(БромКлиент клиент, УзелМетаданных метаданныеМодуля) : base(клиент, метаданныеМодуля) {
		}

		private bool TryGetMemberCommon(string fieldName, out object result) {
			УзелМетаданных метаданные = this.moduleMetadata.Найти(fieldName);
			if (метаданные != null) {
				result = new МодульМенеджер(this.bromClient, метаданные);
				return true;
			}

			result = null;
			return false;
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return this.TryGetMemberCommon(binder.Name, out result);
		}
		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			return this.TryGetMemberCommon((string)indexes[0], out result);
		}

		public override IEnumerable<string> GetDynamicMemberNames() {
			return this.moduleMetadata.GetDynamicMemberNames();
		}
	}
}
