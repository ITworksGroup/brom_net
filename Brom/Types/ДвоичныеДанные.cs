using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Двоичные данные.
	/// </summary>
	public class ДвоичныеДанные : IList<byte> {
		/// <summary>
		/// Конструктор двоичных данных.
		/// </summary>
		/// <param name="данные">Массив байт двоичных данных.</param>
		public ДвоичныеДанные(byte[] данные) {
			this.data = данные;
		}
		/// <summary>
		/// Конструктор двоичных данных.
		/// </summary>
		/// <param name="путьФайла">Путь к файлу, содержащему двоичные данные.</param>
		public ДвоичныеДанные(string путьФайла) {
			this.data = File.ReadAllBytes(путьФайла);
		}

		private byte[] data;

		/// <summary>
		/// Размер массива двоичных данных в байтах.
		/// </summary>
		/// <returns></returns>
		public long Размер() {
			return this.Count;
		}
		/// <summary>
		/// Массив байт двоичных данных.
		/// </summary>
		public byte[] Данные {
			get {
				return this.data;
			}
		}

		/// <summary>
		/// Записывает данные в файл.
		/// </summary>
		/// <param name="имяФайла">Полное имя файла.</param>
		public void Записать(string имяФайла) {
			File.WriteAllBytes(имяФайла, this.data);
		}

		/// <summary>
		/// Создает поток для чтения данных.
		/// </summary>
		/// <returns></returns>
		public Stream ОткрытьПотокДляЧтения() {
			return new MemoryStream(this.data, false);
		}

		#region IReadOnlyList
		public int Count => ((IList<byte>)this.data).Count;

		public bool IsReadOnly => ((IList<byte>)this.data).IsReadOnly;

		public byte this[int index] { get => ((IList<byte>)this.data)[index]; set => ((IList<byte>)this.data)[index] = value; }

		public int IndexOf(byte item) {
			return ((IList<byte>)this.data).IndexOf(item);
		}

		public void Insert(int index, byte item) {
			((IList<byte>)this.data).Insert(index, item);
		}

		public void RemoveAt(int index) {
			((IList<byte>)this.data).RemoveAt(index);
		}

		public void Add(byte item) {
			((IList<byte>)this.data).Add(item);
		}

		public void Clear() {
			((IList<byte>)this.data).Clear();
		}

		public bool Contains(byte item) {
			return ((IList<byte>)this.data).Contains(item);
		}

		public void CopyTo(byte[] array, int arrayIndex) {
			((IList<byte>)this.data).CopyTo(array, arrayIndex);
		}

		public bool Remove(byte item) {
			return ((IList<byte>)this.data).Remove(item);
		}

		public IEnumerator<byte> GetEnumerator() {
			return ((IList<byte>)this.data).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IList<byte>)this.data).GetEnumerator();
		}
		#endregion

		/// <summary>
		/// Строковое представление двоичных данных.
		/// </summary>
		/// <returns>Возвращает строковое представление двоичных данных.</returns>
		public override string ToString() {
			return BitConverter.ToString(this.data).Replace("-", " ");
		}

	}
}
