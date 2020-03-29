using ITworks.Brom.Metadata;
using System.Dynamic;
using System;

namespace ITworks.Brom {
	/// <summary>
	/// Программный модуль.
	/// </summary>
	public abstract class ПрограммныйМодуль : DynamicObject {
		internal ПрограммныйМодуль(БромКлиент клиент, УзелМетаданных метаданныеМодуля) {
			this.bromClient = клиент ?? throw new ArgumentException("Параметр \"клиент\" не определен.", "клиент");
			this.moduleMetadata = метаданныеМодуля ?? throw new ArgumentException("Параметр \"метаданныеМодуля\" не определен.", "метаданныеМодуля");
		}

		protected readonly УзелМетаданных moduleMetadata;
		protected readonly БромКлиент bromClient;

		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return base.TryGetMember(binder, out result);
		}
	}
}
