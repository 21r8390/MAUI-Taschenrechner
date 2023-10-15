using Microsoft.AspNetCore.Components;
using Taschenrechner.Shared;

namespace Taschenrechner.Pages
{
	public partial class Rechner
	{
		public Rechenwerk Rechenwerk { get; } = new Rechenwerk();

		// TODO: Implementieren Sie die fehlenden Methoden um das Rechenwerk zu bedienen
		// Die Knöpfe im HTML-Teil rufen diese Methoden auf

		/// <summary>
		/// Löscht alle bestehenden Eingaben und setzt den Taschenrechner zurück
		/// </summary>
		public void Loeschen()
		{
			Rechenwerk.Loeschen();
		}
	}
}
