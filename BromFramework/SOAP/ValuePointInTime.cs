using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValuePointInTime {
		public ValuePointInTime() {
		}
		public ValuePointInTime(DateTime date, ОбъектСсылка reference) {
			this.Date = date;
			this.Ref = new ValueObjectRef(reference);
		}
		public ValuePointInTime(МоментВремени pointIntime) : this(pointIntime.Дата, (ОбъектСсылка)pointIntime.Ссылка) { }
		public ValuePointInTime(object value) : this((МоментВремени)value) { }

		public override object GetValue(БромКлиент client = null) {
			return new МоментВремени(this.Date, this.Ref.GetValue(client) as ОбъектСсылка);
		}

		public static implicit operator ValuePointInTime(МоментВремени value) {
			return new ValuePointInTime(value);
		}
	}
}
