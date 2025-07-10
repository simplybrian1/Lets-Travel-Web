using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using TouristHelper.Services;
using TouristHelper.Shared.Services;

namespace TouristHelper
{
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
                });
            builder.Services.AddSingleton(new HttpClient
            {
#if ANDROID
    BaseAddress = new Uri("http://192.168.16.100:5103/")
#else
                BaseAddress = new Uri("http://localhost:5103/")
#endif
            });


            // Add device-specific services used by the TouristHelper.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            builder.Services.AddAuthorizationCore(); // Required for auth
            builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthStateProvider>();
            builder.Services.AddSingleton<ChatService>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
