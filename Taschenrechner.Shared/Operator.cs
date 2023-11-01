namespace Taschenrechner.Shared
{
	/// <summary>
	/// Eine Auflistung der möglichen Operatoren.
	/// </summary>
	public enum Operator
	{
		/// <summary>
		/// Gibt an, dass zwei Zahlen zusammengezählt werden sollen. z.B. 1+1 -> 2
		/// </summary>
		Plus,

		/// <summary>
		/// Gibt an, dass eine zweite Zahl von einer ersten abgezogen werden soll. z.B. 2-1 -> 1
		/// </summary>
		Minus,

		/// <summary>
		/// Gibt an, dass zwei Zahlen miteinander multipliziert werden sollen. z.B. 2*3 -> 6
		/// </summary>
		Multiplizieren,

		/// <summary>
		/// Gibt an, dass eine erste Zahl durch eine zweite Zahl geteilt werden soll. z.B. 6/2 -> 3
		/// </summary>
		Dividieren,

		// TODO: Erweiterte Operatoren (Beispiele)
		///// <summary>
		///// Gibt an, dass das Vorzeichen einer Zahl gewechselt werden soll. z.B. 5 -> -5
		///// </summary>
		//Negieren,
		///// <summary>
		///// Gibt an, dass ein Dezimalpunkt gesetzt werden soll.
		///// Die Eingabe weiterer Zahlen soll hinter dem Komma stattfinden. z.B. [1][.][2][3] -> 1.23
		///// </summary>
		//Dezimalpunkt,
		///// <summary>
		///// Gibt an, dass die Wurzel aus der aktuellen Zahl gezogen werden soll. z.B. √(9) -> 3
		///// </summary>
		//Wurzel,
		///// <summary>
		///// Gibt an, dass die aktuelle Zahl hoch zwei genommen werden soll. z.B. 3² -> 9
		///// </summary>
		//Hoch2
	}

	public static class OperatorExtensions
	{
		public static string ToDisplayString(this Operator @operator)
		{
			return @operator switch
			{
				Operator.Plus => "+",
				Operator.Minus => "–",
				Operator.Multiplizieren => "•",
				Operator.Dividieren => "÷",
				_ => throw new NotImplementedException($"Unbekannter Operator {@operator}"),
			};
		}
	}
}