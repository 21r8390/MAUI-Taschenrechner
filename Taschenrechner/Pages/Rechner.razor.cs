using Microsoft.AspNetCore.Components;
using Taschenrechner.Shared;

namespace Taschenrechner.Pages
{
	public partial class Rechner
	{
		public Rechenwerk Rechenwerk { get; } = new Rechenwerk();
	}
}
