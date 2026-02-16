using GestionEmpleadosIII.PageModels;
using GestionEmpleadosIII.Pages;
using GestionEmpleadosIII.Services;
using Microsoft.Extensions.Logging;

namespace GestionEmpleadosIII;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<EmpleService>();
        builder.Services.AddTransient<DeparService>();
        builder.Services.AddTransient<SedeService>();
        builder.Services.AddTransient<DetalleEmpleadoPageModel>();
        builder.Services.AddTransient<DetalleDepartPageModel>();
        builder.Services.AddTransient<AboutPageModel>();
        builder.Services.AddTransient<DepartPageModel>();
        builder.Services.AddTransient<EmplePageModel>();
        builder.Services.AddTransient<MainPageModel>();
        builder.Services.AddTransient<SedePageModel>();
        builder.Services.AddTransient<SettingsPageModel>();
        builder.Services.AddTransient<DetalleEmpleadoPage>();
        builder.Services.AddTransient<DetalleDepartPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AboutPage>();
        builder.Services.AddTransient<SedePage>();
        builder.Services.AddTransient<EmplePage>();
        builder.Services.AddTransient<DepartPage>();
        builder.Services.AddTransient<SettingsPage>();
        return builder.Build();
    }
}
