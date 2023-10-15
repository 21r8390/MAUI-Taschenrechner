namespace Taschenrechner.Shared
{
	/// <summary>
	/// Eine Auflistung die den Typ einer Operation bestimmt.
	/// </summary>
	public enum OperationsTyp
	{
		/// <summary>
		/// Gibt an, dass die Operation als Zahl interpretiert werden soll.
		/// </summary>
		Zahl,

		/// <summary>
		/// Gibt an, dass die Operation als Operator interpretiert werden soll.
		/// </summary>
		Operator
	}

	/// <summary>
	/// Definiert eine Operation (Eingabe einer Zahl oder Eingabe eines Operators)
	/// </summary>
	public class Operation
	{
		private object wert;

		/// <summary>
		/// Erstellt eine Operation, welche die Eingabe einer Zahl abbildet.
		/// </summary>
		/// <param name="zahl">Die Zahl dieser Operation</param>
		public Operation(double zahl)
		{
			Typ = OperationsTyp.Zahl;
			wert = zahl;
		}
		/// <summary>
		/// Erstellt eine Operation, welche die Eingabe eines Operators abbildet.
		/// </summary>
		/// <param name="operator">Der Operator dieser Operation</param>
		public Operation(Operator @operator)
		{
			Typ = OperationsTyp.Operator;
			wert = @operator;
		}

		/// <summary>
		/// Gibt den Typ dieser Operation zurück (Zahl oder Operator).
		/// </summary>
		public OperationsTyp Typ { get; private set; }

		/// <summary>
		/// Gibt die Zahl dieser Operation zurück oder legt diese fest.
		/// Vorsicht: Ist diese Operation nicht vom Typ Zahl tritt ein Fehler auf!
		/// </summary>
		public double Zahl
		{ get { return (double)wert; } set { wert = value; } }

		/// <summary>
		/// Gibt die Zahl dieser Operation zurück oder legt diese fest.
		/// Vorsicht: Ist diese Operation nicht vom Typ Zahl tritt ein Fehler auf!
		/// </summary>
		public Operator Operator
		{ get { return (Operator)wert; } set { wert = value; } }

		public override string ToString()
		{
			return $"[{Typ}, {wert}]";
		}
	}
}
