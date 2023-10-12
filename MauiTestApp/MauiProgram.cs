using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace MauiTestApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCompatibility()
                .ConfigureMauiHandlers(handlers =>
                {
#if __ANDROID__
                    handlers.AddCompatibilityRenderer(typeof(cmbSDKMaui.ScannerControl), typeof(cmbSDKMaui.Android.ScannerControlRenderer));
#endif
#if __IOS__
                    handlers.AddCompatibilityRenderer(typeof(cmbSDKMaui.ScannerControl), typeof(cmbSDKMaui.iOS.ScannerControlRenderer));
#endif
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
