using Microsoft.Extensions.Logging;
using CollectedPassionApp_A2D2.Repositories;
using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.Abstractions;
using CollectedPassionApp_A2D2.MVVM.ViewModels;

namespace CollectedPassionApp_A2D2
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<BaseRepository<Category>>();
            builder.Services.AddSingleton<BaseRepository<Collectable>>();
            builder.Services.AddSingleton<BaseRepository<Appuser>>();
            builder.Services.AddSingleton<BaseRepository<Collectable4Sale>>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
