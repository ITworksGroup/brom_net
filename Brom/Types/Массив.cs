using System.Collections;

/// <summary>
/// Массив объектов.
/// </summary>
namespace ITworks.Brom.Types {
	public class Массив : ArrayList {
		public Массив():base() {
		}
		public Массив(int вместимость) : base(вместимость) {
		}
		public Массив(ICollection элементы) : base(элементы) {
		}

		/// <summary>
		/// Добавляет значение в массив.
		/// </summary>
		/// <param name="значение"></param>
		public void Добавить(object значение) {
			this.Add(значение);
		}
		/// <summary>
		/// Вставляет значение в указанную позицию.
		/// </summary>
		/// <param name="индекс">Индекс позиции.</param>
		/// <param name="значение">Значение.</param>
		public void Вставить(int индекс, object значение) {
			this.Insert(индекс, значение);
		}
		/// <summary>
		/// Удаляет элемент массива по индексу.
		/// </summary>
		/// <param name="индекс"></param>
		public void Удалить(int индекс) {
			this.RemoveAt(индекс);
		}
		/// <summary>
		/// Очищает массив.
		/// </summary>
		public void Очистить() {
			this.Clear();
		}
		/// <summary>
		/// Получает элемент массива по индексу.
		/// </summary>
		/// <param name="индекс">Индекс элемента.</param>
		/// <returns></returns>
		public object Получить(int индекс) {
			return this[индекс];
		}
		/// <summary>
		/// Устанавливает значение элемента массива.
		/// </summary>
		/// <param name="индекс">Индекс элемента.</param>
		/// <param name="значение">Устанавливаемое значение.</param>
		/// <returns></returns>
		public object Установить(int индекс, object значение) {
			return this[индекс] = значение;
		}
		/// <summary>
		/// Количество элементов в массиве.
		/// </summary>
		/// <returns>Возвращает количество элементов в массиве.</returns>
		public int Количество() {
			return this.Count;
		}
		/// <summary>
		/// Находи элемент по значению и возвращает его индекс.
		/// </summary>
		/// <param name="значение"></param>
		/// <returns>Индекс элемента, если элемент найден, или null, если элемент не найден.</returns>
		public object Найти(object значение) {
			int index = this.IndexOf(значение);
			if (index >= 0) {
				return index;
			}

			return null;
		}
	}
}
