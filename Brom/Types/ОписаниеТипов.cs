using System;
using System.Collections;
using System.Collections.Generic;

namespace ITworks.Brom.Types {
	public class ОписаниеТипов : IReadOnlyList<Тип> {
		public ОписаниеТипов(
			Тип[] типы, 
			КвалификаторыЧисла квалификаторыЧисла = null,
			КвалификаторыСтроки квалификаторыСтроки = null,
			КвалификаторыДаты квалификаторыДаты = null,
			КвалификаторыДвоичныхДанных квалификаторыДвоичныхДанных = null
			) {

			this.types = типы;

			this.numberQualifiers = квалификаторыЧисла;
			this.stringQualifiers = квалификаторыСтроки;
			this.dateQualifiers = квалификаторыДаты;
			this.binaryDataQualifiers = квалификаторыДвоичныхДанных;
		}

		private readonly Тип[] types;
		private readonly КвалификаторыСтроки stringQualifiers;
		private readonly КвалификаторыЧисла numberQualifiers;
		private readonly КвалификаторыДаты dateQualifiers;
		private readonly КвалификаторыДвоичныхДанных binaryDataQualifiers;

		public КвалификаторыЧисла КвалификаторыЧисла {
			get { return this.numberQualifiers; }
		}
		public КвалификаторыСтроки КвалификаторыСтроки {
			get { return this.stringQualifiers; }
		}
		public КвалификаторыДаты КвалификаторыДаты {
			get { return this.dateQualifiers; }
		}
		public КвалификаторыДвоичныхДанных КвалификаторыДвоичныхДанных {
			get { return this.binaryDataQualifiers; }
		}

		public Тип[] Типы() {
			return (Тип[])this.types.Clone();
		}
		public bool СодержитТип(Тип тип) {
			return Array.Exists<Тип>(this.types, val => val.Equals(тип));
		}

		public override string ToString() {
			return String.Join<Тип>(", ", this.types);
		}

		#region IReadOnlyList
		public int Count => ((IReadOnlyList<Тип>)this.types).Count;

		public Тип this[int index] => ((IReadOnlyList<Тип>)this.types)[index];

		public IEnumerator<Тип> GetEnumerator() {
			return ((IReadOnlyList<Тип>)this.types).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IReadOnlyList<Тип>)this.types).GetEnumerator();
		}
		#endregion
	}
}
