using Microsoft.Extensions.Logging;
using Taschenrechner.Demo;
using Taschenrechner.Shared;

namespace Taschenrechner
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			//CSharpDemo demo = new CSharpDemo();
			//double ergebnis = demo.AddMethode(12.5, 21);

			var operation = new Operation(12.2);
			//operation.Typ = OperationsTyp.Zahl;
			//operation.Zahl = 12.2;
			//operation.Operator // Fehler

			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			builder.Services.AddMauiBlazorWebView();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}