using ITworks.Brom.Metadata;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ITworks.Brom {
	/// <summary>
	/// Строка табличной части.
	/// </summary>
	public class СтрокаТабличнойЧасти : DynamicObject {
		internal СтрокаТабличнойЧасти(ТабличнаяЧасть таблЧасть) {
			this.tableSection = таблЧасть ?? throw new ArgumentNullException("таблЧасть");
			this.values = new Dictionary<string, object>();
		}

		private readonly ТабличнаяЧасть tableSection;
		private Dictionary<string, object> values;

		internal void УстановитьЗначение(string имяПоля, object значение) {
			this.values[имяПоля] = значение;
		}

		#region DynamicObject
		private bool TryGetMemberCommon(string fieldName, out object result) {
			result = null;
			УзелМетаданных реквизит;
			if (this.tableSection.Метаданные().ПопыткаНайти("Реквизиты." + fieldName, out реквизит)) {
				this.values.TryGetValue(реквизит.Имя(), out result);
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

		private bool TrySetMemberCommon(string fieldName, object value) {
			УзелМетаданных реквизит;
			if (this.tableSection.Метаданные().ПопыткаНайти("Реквизиты." + fieldName, out реквизит)) {
				if (this.tableSection is ТабличнаяЧастьКонтекст) {
					this.values[реквизит.Имя()] = value;
					(this.tableSection as ТабличнаяЧастьКонтекст).SetIsModified(true);
					return true;
				}
				else {
					throw new MemberAccessException(String.Format("Реквизит \"{0}\" доступен только для чтения.", реквизит.Имя()));
				}
			}

			return false;
		}
		public override bool TrySetMember(SetMemberBinder binder, object value) {
			return this.TrySetMemberCommon(binder.Name, value);
		}
		public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value) {
			return this.TrySetMemberCommon((string)indexes[0], value);
		}

		public override IEnumerable<string> GetDynamicMemberNames() {
			return this.tableSection.Метаданные().Найти("Реквизиты").GetDynamicMemberNames();
		}
		#endregion
	}
}
