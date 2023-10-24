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
			operationen.Add(new Operation(0.0));
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

			int zahl = (int)ziffer;
			operationen.Add(new Operation(zahl));
		}

		/// <summary>
		/// Eine Methode um die Eingabe eines neuen Operators zu verarbeiten.
		/// </summary>
		/// <param name="operator">Der Operator, der verarbeitet werden soll</param>
		public void OperatorDazu(Operator @operator)
		{
			// TODO: Was muss passieren, wenn ein neuer Operator eingegeben wurde?
			// TIPP: Wenn die aktuelle Operation eine Zahl ist muss etwas Anderes passieren als wenn die aktuelle Operation bereits ein Operator ist.

			operationen.Add(new Operation(@operator));
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

			var anzeigeText = new StringBuilder();

			foreach (var operation in operationen)
			{
				if (operation.Typ == OperationsTyp.Operator)
				{

					anzeigeText.Append("+");
				}
				else
				{
					anzeigeText.Append(operation.Zahl);
				}
			}

			return anzeigeText.ToString();
		}
	}
}
