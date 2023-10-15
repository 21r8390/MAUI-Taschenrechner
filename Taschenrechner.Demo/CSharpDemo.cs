using System.Text;
using System.Xml.Serialization;

#pragma warning disable CS0219 // Variable is assigned but its value is never used
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable S1481 // Unused local variables should be removed
#pragma warning disable S2589 // Boolean expressions should not be gratuitous
#pragma warning disable S2583 // Conditionally executed code should be reachable
#pragma warning disable S1854 // Unused assignments should be removed
#pragma warning disable IDE0054 // Use '++' operator
#pragma warning disable S1066 // Collapsible "if" statements should be merged
#pragma warning disable S125 // Sections of code should not be commented out

namespace Taschenrechner.Demo
{
	/// <summary>
	/// Das ist eine Klasse, die überall zugreifbar ist (public class).
	/// </summary>
	public class CSharpDemo
	{
		/// <summary>
		/// Methoden bestehen immer aus einer Signatur ("public void ListenDemo()")
		/// und einem Funktionskörper (der Inhalt zwischen "{" und "}").
		/// Im Funktionskörper steht der Code der ausgeführt werden soll wenn die Methode ausgeführt wird.
		/// </summary>
		private void EineLeereMethode()
		{
			// Hier wird nichts ausgeführt.
			// Um eine Methode auszuführen muss vorgängig eine Instanz der Klasse erzeugt worden sein, welche diese Methode beinhaltet.
			// CSharpDemo demo = new CSharpDemo();
			// demo.EineLeereMethode();
		}

		/// <summary>
		/// Eine Methode welche die wichtigsten Datentypen vorstellt.
		/// </summary>
		public bool DatenTypen()
		{
			// Wahrheitswerte (bool) kennen lediglich zwei verschiedene Werte (true/false), richtig oder falsch.
			// Erstellt eine Variable vom Typ "bool" (Wahrheitswert) und weist den Wert "true" zu.
			bool istWahr = true;

			// Erstellt eine weitere Variable vom Typ "bool" (Wahrheitswert) und weist den Wert "false" zu.
			bool istFalsch = false;

			// Ganzzahlen (Integer, int) können nur ganze Zahlen darstellen (1, 2, 3, -1, -2, etc.).
			int ganzzahl = 0;

			// Fliesskommazahlen (float, double) können auch Zahlen mit Wert "hinter dem Komma" darstellen.
			// double weist gegenüber float eine höhere Präzision auf und wird deshalb meist bevorzugt verwendet.
			float kommaZahl1 = 12.34f;
			double kommaZahl2 = 12.34d;

			// Natürlich können mit Zahlen auch die Grundrechenoperationen (+, -, *, /) ausgeführt werden.
			int ergebnis = ganzzahl + ganzzahl;
			int ergebnis4 = ganzzahl - ganzzahl;
			float ergebnis2 = ganzzahl * kommaZahl1;
			double ergebnis3 = ganzzahl / kommaZahl2;

			return true;
		}

		/// <summary>
		/// Eine Methode die den Umgang mit Wahrheitswerten und if..else demonstriert.
		/// </summary>
		public void Logik()
		{
			bool istWahr = true;
			bool istFalsch = false;

			// Dadurch kann man Blöcke nur unter gewissen Bedingungen ausführen lassen.
			if (istWahr)
			{
				// Dieser Block wird nur ausgeführt wenn "istWahr" true ist.
			}
			if (!istFalsch)
			{
				// Dieser Block wird nur ausgeführt wenn "istFalsch" false ist.
				// Das "!" vor "istFalsch" kehrt den Wert um (aus true wird fals und aus false wird true)

				if (!istWahr)
				{
					// Dieser Block wird entsprechend nicht ausgeführt, da !true == false
				}
			}

			// Hier wird eine Ganzzahl erzeugt, darin können Zahlen wie -1, 0, 1, 2 usw. gespeichert werden.
			// 1.23 kann in einer Ganzzahl nicht gespeichert werden.
			int eineGanzzahl = 0;

			// Mit dem Operator "==" kann auf Gleichheit geprüft werden.
			if (eineGanzzahl == 0)
			{
				// Wird ausgeführt, da eineGannzahl momentan noch den Wert 0 hat.

				// Hier wird 1 zu "eineGanzzahl" addiert und das Ergebnis wieder an "eineGanzzahl" zugewiesen.
				eineGanzzahl = eineGanzzahl + 1;
				// "eineGanzzahl" hat jetzt den Wert 1
			}
			// Mit dem Operator ">=" kann geprüft werden, ob ein Wert grösser oder gleich wie ein anderer Wert ist.
			if (eineGanzzahl >= 1)
			{
				eineGanzzahl = eineGanzzahl + 1;
				// "eineGanzzahl" hat jetzt den Wert 2
			}
			// Gibts mit "<=" auch in die andere Richtung.
			if (eineGanzzahl <= 2)
			{
				eineGanzzahl = eineGanzzahl + 1;
				// "eineGanzzahl" hat jetzt den Wert 3
			}
			else
			{
				// Mit "else" können alle Fälle behandelt werden, in denen die Bedingung im vorherigen "if" nicht erfüllt ist.
				// Dieser Block wird aber nicht aufgerufen.
			}

			// Mittels "&&" lässt sich eine Und-Verknüpfung erzeugen.
			// Es müssen beide Bedingungen erfüllt sein damit der folgende Block ausgeführt wird.
			if (istWahr && eineGanzzahl > 3)
			{
				eineGanzzahl = eineGanzzahl + 1;
			}
			// Mittels "||" lässt sich eine Oder-Verküpfung erzeugen.
			// Es muss eine (oder beide) Bedingung(en) erfüllt sein damit der folgende Block ausgeführt wird.
			if (istFalsch || eineGanzzahl >= 3)
			{
				eineGanzzahl = eineGanzzahl + 1;
			}
			// Diese Verknüpfungen lassen sich über Klammen gruppieren und beliebig oft kombinieren.
			if ((istWahr && !istFalsch && eineGanzzahl > 3) || eineGanzzahl < 4)
			{
				eineGanzzahl = eineGanzzahl + 1;

			}

			// FRAGE: Welchen Wert hat "eineGanzzahl" am Ende?
			// 5
		}

		/// <summary>
		/// Eine Methode die den Umgang mit Listen demonstiert.
		/// </summary>
		public void Listen()
		{
			// Hier wird eine Variable vom Typ "IList<string>" deklariert.
			// Momenten die Variable keinen Wert (= null).
			IList<string> listeAusTexten;

			// Hier eine neue Instanz von "List<string>" erzeugt und der Variable "listeAusTexten" zugewiesen.
			// "listeAusTexten" verweist nun auf die neue Liste (und nicht mehr auf null).
			listeAusTexten = new List<string>();

			// Die Liste kann nun mit einzlnen Texten (strings) befüllt werden.
			listeAusTexten.Add("TEXT1");
			listeAusTexten.Add("TEXT2");
			// Einzelne Elemente können auch wieder entfernt werden..
			listeAusTexten.Remove("TEXT2");
			// .. und wieder hinzugefüt werden
			listeAusTexten.Add("TEXT3");
			listeAusTexten.Add("TEXT4");

			// Der StringBuilder eignet sich um mehre Textstücke speichereffizient zusammenzufügen.
			StringBuilder textErsteller = new StringBuilder();

			string test = "123" + "456";

			// Mit foreach kann für jeden "text" in "listeAusTexten" eine Aktion ausgeführt werden.
			foreach (string text in listeAusTexten)
			{
				// Dieser Block wird für jedes Element in "listeAusTexten" ausgeführt.
				// Die Variable "text" hat den Wert des jeweiligen Elements.
				// Die Liste darf in diesem Block nicht verändert werden, sonst gibt es Fehler!

				// Hier wird "text" in dem StringBuilder "textErsteller" hinzugefügt.
				textErsteller.Append(text);
				textErsteller.Replace("TEXT", "REPLACED");
			}
			// Über die Methode "ToString()" kann aus jedem Objekt ein Text erzeugt werden.
			// Beim StringBuilder führt dies dazu, dass alle Textstücke zusammengefügt werden.
			string erstellterText = textErsteller.ToString();

			// FRAGE: Was steht am Ende in "erstellterText"?
		}

		// AUFGABE: Erstelle eine Methode, welche zwei Zahlen als Parameter entgegennimmt und die Summe der beiden Zahlen zurückgibt.
		// Frage: Was sind Parameter?
		// Frage: Was ein Rückgabewert?
		// Frage: Was für ein Datentyp hat der Rückgabewert / die Zahlen?
		public double AddMethode(double zahl1, double zahl2)
		{
			double summe = zahl1 + zahl2;
			return summe;
		}
	}
}

#pragma warning restore S125 // Sections of code should not be commented out
#pragma warning restore IDE0054 // Use '++' operator
#pragma warning restore S1854 // Unused assignments should be removed
#pragma warning restore S2583 // Conditionally executed code should be reachable
#pragma warning restore S2589 // Boolean expressions should not be gratuitous
#pragma warning restore S1481 // Unused local variables should be removed
#pragma warning restore IDE0028 // Simplify collection initialization
#pragma warning restore IDE0059 // Unnecessary assignment of a value
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore CS0219 // Variable is assigned but its value is never used
#pragma warning restore S1066 // Collapsible "if" statements should be merged
