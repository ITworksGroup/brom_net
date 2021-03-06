﻿namespace ITworks.Brom.Types {
	/// <summary>
	/// Вид периода регистра расчета.
	/// </summary>
    public enum ВидПериодаРегистраРасчета : byte {
		/// <summary>
		/// Базовый период.
		/// </summary>
		БазовыйПериод,
		/// <summary>
		/// Период действия.
		/// </summary>
		ПериодДействия,
		/// <summary>
		/// Период регистрации.
		/// </summary>
		ПериодРегистрации,
		/// <summary>
		/// Фактический период действия.
		/// </summary>
		ФактическийПериодДействия
	}
}
