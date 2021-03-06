﻿namespace ITworks.Brom {
	/// <summary>
	/// Виды сравнений значений в условиях отбора данных 1С.
	/// </summary>
    public enum ВидСравнения : byte {
		/// <summary>
		/// Значение должно быть точно равно заданному.
		/// </summary>
		Равно,
		/// <summary>
		/// Значение не должно быть равно заданному.
		/// </summary>
		НеРавно,
		/// <summary>
		/// Значение зодлжно быть строго больше заданного.
		/// </summary>
		Больше,
		/// <summary>
		/// Значение должно быть больше или равно заданному.
		/// </summary>
		БольшеИлиРавно,
		/// <summary>
		/// Значение должно быть строго меньше заданного.
		/// </summary>
		Меньше,
		/// <summary>
		/// Значение должно быть меньше или равно заданному.
		/// </summary>
		МеньшеИлиРавно,
		/// <summary>
		/// Значение строкового типа должно содержаться в заданном строковом значении.
		/// </summary>
		Содержит,
		/// <summary>
		/// Значение строкового типа не должно содержаться в заданном строковом значении.
		/// </summary>
		НеСодержит,
		/// <summary>
		/// Значение должно содержаться в заданном списке значений.
		/// </summary>
		ВСписке,
		/// <summary>
		/// Значение не должно содержаться в заданном списке значений.
		/// </summary>
		НеВСписке,
		/// <summary>
		/// Ссылка иерархической коллекции должна быть потомком заданной ссылки или одной из ссылок заданного списка.
		/// </summary>
		ВИерархии,
		/// <summary>
		/// Ссылка иерархической коллекции не должна быть потомком заданной ссылки или одной из ссылок заданного списка.
		/// </summary>
		НеВИерархии
	}
}
