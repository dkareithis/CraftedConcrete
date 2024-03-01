using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CraftedConcrete.Services;
using CraftedConcrete.ViewModels;
using CraftedConcrete.Pages;

namespace CraftedConcrete
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
                })
                .UseMauiCommunityToolkit();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            AddConcreteServices(builder.Services);
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<ProfilePage>();

            return builder.Build();
        }

        private static IServiceCollection 
            AddConcreteServices(IServiceCollection services)
        {
            services.AddSingleton<ConcreteService>();

            services.AddSingleton<HomePage>()
                .AddSingleton<HomeViewModel>();

            services.AddTransientWithShellRoute<AllConcretePage,
                AllConcreteViewModel>(nameof(AllConcretePage));
            
            services.AddTransientWithShellRoute<DetailPage,
                DetailsViewModel>(nameof(DetailPage));
            
            services.AddSingleton<CartViewModel>();
            services.AddTransient<CartPage>();
            return services;
        }
    }
}
