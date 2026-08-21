using Plugin.Maui.Audio;
using Microsoft.Extensions.Logging;

namespace MusicPlayerApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseAudio();

        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}
