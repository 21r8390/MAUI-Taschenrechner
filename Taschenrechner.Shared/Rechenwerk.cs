using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Taschenrechner.Shared
{
	public class Rechenwerk
	{
		/// <summary>
		/// Die Liste der bisher eingegebenen Operationen.
		/// Dies ist ein privates Feld (nicht zugreifbar ausserhalb dieser Klasse).
		/// </summary>
		private readonly IList<Operation> operationen;

		/// <summary>
		/// Der Konstruktor für die Klasse Rechenwerk.
		/// Dieser wird ausgeführt, wenn die Klasse instanziiert (new Rechenwerk()) wird.
		/// </summary>
		public Rechenwerk()
		{
			// TODO: Hier müssen Felder und Eigenschaften vom Rechenwerkt mit sinnvollen Startwerten bestückt werden.
			operationen = new List<Operation>();
			Loeschen();
		}

		/// <summary>
		/// Eine Eigenschaft, welche die eigegebenen Operationen als Text formatiert zurückgibt.
		/// </summary>
		public string AnzeigeText => AnzeigeTextAufbereiten();

		/// <summary>
		/// Eine Methode um die Eingabe einer neuen Ziffer zu verarbeiten.
		/// </summary>
		/// <param name="ziffer">Die Ziffer, die verarbeitet werden soll</param>
		public void ZahlDazu(Ziffer ziffer)
		{
			// TODO: Was muss passieren, wenn eine neue Ziffer eingegeben wurde?
			// TIPP: Wenn die aktuelle Operation eine Zahl ist muss etwas Anderes passieren als wenn die aktuelle Operation bereits ein Operator ist.

			// Ziffer in double umwandeln, damit wir damit rechnen können
			var zahl = (double)ziffer;
			var letzteOperation = operationen.LastOrDefault();

			if (letzteOperation == null || letzteOperation.Typ == OperationsTyp.Operator)
			{
				// Wenn die letzte Operation ein Operator war oder es noch keine Operationen gibt, dann fügen wir eine neue Zahl hinzu
				operationen.Add(new Operation(zahl));
			}
			else
			{
				// Wenn die letzte Operation eine Zahl war, dann fügen wir die Ziffer zur Zahl hinzu
				// Mathematik: Wir haben die Zahl 2 und geben die Ziffer 5 ein
				// 2 * 10 => 20
				// 20 + 5 => 25
				letzteOperation.Zahl = letzteOperation.Zahl * 10 + zahl;
			}
		}

		/// <summary>
		/// Eine Methode um die Eingabe eines neuen Operators zu verarbeiten.
		/// </summary>
		/// <param name="operator">Der Operator, der verarbeitet werden soll</param>
		public void OperatorDazu(Operator @operator)
		{
			// TODO: Was muss passieren, wenn ein neuer Operator eingegeben wurde?
			// TIPP: Wenn die aktuelle Operation eine Zahl ist muss etwas Anderes passieren als wenn die aktuelle Operation bereits ein Operator ist.

			var letzteOperation = operationen.LastOrDefault();

			if (letzteOperation != null)
			{
				if (letzteOperation.Typ == OperationsTyp.Zahl)
				{
					// Wenn die letzte Operation eine Zahl war, dann fügen wir einen neuen Operator hinzu
					operationen.Add(new Operation(@operator));
				}
				else
				{
					// Wenn zuletzt ein Operator eingegeben wurde, dann ersetzen wir diesen mit dem neuen Operator
					letzteOperation.Operator = @operator;
				}
			}

		}

		/// <summary>
		/// Eine Methode um alle bisherigen Eingaben auswerten (rechnen) zu lassen.
		/// </summary>
		public void Auswerten()
		{
			// TODO: Was muss getan werden um alle bisherigen Eingaben auszurechnen?
			// TODO: (Erweitert) Was muss getan werden damit "Punkt-vor-Strich" berücksichtigt wird?
			// TIPP: Was ist ein "Stack" und wieso könnte dieser beim Rechnen nützlich sein?
			// https://3.bp.blogspot.com/-ZTPyluNn8oU/XlkES_014qI/AAAAAAAAHRs/fG18AQEHxAwtzXiM7nKbssA3sl3uPVAtQCLcBGAsYHQ/s1600/0_SESFJYWU5a-3XM9m.gif

			var offeneOperationen = new Stack<Operation>(operationen.Reverse());
			var ergebnis = Rechne(offeneOperationen);

			operationen.Clear();
			operationen.Add(ergebnis);
		}

		private Operation Rechne(Stack<Operation> offeneOperationen)
		{
			while (offeneOperationen.Skip(1).Any())
			{
				// Wir wissen, dass es mindestens 3 Operationen gibt (Zahl, Operator, Zahl)
				double zahl1 = offeneOperationen.Pop().Zahl;
				Operator @operator = offeneOperationen.Pop().Operator;
				double zahl2 = offeneOperationen.Pop().Zahl;

				// Punkt-vor-Strich
				// Wenn der aktuelle Operator stärker bindend ist als der nächste Operator, dann müssen wir die nächste Operation zuerst ausrechnen
				if (offeneOperationen.Any() && IstStaerkerBindend(@operator, offeneOperationen.Peek().Operator))
				{
					// 2. Zahl wieder in Stack legen, damit wir wieder schöne 3 Operationen haben (Zahl, Operator, Zahl)
					offeneOperationen.Push(new Operation(zahl2));
					// Restliche Operationen ausrechnen und das Ergebnis als 2. Zahl verwenden
					var restlichesErgebnis = Rechne(offeneOperationen);
					zahl2 = restlichesErgebnis.Zahl;
				}

				// 2 Zahlen und 1 Operator ausrechnen und das Ergebnis als neue Zahl in den Stack legen
				double ergebnis = Berechne(zahl1, @operator, zahl2);
				offeneOperationen.Push(new Operation(ergebnis));
			}

			// Wenn es nur noch eine Operation gibt, dann ist dass das Ergebnis
			return offeneOperationen.Pop();
		}

		private static bool IstStaerkerBindend(Operator aktueller, Operator zuPruefen)
		{
			// TODO: Wie kann geprüft werden ob der Operator "zuPruefen" stärker bindend ist als der Operator "naechster"?

			return aktueller is Operator.Plus or Operator.Minus
				&& zuPruefen is Operator.Multiplizieren or Operator.Dividieren;
		}

		private static double Berechne(double zahl1, Operator @operator, double zahl2)
		{
			return @operator switch
			{
				Operator.Plus => zahl1 + zahl2,
				Operator.Minus => zahl1 - zahl2,
				Operator.Multiplizieren => zahl1 * zahl2,
				Operator.Dividieren => zahl1 / zahl2,
				_ => throw new InvalidEnumArgumentException($"Unbekannter Operator {@operator}"),
			};
		}

		/// <summary>
		/// Eine Methode um alle bisherigen Eingaben zu löschen.
		/// </summary>
		public void Loeschen()
		{
			operationen.Clear();
			operationen.Add(new Operation(0.0));
		}

		/// <summary>
		/// Eine Methode welche den Anzeigetext aufbereiten soll.
		/// </summary>
		/// <returns>den aufbereiteten Anzeigetext als Text</returns>
		private string AnzeigeTextAufbereiten()
		{
			// TODO: Wie kann aus dem Feld "operationen" ein lesbarer Text erzeugt werden?
			// TIPP: foreach und StringBuilder verwenden

			var anzeigeTextErsteller = new StringBuilder();

			foreach (var operation in operationen)
			{
				if (operation.Typ == OperationsTyp.Zahl)
				{
					// Zahlen können automatisch in Text umgewandelt werden
					anzeigeTextErsteller.Append(operation.Zahl);
				}
				else
				{
					// Operatoren müssen manuell in Text umgewandelt werden
					anzeigeTextErsteller.Append(operation.Operator.ToDisplayString());
				}
			}

			return anzeigeTextErsteller.ToString();
		}
	}
}
