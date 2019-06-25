using System;
using System.Collections.Generic;

namespace ITworks.Brom.Types {
    public struct МоментВремени : IEquatable<МоментВремени> {
		public МоментВремени(DateTime дата, Ссылка ссылка) {
			this.date = дата;
			this.reference = ссылка;
		}

		private readonly DateTime date;
		private readonly Ссылка reference;

		public DateTime Дата {
			get { return this.date; }
		}
		public Ссылка Ссылка {
			get { return this.reference; }
		}

		public override string ToString() {
			return this.date.ToString() + "; " + this.reference.ToString();
		}

		public override bool Equals(object obj) {
			return obj is МоментВремени && this.Equals((МоментВремени)obj);
		}

		public bool Equals(МоментВремени other) {
			return this.date == other.date &&
				   EqualityComparer<Ссылка>.Default.Equals(this.reference, other.reference);
		}

		public override int GetHashCode() {
			var hashCode = 178113243;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + this.date.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<Ссылка>.Default.GetHashCode(this.reference);
			return hashCode;
		}
	}
}
