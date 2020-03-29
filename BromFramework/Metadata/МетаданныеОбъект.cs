using ITworks.Brom.SOAP;
using ITworks.Brom.Types;
using System;
using System.Collections.Generic;

namespace ITworks.Brom.Metadata {
	public class МетаданныеОбъект : УзелМетаданных {
		internal МетаданныеОбъект(УзелМетаданных родитель, MetadataObject metadata) : 
			base(
				родитель.Корень(),
				родитель, 
				metadata.Name, 
				metadata.FullName, 
				metadata.Title
			) {

			this.collectionType = (ТипКоллекции)Enum.Parse(typeof(ТипКоллекции), metadata.CollectionType);

			УзелМетаданных.ЗагрузитьРеквизиты(родитель.Корень(), this, metadata.Attribute);
			УзелМетаданных.ЗагрузитьТабличныеЧасти(родитель.Корень(), this, metadata.TableSection);

			Структура предопределенные = metadata.Predefined != null ? metadata.Predefined.GetValue(родитель.Клиент()) as Структура : null;
			if (предопределенные != null) {
				this.predefinedValues = new Dictionary<string, Ссылка>(предопределенные.Count, StringComparer.OrdinalIgnoreCase);
				foreach (var keyValue in предопределенные) {
					this.predefinedValues.Add(keyValue.Key, (Ссылка)keyValue.Value);
				}
			}
		}

		private readonly ТипКоллекции collectionType;
		private readonly Dictionary<string, Ссылка> predefinedValues;

		public ТипКоллекции ТипКоллекции() {
			return this.collectionType;
		}

		public IReadOnlyDictionary<string, Ссылка> Предопределенные {
			get { return this.predefinedValues; }
		}
	}
}
