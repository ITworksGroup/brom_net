using ITworks.Brom.Types;
using System;
using System.Collections;

namespace ITworks.Brom.SOAP { 
    public abstract partial class ValueBase {
		public abstract object GetValue(БромКлиент client = null);
		public T GetValue<T>(БромКлиент client = null) {
			return (T)this.GetValue(client);
		}

		public static ValueBase From(object value) {
			if (value is null) {
				return new ValueNull();
			}
			else if (value is DBNull) {
				return new ValueDBNull();
			}
			else if (value is string) {
				return new ValueString(value);
			}
			else if (value is decimal) {
				return new ValueNumber((decimal)value);
			}
			else if (ValueBase.ЭтоЧисло(value)) {
				return new ValueNumber(value);
			}
			else if (value is bool) {
				return new ValueBoolean(value);
			}
			else if (value is DateTime) {
				return new ValueDate(value);
			}
			else if (value is Guid) {
				return new ValueGuid(value);
			}
			else if (value is МоментВремени) {
				return new ValuePointInTime(value);
			}
			else if (value is Граница) {
				return new ValueBoundary(value);
			}
			else if (value is ПеречислениеСсылка) {
				return new ValueEnumRef(value);
			}
			else if (value is ОбъектСсылка) {
				return new ValueObjectRef(value);
			}
			else if (value is Структура) {
				return new ValueStruct(value);
			}
			else if (value is ДвоичныеДанные) {
				return new ValueBinaryData(value);
			}
			else if (value is ХранилищеЗначения) {
				return new ValueStorage(value);
			}
			else if (value is ТаблицаЗначений) {
				return new ValueTable(value);
			}
			else if (value is ТабличнаяЧасть) {
				return new ValueTable((value as ТабличнаяЧасть).Выгрузить());
			}
			else if (value is ДеревоЗначений) {
				return new ValueTree(value);
			}
			else if (value is IDictionary) {
				return new ValueMap(value as IDictionary);
			}
			else if (value is IList) {
				return new ValueArray(value as IList);
			}
			else if (value is Тип) {
				return new ValueType(value);
			}
			else if (value is ОписаниеТипов) {
				return new ValueTypeDescription(value);
			}

			else if (value is ВидДвиженияБухгалтерии) {
				return new ValueAccountingRecordType(value);
			}
			else if (value is ВидДвиженияНакопления) {
				return new ValueAccumulationRecordType(value);
			}
			else if (value is ВидСчета) {
				return new ValueAccountType(value);
			}
			else if (value is РежимЗаписиДокумента) {
				return new ValueDocumentWriteMode(value);
			}
			else if (value is РежимПроведенияДокумента) {
				return new ValueDocumentPostingMode(value);
			}	

			throw new Exception(String.Format("Тип \"{0}\" не может быть передан удаленному сервису. Сериализация типа данных не поддерживается.", value.GetType().Name));
		}

		private static bool ЭтоЧисло(object значение) {
			return значение is sbyte
			|| значение is byte
			|| значение is short
			|| значение is ushort
			|| значение is int
			|| значение is uint
			|| значение is long
			|| значение is ulong
			|| значение is float
			|| значение is double
			|| значение is decimal;
		}
		private static bool ЭтоЦелоеЧисло(object значение) {
			return значение is sbyte
			|| значение is byte
			|| значение is short
			|| значение is ushort
			|| значение is int
			|| значение is uint
			|| значение is long
			|| значение is ulong;
		}
		private static bool ЭтоВещественноеЧисло(object значение) {
			return значение is float
			|| значение is double
			|| значение is decimal;
		}
	}
}
