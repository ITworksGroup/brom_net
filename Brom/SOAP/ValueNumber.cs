using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueNumber {
		public ValueNumber() {
		}
		public ValueNumber(decimal value) {
			this.Value = value;
		}
		public ValueNumber(int value) : this(Convert.ToDecimal(value)) { }
		public ValueNumber(uint value) : this(Convert.ToDecimal(value)) { }
		public ValueNumber(short value) : this(Convert.ToDecimal(value)) { }
		public ValueNumber(sbyte value) : this(Convert.ToDecimal(value)) { }
		public ValueNumber(long value) : this(Convert.ToDecimal(value)) { }
		public ValueNumber(ulong value) : this(Convert.ToDecimal(value)) { }
		public ValueNumber(double value) : this(Convert.ToDecimal(value)) { }
		public ValueNumber(float value) : this(Convert.ToDecimal(value)) { }
		public ValueNumber(object value) : this(Convert.ToDecimal(value)) { }


		public override object GetValue(БромКлиент client = null) {
			return this.Value;
		}

		public static implicit operator ValueNumber(decimal value) {
			return new ValueNumber(value);
		}
		public static implicit operator ValueNumber(int value) {
			return new ValueNumber(value);
		}
		public static implicit operator ValueNumber(uint value) {
			return new ValueNumber(value);
		}
		public static implicit operator ValueNumber(short value) {
			return new ValueNumber(value);
		}
		public static implicit operator ValueNumber(ushort value) {
			return new ValueNumber(value);
		}
		public static implicit operator ValueNumber(byte value) {
			return new ValueNumber(value);
		}
		public static implicit operator ValueNumber(sbyte value) {
			return new ValueNumber(value);
		}
		public static implicit operator ValueNumber(long value) {
			return new ValueNumber(value);
		}
		public static implicit operator ValueNumber(ulong value) {
			return new ValueNumber(value);
		}
		public static implicit operator ValueNumber(double value) {
			return new ValueNumber(value);
		}
		public static implicit operator ValueNumber(float value) {
			return new ValueNumber(value);
		}


		public static explicit operator decimal(ValueNumber value) {
			return value.Value;
		}
		public static explicit operator int(ValueNumber value) {
			return (int)value.Value;
		}
		public static explicit operator uint(ValueNumber value) {
			return (uint)value.Value;
		}
		public static explicit operator short(ValueNumber value) {
			return (short)value.Value;
		}
		public static explicit operator long(ValueNumber value) {
			return (long)value.Value;
		}
		public static explicit operator ulong(ValueNumber value) {
			return (ulong)value.Value;
		}
		public static explicit operator byte(ValueNumber value) {
			return (byte)value.Value;
		}
		public static explicit operator sbyte(ValueNumber value) {
			return (sbyte)value.Value;
		}
		public static explicit operator double(ValueNumber value) {
			return (double)value.Value;
		}
		public static explicit operator float(ValueNumber value) {
			return (float)value.Value;
		}
	}
}
